﻿using eCommerceShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }

        

        public DbSet<Products> Products { get; set; }
    }
}
