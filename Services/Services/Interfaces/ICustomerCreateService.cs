using Services.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICustomerCreateService
    {
        Task<string> CreateUser(UserBO data);
        Task<UserBO> ConfirmEmail(string token);
        Task<string> ForgotPassword(string email);
        Task ResetPassword(string token, string password);
    }
}
