using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DB
{
    public class MessageRec
    {
        [Key]
        public int MesRecId { get; set; }
        public int? PhonesId { get; set; }
        public int? MessageId { get; set; }

        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        public int PeriodCount { get; set; }


        [ForeignKey("PhonesId")]
        public PhoneRec PhoneRec { get; set; }
        [ForeignKey("MessageId")]
        public UserMessage UserMessage { get; set; }

        public MessageRec()
        {
            DateCreate = DateTime.Now.Date;
            DateStart = DateTime.Now.Date;// need default ??? 
        }
    }
}
