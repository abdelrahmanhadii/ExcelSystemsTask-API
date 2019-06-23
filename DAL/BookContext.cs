using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Book>(b =>
            {
                b.HasKey(a => a.ID);                
                b.Property(a => a.Name).IsRequired();
                b.Property(a => a.Description).IsRequired();
                b.Property(a => a.Author).IsRequired();
                b.Property(a => a.PublishingDate).IsRequired();
                b.Property(a => a.Price).IsRequired();
            });
            mb.Entity<User>(b =>
            {
                b.HasKey(a => a.ID);
                b.Property(a => a.Password).IsRequired();
                b.Property(a => a.RoleID).IsRequired();
                b.Property(a => a.UserName).IsRequired();
            });

            mb.Entity<Role>(b =>
            {
                b.HasKey(a => a.ID);
                b.Property(a => a.Name).IsRequired();
            });
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}