using BAL.Interface;
using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCustomerApp.Data;

namespace BAL.Repository
{
   public class MessageRepository : GenericRepository<Message> , IMessage
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Create(DateTime dataStart, int period, DateTime dateEnd, int phoneId, int userMesId)
        {
            Message message = new Message() { DateStart = dataStart, PeriodCount = period, DateEnd = dateEnd ,PhoneId=phoneId,UserMesId=userMesId};
            context.Messages.Add(message);
            context.SaveChanges();
        }

    }
}
