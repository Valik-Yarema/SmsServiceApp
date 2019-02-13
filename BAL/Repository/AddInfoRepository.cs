using DAL.DB;
using BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCustomerApp.Data;

namespace BAL.Repository
{
    public class AddInfoRepository:GenericRepository<AddInfo>, IAddInfo
    {
        public AddInfoRepository(ApplicationDbContext context) : base(context)
    {
    }
        public void Create(string addInfo, int phoneId)
        {
            AddInfo information = new AddInfo() { TextInfo = addInfo, PhoneId = phoneId };
            context.AddInfos.Add(information);
            context.SaveChanges();
        }
    
    }
}
