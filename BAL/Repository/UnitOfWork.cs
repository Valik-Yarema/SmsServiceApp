using BAL.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCustomerApp.Data;
using WebCustomerApp.Models;

namespace BAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _DbContext;
        private bool disposed = false;
        private AddInfoRepository     infoRepository;
        public UserManager<ApplicationUser> userRepository     { get; }
        public SignInManager<ApplicationUser> SignInRepository { get; }
        private UserMessageRepository userMessageRepository;
        private PhoneRecRepository    recRepository;
        private MessageRepository     messageRepository;

        public UnitOfWork(ApplicationDbContext connectionContext,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInRepository)
        {
            _DbContext = connectionContext;
            userRepository = userManager;
            SignInRepository = signInRepository;
        }
        
        public AddInfoRepository InfoRepository
        {
            get
            {

                if (infoRepository == null)
                {
                    infoRepository = new AddInfoRepository(_DbContext);
                }
                return infoRepository;
            }
        }
        public UserMessageRepository UserMessageRepository
        {
            get
            {
                if (userMessageRepository == null)
                {
                    userMessageRepository = new UserMessageRepository(_DbContext);
                }
                return userMessageRepository;
            }
        }
        public PhoneRecRepository RecRepository
        {
            get
            {
                if (recRepository == null)
                {
                    recRepository = new PhoneRecRepository(_DbContext);
                }
                return recRepository;
            }

        }
        public MessageRepository MessageRepository
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new MessageRepository(_DbContext);
                }
                return messageRepository;
            }

        }

        #region default Save & Dispose
        public void Save()
        {
            _DbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _DbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
