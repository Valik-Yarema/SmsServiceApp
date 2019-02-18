using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace WebCustomerApp.Models.PhoneRecViewModels
{
   public class PhoneVieweModel
    {
        public int id { get; set; }
        [Required]
        [RegularExpression(@"^\+[0-9]{12}$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
      
}
