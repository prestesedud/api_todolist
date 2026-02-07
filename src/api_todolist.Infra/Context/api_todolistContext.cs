using Microsoft.EntityFrameworkCore;
using api_todolist.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using api_todolist.Domain;

namespace api_todolist.Infra.Context
{
    public class api_todolistContext(DbContextOptions<api_todolistContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tasks> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(api_todolistContext).Assembly);
            //DateTimeConfig.ConfigDateTime(modelBuilder);
            EntitiesConfigurator.Configure(modelBuilder);
            DatabaseSeeder.Seed(modelBuilder);

        }
    }
}
