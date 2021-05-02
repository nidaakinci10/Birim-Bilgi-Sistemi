using BirimBilgiSistemi.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.BusinessLayer
{
    public class test
    {
        public test()
        {
            DataAccessLayer.EntityFramework.DatabaseContext database = new DataAccessLayer.EntityFramework.DatabaseContext();
            database.Personel.ToList();
            
        }
    }
}