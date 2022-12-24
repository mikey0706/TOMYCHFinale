using AutoMapper;
using Common.Enums;
using Common.Exceptions;
using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Services.BusinessObjects;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CustomerCreateService : ICustomerCreateService
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;
        private IMemoryCache _cache;
        private string _key = "customer";

        public CustomerCreateService(IUnitOfWork unit, IMapper mapper, IMemoryCache cache) 
        {
            _unit = unit;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<string> CreateUser(UserBO data) 
        {
            var email = await _unit.GetUser.FindByMail(data.Email);

            if (email != null) 
            {
                throw new UserEmailExistsException($"User with email: {data.Email} already exists.");
            }

            var user = _mapper.Map<User>(data);

            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.Password = new PasswordHasher<User>().HashPassword(user, data.Password);
            user.Role = RoleTypes.User;
            user.SecurityStamp = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            await _unit.GetUser.CreateUser(user);
            await _unit.SaveDataAsync();
            _cache.Remove(_key);

            return user.SecurityStamp;
        }

        public async Task<UserBO> ConfirmEmail(string token)
        {
            var user = await _unit.GetUser.FindByStamp(token);

            if (user == null) 
            {
                throw new UserNotFoundException("Can't find a user");
            }

            user.SecurityStamp = null;
            user.UpdatedAt = DateTime.Now;
            user.EmailConfirmed = true;

            _unit.GetUser.UpdateUser(user);
            await _unit.SaveDataAsync();
            _cache.Remove(_key);

            return _mapper.Map<UserBO>(user);
        }

        public async Task<string> ForgotPassword(string email) 
        {
            var user = await _unit.GetUser.FindByMail(email);
            if (user is null) 
            {
                throw new UserNotFoundException($"A user with email {email} do not exist.");
            }
           
            user.SecurityStamp = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            user.UpdatedAt = DateTime.Now;

            _unit.GetUser.UpdateUser(user);
            await _unit.SaveDataAsync();
            _cache.Remove(_key);

            return user.SecurityStamp;
        }

        public async Task ResetPassword(string token, string password)
        {
            var user = await _unit.GetUser.FindByStamp(token);
            if ((user.UpdatedAt - DateTime.Now).Hours > 2) 
            {
                throw new TokenAuthenticationException("This token is outdated.");
            }
            if (user == null)
            {
                throw new UserNotFoundException("Can't find a user.");
            }

            user.SecurityStamp = null;
            user.UpdatedAt = DateTime.Now;
            user.Password = new PasswordHasher<User>().HashPassword(user, password);

            _unit.GetUser.UpdateUser(user);
            await _unit.SaveDataAsync();
            _cache.Remove(_key);
        }
    }
}
