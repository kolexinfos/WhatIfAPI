using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VanHackAPI.Models;

namespace VanHackAPI
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            UserModel user = new UserModel
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Password = userModel.Password
            };

            string passwordHash = _userManager.PasswordHasher.HashPassword(userModel.Password);
            var result = await _userManager.CreateAsync(user, passwordHash);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            string passwordHash = _userManager.PasswordHasher.HashPassword(password);
            IdentityUser user = await _userManager.FindAsync(userName, passwordHash);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}