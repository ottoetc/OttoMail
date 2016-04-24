using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OttoMail.Models
{
    public class OttoMailDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Email> Emails { get; set; }
    }
}
