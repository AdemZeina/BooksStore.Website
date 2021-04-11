using BooksStore.Website.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tag>().HasData(
                new { Id = 1, Name = "Science" },
                new { Id = 2, Name = "Technology" },
                new { Id = 3, Name = "Psycology" });

            builder.Entity<User>().HasData(
               new
               {
                   Id = 1,
                   Name = "John Smith",
                   Email = "john@hotmail.com",
                   Password = "123456",
                   Address = "USA",
                   IsAdmin = true,
                   CreatedAt = DateTime.UtcNow
               },
               new
               {
                   Id = 2,
                   Name = "Gavin Smith",
                   Email = "gavin@hotmail.com",
                   Password = "123456",
                   Address = "USA",
                   IsAdmin = false,
                   CreatedAt = DateTime.UtcNow
               }
              );

            builder.Entity<Book>().HasData(
               new
               {
                   Id = 1,
                   Title = "C# Programming Guide",
                   Description = "From A to Z Guid to program in c#",
                   Content = "C# Programming Guide, From A to Z Guid to program in c#",
                   ImageUrl = "",
                   Author = "Bill Gates",
                   Price = double.Parse("50"),
                   ReadCount = 1,
                   TagId = 2,
                   UserId = 1,
                   CreatedUserId = 1,
                   CreatedAt = DateTime.UtcNow
               });

            builder.Entity<FavoriteBook>()
                .HasOne<User>(s => s.User)
                .WithMany(ta => ta.FavoriteBooks)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FavoriteBook>()
            .HasOne<Book>(s => s.Book)
            .WithMany(ta => ta.FavoriteBooks)
            .HasForeignKey(u => u.BookId)
            .OnDelete(DeleteBehavior.Restrict);

          
        }
    }
}
