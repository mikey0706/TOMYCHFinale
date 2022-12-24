using Common.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface ISupportRequestRepository
    {
        Task<IEnumerable<SupportRequest>> GetResolvedRequests(ReportTypes type);
        Task<IEnumerable<SupportRequest>> ReadUsersRequests(long userId);
        Task<SupportRequest> RequestMessageBranch(long id);
        Task CreateRequestAsync(SupportRequest request);
        void DeleteRequest(SupportRequest request);
        void UpdateRequest(SupportRequest request);
        Task AddMessage(SupportRequestMessages message);

    }
}
