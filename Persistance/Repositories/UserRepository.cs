using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MyAppDbContext _db;
        public UserRepository(MyAppDbContext db)
        {
            _db = db;
        }

        public async Task<User> FindByStamp(string stamp) 
        {
            return await _db.Users.FirstOrDefaultAsync(d => d.SecurityStamp.Equals(stamp));
        }
        public async Task<User> FindByMail(string email) 
        {
            return await _db.Users.FirstOrDefaultAsync(d => d.Email.Equals(email));
        }

        public async Task<IEnumerable<User>> ReadAllUsers(int? limit, int? offset) 
        {
            var result =  _db.Users.AsQueryable();
            if (limit > 0 && offset != null)
            {
                result = result.Skip(offset.Value)
                    .Take(limit.Value);
            }
            return await result.Include(d => d.Requests).ToListAsync();
        }

        public async Task CreateUser(User user) 
        {
            await _db.Users.AddAsync(user);
        }

        public void UpdateUser(User user) 
        {
            _db.Users.Update(user);
        }
    }
}
