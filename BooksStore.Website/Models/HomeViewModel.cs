using BooksStore.Website.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Models
{
    public class HomeViewModel
    {
        public List<BookViewModel> ScienceBooks { get; set; }
        public List<BookViewModel> ProgrammingBooks { get; set; }
        public List<BookViewModel> TechnologyBooks { get; set; }
                    
        public List<BookViewModel> TravelBooks { get; set; }
                    
        public List<BookViewModel> HealthBooks { get; set; }
                    
        public List<BookViewModel>  RomanticBook{ get; set; }
    }

    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public int ReadCount { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public bool Liked { get; set; }
    }
}
