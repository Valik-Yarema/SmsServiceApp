﻿using DAL.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interface
{
    public interface IPhoneRec : IRepository<PhoneRec>
    {
        void Create(string phoneNumber);
        PhoneRec SearchByPhone(string phoneNumber);
    
    }
}
