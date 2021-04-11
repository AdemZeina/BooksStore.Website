using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Data.Entity
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public int ReadCount { get; set; }
        
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        
        [ForeignKey("CreatedUser")]
        public int CreatedUserId { get; set; }
        public User CreatedUser { get; set; }

        public List<FavoriteBook> FavoriteBooks { get; set; }
    }
}
