using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DB
{
   public class PhoneRec
    {
        [Key]
        public int PhoneId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }



        public ICollection<AddInfo> PhoneColl { get; set; }
     //   public ICollection<Message> PhoneMesColl { get; set; }

        public PhoneRec()
        {
            PhoneColl = new List<AddInfo>();
         //   PhoneMesColl = new List<Message>();
        }
    }
}
