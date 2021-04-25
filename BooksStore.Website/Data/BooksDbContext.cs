using BooksStore.Website.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Data
{
    public class BooksDbContext  :IdentityDbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }
        public DbSet<IdentityUser> ApplicationUser { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Tag>().HasData(
                new { Id = 1, Name = "Science" },
                new { Id = 2, Name = "Technology" },
                new { Id = 3, Name = "Psycology" });

            //Seeding a  'Administrator' role to AspNetRoles table
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();


            //Seeding the User to AspNetUsers table
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    UserName = "admin@admin.com",
                    NormalizedUserName = "admin@admin.com",
                    PasswordHash = hasher.HashPassword(null, "12345")
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
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
                   CreatedUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   CreatedAt = DateTime.UtcNow
               });

            //builder.Entity<FavoriteBook>()
            //    .HasOne<ApplicationUser>(s => s.User)
            //    .WithMany(ta => ta.FavoriteBooks)
            //    .HasForeignKey(u => u.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FavoriteBook>()
            .HasOne<Book>(s => s.Book)
            .WithMany(ta => ta.FavoriteBooks)
            .HasForeignKey(u => u.BookId)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
