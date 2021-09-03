using System;
using Consumer.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Consumer.Persistence
{
    public class AppDbContext: DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<ClassModel> Classes { get; set; }
        
        public string DbPath { get; private set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=my_host;Database=cqrs_masstransit;Username=blue;Password=blue");
    }
}