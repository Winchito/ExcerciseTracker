using System;
using System.Configuration;
using ExcerciseTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ExcerciseTracker.Data
{
    internal class ExcerciseContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigurationManager.AppSettings.Get("SQLiteConnectionString"));
        }

        public DbSet<Excercise> Excercises { get; set; }

    }
}
