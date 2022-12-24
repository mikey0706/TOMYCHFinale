using Common.Enums;
using Entities.Models;
using Services.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICustomerReadService
    {
        Task<IEnumerable<UserBO>> GetUsersList(int? limit, int? offset, UrgencyTypes? urgency, RequestStatusTypes? status);
        Task<UserBO> Login(string email, string password);
    }
}
