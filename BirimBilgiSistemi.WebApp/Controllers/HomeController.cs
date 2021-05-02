using BirimBilgiSistemi.BusinessLayer;
using BirimBilgiSistemi.BusinessLayer.Result;
using BirimBilgiSistemi.WebApp.Models;
using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirimBilgiSistemi.Entity.ValueObjects;

namespace BirimBilgiSistemi.WebApp.Controllers
{
    public class HomeController : Controller
    {
        kategoriTipiManager kategoriTipiManager = new kategoriTipiManager();
        personelManager personelManager = new personelManager();
        TakvimViewModel takvimViewModel = new TakvimViewModel();
        takvimManager takvimManager = new takvimManager();
        PersonelViewModel PersonelViewModel = new PersonelViewModel();

        public ActionResult Index()
        {
            //Modal için
            TakvimViewModel takvimViewModel = new TakvimViewModel();
            ViewBag.KategoriTipi = new SelectList(kategoriTipiManager.List(), "Id", "KategoriTipi");
            ViewBag.katilimci = new SelectList(personelManager.List(), "Id", "kullanici_adi");

            //Takvim için
            ViewBag.personelId = new SelectList(personelManager.List(), "Id", "sicilNo");
            return View(takvimViewModel);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<personel> result = personelManager.LoginUser(loginView);
                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(loginView);
                }

                CurrentSession.Set<personel>("login", result.Result);//Session'a kullanıcı bilgi saklama..
                return RedirectToAction("Index");   // yönlendirme
            }
         return View(loginView); 
       }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
        public ActionResult HasError() { return View(); }

       
        [HttpPost]
        public ActionResult Insert(TakvimViewModel takvimViewModel) {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            {
                takvim result = new takvim()
                {
                    etkinlikAd = takvimViewModel.etkinlikAd,
                    etkinlikAciklama = takvimViewModel.etkinlikAciklama,
                    etkinlikKonum = takvimViewModel.etkinlikKonum,
                    etkinlikKategori = takvimViewModel.etkinlikKategori,
                    baslangicTarihi = takvimViewModel.baslangicTarihi,
                    bitisTarihi = takvimViewModel.bitisTarihi,
                    katilimci = takvimViewModel.katilimci
                };


                takvimManager.Insert(result);
                takvimManager.Save();
                return RedirectToAction("Index");

                //  return Json(takvimViewModel, JsonRequestBehavior.AllowGet); metod JSON dı bunu değiştirince alanı kaydedip indexe gönderilme yapılmış oldı
            }
            return View();
           
        }

        [HttpPost]
        public JsonResult Takvim()
        {
            List<TakvimViewModel> takvimViewModel = new List<TakvimViewModel>();
            takvimManager.List().ForEach(x => takvimViewModel.Add(new TakvimViewModel()
            {
                title = x.etkinlikAd,
                start = x.baslangicTarihi.ToString("yyyy-MM-dd HH:mm"),
                end = x.bitisTarihi.ToString("yyyy-MM-dd HH:mm"),
                constraint = "businessHours",
               // color = x.kategoriTipi.RenkKodu,
                groupId = "group",
            }));

            return Json(takvimViewModel, JsonRequestBehavior.AllowGet);
        }

    }
}