using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebCustomerApp.Models;

namespace DAL.DB
{
   public class PhoneRec
    {
        [Key]
        public int PhoneId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
       
        public ICollection<AddInfo> PhoneColl { get; set; }
     //   public ICollection<Message> PhoneMesColl { get; set; }

        public PhoneRec()
        {
            PhoneColl = new List<AddInfo>();
         //   PhoneMesColl = new List<Message>();
        }
    }
}
