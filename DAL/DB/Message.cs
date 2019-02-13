using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DB
{
    public class Message
    {
        [Key]
        public int MesRecId { get; set; }
        public int? PhoneId { get; set; }
        public int? UserMesId { get; set; }

        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        public int PeriodCount { get; set; }


        [ForeignKey("PhoneId")]
        public PhoneRec PhoneRec { get; set; }
        [ForeignKey("UserMesId")]
        public UserMessage UserMessage { get; set; }

        public Message()
        {
            DateCreate = DateTime.Now.Date;
            DateStart = DateTime.Now.Date;// need default ??? 
        }
    }
}
