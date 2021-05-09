using BooksStore.Website.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Areas.Admin.Models
{
    public class CreateBookViewModel
    {
        public Book Book { get; set; }
        public SelectList Tags { get; set; }
    }
}
