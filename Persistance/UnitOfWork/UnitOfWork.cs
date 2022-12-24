using Entities.Interfaces;
using Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private ISupportRequestRepository _supportRequestRepository;
        private IReportRepository _reportRepository;
        private MyAppDbContext _db;

        public UnitOfWork(IUserRepository userRepository,
            ISupportRequestRepository supportRequestRepository,
            IReportRepository reportRepository,
            MyAppDbContext db) 
        {
            _userRepository = userRepository;
            _supportRequestRepository = supportRequestRepository;
            _reportRepository = reportRepository;
            _db = db;
        }

        public IUserRepository GetUser 
        {
            get 
            {
                return _userRepository;
            }
        }

        public ISupportRequestRepository GetSupportRequest 
        {
            get 
            {
                return _supportRequestRepository;
            }
        }
        public IReportRepository GetReport
        {
            get
            {
                return _reportRepository;
            }
        }
        public async Task SaveDataAsync() 
        {
            await _db.SaveChangesAsync();
        }
    }
}
