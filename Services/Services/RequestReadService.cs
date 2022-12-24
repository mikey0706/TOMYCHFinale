using AutoMapper;
using Common.Exceptions;
using Entities.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;
using Services.BusinessObjects;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RequestReadService : IRequestReadService
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;

        public RequestReadService(IUnitOfWork unit, IMapper mapper) 
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<SupportRequestBO> GetSupportRequest(long id) 
        {
            var request = _mapper.Map<SupportRequestBO>(await _unit.GetSupportRequest.RequestMessageBranch(id));
            if (request is null)
            {
                throw new SupportRequestNotFoundException($"A request with id: {id} was not found.");
            }
            return request;
        }
    }
}
