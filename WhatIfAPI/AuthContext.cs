﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VanHackAPI.Models;

namespace VanHackAPI
{
    public class AuthContext : IdentityDbContext<UserModel>
    {
        public AuthContext()
            : base("AuthContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, VanHackAPI.Migrations.Configuration>());
        }

        public DbSet<Company> companys { get; set; }
        //public DbSet<>
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}