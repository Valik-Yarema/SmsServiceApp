using DAL.DB;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCustomerApp.Data;

namespace DAL.Repository
{
    public class PhoneRecRepository : GenericRepository<PhoneRec>, IPhoneRec
    {
        public PhoneRecRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreatePhone(string phoneNumber)
        {
            PhoneRec phone = new PhoneRec() { PhoneNumber = phoneNumber };
            context.PhoneRecs.Add(phone);
            context.SaveChanges();
        }

        public PhoneRec SearchByPhone(string phoneNumber)
        {
            PhoneRec phone = context.PhoneRecs.FirstOrDefault(p => p.PhoneNumber == phoneNumber);
            return phone;
        }
    }
}
