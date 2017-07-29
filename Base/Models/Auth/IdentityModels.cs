using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Models.Auth
{
    public class AppUser : IdentityUser
    {
        public DateTime JoinDate { get; set; }

        public String IpAddress { get; set; }
    }

    public class AppRole : IdentityRole
    {
        public String Description { get; set; }
    }

    public class AppIdentityContext : IdentityDbContext<AppUser>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options)
            : base(options)
        {
        }
        
    }

}
