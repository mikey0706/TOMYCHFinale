using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IUnitOfWork
    {
       IUserRepository GetUser { get; }
       ISupportRequestRepository GetSupportRequest { get; }
       IReportRepository GetReport{ get; }
       Task SaveDataAsync();
    }
}
