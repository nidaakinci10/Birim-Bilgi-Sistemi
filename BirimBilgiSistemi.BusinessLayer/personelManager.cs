using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using BirimBilgiSistemi.BusinessLayer.Abstact;
using BirimBilgiSistemi.BusinessLayer.Result;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.Entity.Messages;
using BirimBilgiSistemi.Entity.ValueObjects;
namespace BirimBilgiSistemi.BusinessLayer
{
    public class personelManager:ManagerBase<personel>
    {
        public BusinessLayerResult<personel> LoginUser(LoginViewModel data)
        {
            // Giriş kontrolü
           BusinessLayerResult<personel> res = new BusinessLayerResult<personel>();
          //  personel personel = Find(x => x.kullanici_adi == data.Username && x.sifre == data.Password);
          res.Result = Find(x => x.kullanici_adi == data.Username && x.sifre == data.Password);

            if (res.Result != null)
            {
             
            }

            else
            {
                res.AddError(ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı Adınızı veya Şifrenizi Hatalı Girdiniz");
                
            }

            return res;
        }
    }
}