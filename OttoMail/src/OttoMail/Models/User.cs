using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OttoMail.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        [Key]
        public virtual ICollection<Email> Emails { get; set; }
    }
}
