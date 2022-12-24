using Common.Enums;
using Entities.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class SupportRequestRepository : ISupportRequestRepository
    {
        private MyAppDbContext _db;
        public SupportRequestRepository(MyAppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SupportRequest>> GetResolvedRequests(ReportTypes type) 
        {
            if (type == ReportTypes.Daily) 
            {
                return await _db.SupportRequests.Where(d => 
                d.DueDate.Date == DateTime.Today && d.Status == RequestStatusTypes.Closed)
                    .ToListAsync();
            }
            if (type == ReportTypes.Weekly)
            {
                return await _db.SupportRequests.Where(d => 
                (d.DueDate - DateTime.Now).Days < 7 && d.Status == RequestStatusTypes.Closed)
                    .ToListAsync();
            }
            
            return await _db.SupportRequests.Where(d => 
            d.DueDate.Month.Equals(DateTime.Now.Month) && d.Status == RequestStatusTypes.Closed)
                .ToListAsync();

        }

        public async Task<IEnumerable<SupportRequest>> ReadUsersRequests(long userId) 
        {
            return await _db.SupportRequests.Where(d => d.Id == userId).ToListAsync();
        }

        public async Task<SupportRequest> RequestMessageBranch(long id) 
        {
            return await _db.SupportRequests.Include(d => d.Messages)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateRequestAsync(SupportRequest request) 
        {
            await _db.SupportRequests.AddAsync(request);
        }

        public void DeleteRequest(SupportRequest request) 
        {
        _db.SupportRequests.Remove(request); 
        }

        public void UpdateRequest(SupportRequest request) 
        {
            _db.SupportRequests.Update(request);
        }

        public async Task AddMessage(SupportRequestMessages message) 
        {
            await _db.SupportRequestMessages.AddAsync(message);
        }
    }
}
