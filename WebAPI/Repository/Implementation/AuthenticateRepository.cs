using Repository.Abstraction;
using ApplicationCore;
using DomainModels.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Repository.Implementation
{
    public class AuthenticateRepository : Repository<User>, IAuthenticateRepository
    {
        private UserManager<User> userManager;
        private SignInManager<User> singInManager;
        private DatabaseContext context
        {
            get
            {
                return this.db as DatabaseContext;
            }
        }
        public AuthenticateRepository(DbContext _db, UserManager<User> _userManager, SignInManager<User> _singInManager)
        {
            this.db = _db;
            this.userManager = _userManager;
            this.singInManager = _singInManager;
        }

        public async Task<bool> Validate(LogInModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                return true;
            else
                return false;
        }

        public async Task<User> GetByName(string UserName)
        {
            var user = await userManager.FindByNameAsync(UserName);
            return user;
        }

        public async Task<bool> IsUserExists(string UserName)
        {
            var user = await userManager.FindByNameAsync(UserName);
            return user == null ? false : true;
        }

        public async Task<IdentityResult> Register(UserRegistrationModel model)
        {

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.Mobile
            };
            var result = await userManager.CreateAsync(user, model.Password);
            return result;

        }

        public async Task<UserProfileModel> GetProfile(string UserId)
        {
            var user = await userManager.FindByIdAsync(UserId);
            return new UserProfileModel
            {
                FullName =  user.FullName,
                Email =  user.Email,
                UserName = user.UserName
            };
        }
    }
}
