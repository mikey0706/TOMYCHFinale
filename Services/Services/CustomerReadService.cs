using AutoMapper;
using Common.Enums;
using Common.Exceptions;
using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.BusinessObjects;
using Services.Services.Interfaces;


namespace Services.Services
{
    public class CustomerReadService : ICustomerReadService
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;

        public CustomerReadService(IUnitOfWork unit,
            IMapper mapper) 
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserBO>> GetUsersList(int? limit, int? offset, UrgencyTypes? urgency, RequestStatusTypes? status)
        {
            var result = await _unit.GetUser.ReadAllUsers(limit, offset);
            if (urgency != null || status != null)
            {
                 foreach (var item in result)
                 {
                     item.Requests = item.Requests.Where(r =>
                          r.Status == status || r.UrgencyLevel == urgency)
                          .ToList();
                 }
            }
            return _mapper.Map<IEnumerable<UserBO>>(result);
        }

        public async Task<UserBO> Login(string email, string password) 
        {
            var user = await _unit.GetUser.FindByMail(email);
            if (user is null) 
            {
                throw new UserNotFoundException($"User with provided {email} not found.");
            }
            
            var hashPassword = new PasswordHasher<User>()
                    .VerifyHashedPassword(user, user.Password, password);

            if (hashPassword.Equals(PasswordVerificationResult.Failed)) 
            {
               throw new UsersPasswordVerificationException("Wrong password.");
            }
            return _mapper.Map<UserBO>(user);

        }
    }
}
