using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Models;

namespace WpfApp15.Data
{
    internal class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Course_degrees> Course_degrees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J624QNQ\\SQLEXPRESS;Initial Catalog=StudentsDB;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course_degrees>().HasKey(scd => new { scd.c_id, scd.std_id });
        }
    }
}
