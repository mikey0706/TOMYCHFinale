using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByStamp(string stamp);
        Task<User> FindByMail(string email);
        Task<IEnumerable<User>> ReadAllUsers(int? limit, int? offset);
        Task CreateUser(User user);
        void UpdateUser(User user);
    }
}
