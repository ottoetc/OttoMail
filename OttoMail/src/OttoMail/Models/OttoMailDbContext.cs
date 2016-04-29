using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OttoMail.Models
{
    public class OttoMailDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Email> Emails { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OttoMail;integrated security = True");
        }
    }
}
