using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.BusinessLayer;
using BirimBilgiSistemi.WebApp.Models;
using BirimBilgiSistemi.DTO;

namespace BirimBilgiSistemi.WebApp.Controllers
{
    public class BaskanlikController : Controller
    {
        public baskanlikMaganer baskanlikMaganer = new baskanlikMaganer();
       
        // GET: Baskanlik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BaskanlikViewModel baskanlikViewModel) {

            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if(ModelState.IsValid)
            {
                baskanlik result = new baskanlik()
                {
                    isim = baskanlikViewModel.Ad
                };
                baskanlikMaganer.Insert(result);
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public ActionResult sayfa()
        {
            int draw = Convert.ToInt32(Request.Form["draw"]);// etkin sayfa numarası
            int start = Convert.ToInt32(Request["start"]); ;//listenen ilk kayıtın  index numarası
            int length = Convert.ToInt32(Request["length"]);//sayfadaki toplam listelenecek kayit sayısı
            string search = Request["search[value]"];//arama
            string sortColumnName = Request["columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]"];//Sıralama yapılacak column adı
            string sortDirection = Request["order[0][dir]"];//sıralama türü

            List<BaskanlikDTO> model = new List<BaskanlikDTO>();

            baskanlikMaganer.List().ForEach(x => model.Add(new BaskanlikDTO() {
                ID = x.Id,
                Ad = x.isim
            }));
            if (!string.IsNullOrEmpty(search))//filter
            {
                model = model.Where(x => x.Ad.Contains(search)).ToList();
            }
            int FiltrelenmisKayitSayisi = model.Count;
            //short
            model = model.OrderBy(x => x.Ad == sortColumnName).ToList();
            //paging
            model = model.Skip(start).Take(length).ToList();

            int toplamKayit = model.Count();

            return Json(new { data = model, draw = Request["draw"], recordsTotal = toplamKayit, recordsFiltered = FiltrelenmisKayitSayisi });

        }

    }
 }   