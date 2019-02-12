using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DB
{
    public class AddInfo
    {
        [Key]
        public int AdInfoId { get; set; }

        public int? PhoneId { get; set; }
        [ForeignKey("PhoneId")]
        public PhoneRec PhoneRec { get; set; }

        public string TextInfo { get; set; }
    }
}
