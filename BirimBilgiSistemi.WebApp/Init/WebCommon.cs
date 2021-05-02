using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Common;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.WebApp.Models;

namespace BirimBilgiSistemi.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            personel user = CurrentSession.User;

            if (user != null)
                return user.kullanici_adi;
            else
                return "system";
        }
    }
}