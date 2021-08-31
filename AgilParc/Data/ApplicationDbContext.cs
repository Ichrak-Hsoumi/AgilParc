using AgilParc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgilParc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Assurence> Assurence { get; set; }
        public DbSet<Chauffeur> Chauffeur { get; set; }
        public DbSet<EquipementEmbarque> EquipementEmbarque { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Parc> Parcs { get; set; }
        public DbSet<Vehicule> Vehicule { get; set; }
        public DbSet<Visite> Visite { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=127.0.0.1;port=3306;user=root;password=;database=AgilParcDb")
                .UseLoggerFactory(LoggerFactory.Create(b => b
                    .AddConsole()
                    .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
