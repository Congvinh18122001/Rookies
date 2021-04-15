using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class libDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-HI0OTCU;Database=LibraryManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        // public libDbContext(DbContextOptions options) : base(options)
        // {
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 

            modelBuilder.Entity<Role>().HasData(
                  new Role(){ID=1,Name="Admin"}
                 ,new Role(){ID=2,Name="User"}
             );
             modelBuilder.Entity<User>().HasData(
                 new User(){ID=1,Username="Admin",Password="123",RoleID=1}
                ,new User(){ID=2,Username="User1",Password="123",RoleID=2}
                ,new User(){ID=3,Username="User4",Password="123",RoleID=2}
                ,new User(){ID=4,Username="User2",Password="123",RoleID=2}
                ,new User(){ID=5,Username="User3",Password="123",RoleID=2}
             );
        }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BorrowingRequest> BorrowingRequests { get; set; }
        public virtual DbSet<RequestDetail> RequestDetails { get; set; }


    }
}