﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore001.Models;
using Microsoft.AspNetCore.Identity;

namespace NetCore001.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<NetCore001.Models.Food> Food { get; set; }

        public DbSet<NetCore001.Models.ApplicationUser> ApplicationUser { get; set; }

        //public DbSet<NetCore001.Models.Listar> Listar { get; set; }
        //public DbSet<IdentityRole> identityRole { get; set; }

//[DbFunction(Schema="dbo")]
//        public static int xyz(int Food)
//        {
//            throw new Exception();
//        }
    }
}
