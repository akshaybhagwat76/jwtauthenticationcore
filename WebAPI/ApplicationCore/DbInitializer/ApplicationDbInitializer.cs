using DomainModels.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.SeedData
{
    public static class ApplicationDbInitializer
    {
        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                roleManager.CreateAsync(new Role { Name = "Admin" });
            }
            if (roleManager.FindByNameAsync("User").Result == null)
            {
                roleManager.CreateAsync(new Role { Name = "User" });
            }
        }
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                var user = new User
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com",
                    FullName = "Admin Test",
                    PhoneNumber = "1234567890"
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
