using DAL.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    interface IPhoneRec : IRepository<PhoneRec>
    {
        void CreatePhone(string phoneNumber);
        PhoneRec SearchByPhone(string phoneNumber);
    }
}
