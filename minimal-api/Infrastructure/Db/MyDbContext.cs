using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Db
{
    public class MyDbContext : DbContext
    {
        private readonly IConfiguration  _configurationAppSettings;

        public MyDbContext(IConfiguration configurationAppSettings)
        {
            _configurationAppSettings = configurationAppSettings;
        }

        public DbSet<Administrator> Administrators {get; set;} = default!;

        public DbSet<Vehicle> Vehicles {get; set;} = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator
                {
                    Id = 1,
                    Email = "admin@test.com",
                    Password = "123456",
                    AccountType = "Adm"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var stringConnection = _configurationAppSettings.GetConnectionString("mysql")?.ToString();

            if (string.IsNullOrEmpty(stringConnection))
            {
                throw new Exception("The stringConnection cannot be null");
            }

            optionsBuilder.UseMySql(
                stringConnection,
                ServerVersion.AutoDetect(stringConnection)
            );
        }
    }
}