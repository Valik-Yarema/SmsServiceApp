using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.DB;
using Microsoft.AspNetCore.Identity;

namespace WebCustomerApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

   //   public ICollection<PhoneRec> PhoneRecs { get; set; }
      public ICollection<UserMessage> UserMessages { get; set; }
       public ApplicationUser()
        {
     //       PhoneRecs = new List<PhoneRec>();
            UserMessages = new List<UserMessage>();
        }
    }
}
