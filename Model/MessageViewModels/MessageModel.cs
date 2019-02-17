using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace WebCustomerApp.Models.MessageViewModels
{
   public  class MessageModel
    {
        [Required]
      //  [Display(Name = "Recepient phone number")]
      //  [RegularExpression(@"^\+[0-9]{12}$", ErrorMessage = "Invalid phone number")]
        public List<string> PhoneNumber { get; set; }

        [Required]
    //    [Display(Name = "Text message")]
        public string MessageText { get; set; }
        
    }
}
