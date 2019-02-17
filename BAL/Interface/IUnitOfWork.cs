using BAL.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Models;


namespace BAL.Interface
{
     public interface IUnitOfWork : IDisposable
    {
        void Save();
      //void Dispose();

        UserManager<ApplicationUser> UserRepository { get; }
        SignInManager<ApplicationUser> SignInRepository { get; }
        UserMessageRepository UserMessageRepository { get; }
        PhoneRecRepository PhoneRecRepository { get; }
        MessageRepository MessageRepository { get; }
    }
}
