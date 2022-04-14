using System;
using Microsoft.EntityFrameworkCore;
using UniversityModel.Models;

namespace UniversityModel.Contexts
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=localhost;Database=UniversityModel;User=TestUser;Password=VerySecure1");
    }
}
