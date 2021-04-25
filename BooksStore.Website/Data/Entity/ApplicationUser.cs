using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Data.Entity
{

    public class ApplicationUser : IdentityUser<Guid> { }
    public class Role : IdentityRole<Guid> { }
}
