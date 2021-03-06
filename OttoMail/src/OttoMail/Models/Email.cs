﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OttoMail.Models
{
    [Table("Emails")]
    public class Email
    {
        [Key]
        public int EmailId { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }
        public bool Checked { get; set; }
        public virtual ApplicationUser User { get; set; }

        private DateTime Now = DateTime.Now;
        private bool DefaultRead = false;

        public Email()
        {
            Date = Now;
            Read = DefaultRead;
        }
    }
}
