using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IReportRepository
    {
        Task<Report> FindById(long id);
        Task CreateReport(Report data);
    }
}
