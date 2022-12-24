using AutoMapper;
using Common.Enums;
using Common.Exceptions;
using Entities.Interfaces;
using Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using Services.BusinessObjects;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RequestCreateService : IRequestCreateService
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;
        private IMemoryCache _cache;
        private string _key = "support_request";

        public RequestCreateService(IUnitOfWork unit, IMapper mapper, IMemoryCache cache) 
        {
            _unit = unit;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<SupportRequestBO> CreateRequest(SupportRequestBO data, string mail) 
        {
            var user = await _unit.GetUser.FindByMail(mail);
            if (user is null) 
            {
                throw new UserNotFoundException($"User with provided email:{mail} do not exist.");
            }
            
            if (data.UrgencyLevel == UrgencyTypes.Low || data.UrgencyLevel == UrgencyTypes.Medium)
            {
               data.DueDate = DateTime.Now.AddHours(48);
            }
            if (data.UrgencyLevel == UrgencyTypes.High)
            {
               data.DueDate = DateTime.Now.AddHours(24);
            }
            else
            {
               data.DueDate = DateTime.Now.AddHours(4);
            }

            data.UserId = user.Id;
            data.CreatedAt = DateTime.Now;
            data.UpdatedAt = DateTime.Now;
            data.Status = RequestStatusTypes.Open;

            await _unit.GetSupportRequest.CreateRequestAsync(_mapper.Map<SupportRequest>(data));
            await _unit.SaveDataAsync();
            _cache.Remove(_key);

            return data; 
        }

        public async Task SendMessageAsync(long requestId, string content) 
        {
            var request = await _unit.GetSupportRequest.RequestMessageBranch(requestId);
            if (request is null) 
            {
                throw new SupportRequestNotFoundException($"A request with id: {requestId} was not found.");
            }
            
            var message = new SupportRequestMessages ()
            {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Content = content,
            RequestId = request.Id
            };

            await _unit.GetSupportRequest.AddMessage(message);
            await _unit.SaveDataAsync();
            _cache.Remove(_key);
        }

        public async Task UpdateStatus(long requestId, RequestStatusTypes type) 
        {
            var request = await _unit.GetSupportRequest.RequestMessageBranch(requestId);
            if (request is null)
            {
                throw new SupportRequestNotFoundException($"A request with id: {requestId} was not found.");
            }
            request.Status = type;
            _unit.GetSupportRequest.UpdateRequest(request);
            await _unit.SaveDataAsync();
            _cache.Remove(_key);

        }
    }
}
