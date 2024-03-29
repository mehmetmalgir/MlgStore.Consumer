﻿using Microsoft.EntityFrameworkCore;
using MlgStore.WebUI.Models.Entities;

namespace MlgStore.WebUI.Models.Contexts
{
    public class MlgStoreDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-J3DG8F2;database=MlgStoreDb;trusted_connection=true;");
        }

       
        public DbSet<UserAdmin> UsersAdmin { get; set; }

        public DbSet<Customer> Customers { get; set; }







    }
}
