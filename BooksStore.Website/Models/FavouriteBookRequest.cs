using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Models
{
    public class FavouriteBookRequest
    {
        [JsonProperty("bookId")]
        public string BookId { get; set; }
    }
}
