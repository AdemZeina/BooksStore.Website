using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Data.Entity
{
    public class FavoriteBook:BaseEntity
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }
       
        public Book Book { get; set; }

        //[ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
