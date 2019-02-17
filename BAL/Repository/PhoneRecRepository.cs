using DAL.DB;
using BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCustomerApp.Data;

namespace BAL.Repository
{
    public class PhoneRecRepository : GenericRepository<PhoneRec>, IPhoneRec
    {
        public PhoneRecRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Create(string phoneNumber)
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
