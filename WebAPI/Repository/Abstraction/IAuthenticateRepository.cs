using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Repository.Abstraction
{
    public interface IAuthenticateRepository : IRepository<User>
    {
        Task<bool> Validate(LogInModel model);
        Task<User> GetByName(string UserName);
        Task<bool> IsUserExists(string UserName);
        Task<IdentityResult> Register(UserRegistrationModel model);
        Task<UserProfileModel> GetProfile(string UserId);
    }
}
