using DAL.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interface
{
    public interface IUserMessage :IRepository<UserMessage>
    {
        void Create(string messageText,string Id);
       
    }
}
