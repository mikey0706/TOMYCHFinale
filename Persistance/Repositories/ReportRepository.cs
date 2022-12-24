using Entities.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private MyAppDbContext _db;
        public ReportRepository(MyAppDbContext db) 
        {
            _db = db;
        }

        public async Task<Report> FindById(long id) 
        {
            return await _db.Reports.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateReport(Report data) 
        {
            await _db.Reports.AddAsync(data);
        }
    }
}
