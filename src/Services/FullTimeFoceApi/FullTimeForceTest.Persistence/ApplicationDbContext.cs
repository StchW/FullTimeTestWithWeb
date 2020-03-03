using FulltimeForceTest.Domain.EmployeeAggregate;
using FulltimeForceTest.Domain.StudentAggregate;
using FulltimeForceTest.Domain.WordPalindromaAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullTimeForceTest.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public void Save()
        {
            this.SaveChanges();
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<WordPalindroma> WordPalindroma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(local);Database=FullTimeForceDB;Integrated Security=True");
        }
    }
}
