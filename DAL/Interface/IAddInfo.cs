﻿using DAL.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IAddInfo : IRepository<AddInfo>
    {
        void Create(string addInfo,int phoneId);
      
       
    }
}
