using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Data.Entity
{
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser<string> { }
    public class Role : IdentityRole<string> { }
}
