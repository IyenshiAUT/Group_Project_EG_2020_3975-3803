using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleSystem.Models
{
    public class DatabaseContext:DbContext
    {
        public readonly string Path = @"D:\Taneesha\3rd Semester\Group Project Duet\Group\PointofSaleSystem\Database.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path}");
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
