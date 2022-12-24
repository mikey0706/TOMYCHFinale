using Common.Enums;
using Services.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IRequestCreateService
    {
        Task<SupportRequestBO> CreateRequest(SupportRequestBO data, string mail);
        Task SendMessageAsync(long requestId, string content);
        Task UpdateStatus(long requestId, RequestStatusTypes type);
    }
}
