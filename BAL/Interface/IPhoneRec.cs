using DAL.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interface
{
    public interface IPhoneRec : IRepository<PhoneRec>
    {
        void Create(string phoneNumber, string userId);
        PhoneRec SearchByPhone(string phoneNumber);
        List<PhoneRec> GetByUserId(string userId);
    }
}
