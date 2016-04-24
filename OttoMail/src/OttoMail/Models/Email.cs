using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OttoMail.Models
{
    public class Email
    {
        [Key]
        public int EmailId { get; set; }
        public string Sender { get; set; }
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }
        public bool Checked { get; set; }
        public virtual User User { get; set; }
    }
}
