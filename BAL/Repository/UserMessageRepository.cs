using BAL.Interface;
using DAL.DB;
using System;
using System.Collections.Generic;
using System.Text;
using WebCustomerApp.Data;

namespace BAL.Repository
{
   public class UserMessageRepository: GenericRepository<UserMessage>,IUserMessage
    {
        public UserMessageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Create(string messageText, string Uid)
        {
            UserMessage userMess = new UserMessage() { Id = Uid , MessageText=messageText };
            context.UserMessages.Add(userMess);
            context.SaveChanges();
        }
    }
}
