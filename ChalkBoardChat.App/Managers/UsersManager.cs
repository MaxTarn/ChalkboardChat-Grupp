using ChalkBoardChat.Data.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkBoardChat.App.Managers
{
    public class UsersManager
    {
        private readonly AuthDbContext _authDbContext;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;



        public UsersManager(AuthDbContext authContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _authDbContext = authContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }





        public async Task<bool> CheckIfUserExists(string? userName)
        {
            if (string.IsNullOrEmpty(userName)) return false;
            IdentityUser? user = await _userManager.Users.FirstOrDefaultAsync(usr => usr.UserName == userName);
            if (user == null) return false;
            return true;
        }

        public async Task<IdentityResult?> AddUser(string? userName, string? password)
        {
            if (string.IsNullOrEmpty(userName)) return null;
            if (string.IsNullOrEmpty(password)) return null;
            var user = new IdentityUser { UserName = userName };

            IdentityResult result = await _userManager.CreateAsync(user, password);

            return result;

        }

        public async Task<IdentityResult?> DeleteByUserName(string? userName)
        {
            IdentityUser? usertoDelete = await _userManager.FindByNameAsync(userName);
            if (usertoDelete == null) return null;
            return await _userManager.DeleteAsync(usertoDelete);
        }

        public async Task<SignInResult?> SignInUser(string? username, string? password, bool rememberUser = false, bool lockOutUser = false)
        {
            if (string.IsNullOrEmpty(username)) return null;
            if (string.IsNullOrEmpty(password)) return null;
            SignInResult? result = await _signInManager.PasswordSignInAsync(username, password, rememberUser, lockOutUser);
            return result;
        }

        public async Task SignOutUser()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
