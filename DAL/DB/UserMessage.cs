using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebCustomerApp.Models;

namespace DAL.DB
{
   public class UserMessage
    {
        [Key]
        public int UserMesId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string MessageText { get; set; }

        public ICollection<Message> MesMesColl { get; set; }
        public UserMessage()
        {
            MesMesColl = new List<Message>();
        }
    }
}
