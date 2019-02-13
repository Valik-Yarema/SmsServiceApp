using DAL.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAL.Interface
{
    public interface IMessage : IRepository<Message>
    {
        void Create(DateTime dataStart, int period, DateTime dateEnd ,int phoneId,int userMesId );

      /*  Message SearchByCreateDate(DateTime dateTime);


        public Message SearchByCreateDate(DateTime dateTime)
        {
            Message message = context.Messages.FirstOrDefault(p => p.DateCreate == dateTime));
            return message;
        }*/
    }
}
