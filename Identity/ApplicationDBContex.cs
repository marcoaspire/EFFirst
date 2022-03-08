using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFFirst.Identity
{
    public class ApplicationDBContex: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContex(): base("Default") { }
    }
}