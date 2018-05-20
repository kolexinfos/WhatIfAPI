namespace VanHackAPI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VanHackAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VanHackAPI.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VanHackAPI.AuthContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<UserModel>(
                new UserStore<UserModel>(
                    new AuthContext()));

            // Create 4 test users:
            for (int i = 0; i < 4; i++)
            {
                var user = new UserModel()
                {
                    FirstName = string.Format("FirstName{0}", i.ToString()),
                    LastName = string.Format("LastName{0}", i.ToString())
                   
                };
                manager.Create(user, string.Format("Password{0}", i.ToString()));
            }
        }
    }
}
