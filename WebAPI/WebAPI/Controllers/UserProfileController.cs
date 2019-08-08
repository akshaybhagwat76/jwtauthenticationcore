using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Entities;
using DomainModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<User> _userManager;
        private IUnitOfWork unitOfWork;
        public UserProfileController(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<UserProfileModel> GetUserProfile() {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await unitOfWork.AuthenticateRepo.GetProfile(userId);
            return user;
        }
    }
}