using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirimBilgiSistemi.BusinessLayer;
using BirimBilgiSistemi.DTO;
using BirimBilgiSistemi.Entity.Entity;

using BirimBilgiSistemi.WebApp.Models;

namespace BirimBilgiSistemi.WebApp.Controllers
{
  
    public class MudurlukController : Controller
    {
        baskanlikMaganer baskanlikMaganer = new baskanlikMaganer();
        mudurlukManager mudurlukManager = new mudurlukManager();
        
        // GET: Mudurluk
        public ActionResult Index()
        {
            
            return View();
            
        }
        public ActionResult Create() {
            ViewBag.baskanlikId = new SelectList(baskanlikMaganer.List(),"ID","Isim");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MudurlukViewModel mudurlukViewModel)
        {

            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            {
                mudurluk result = new mudurluk()
                {
                 
                    isim = mudurlukViewModel.Isim,
                    baskanlikId= mudurlukViewModel.BaskanlikId
                
                };
                mudurlukManager.Insert(result);
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpPost]
        public ActionResult Sayfa()
        {
            int draw = Convert.ToInt32(Request.Form["draw"]);// etkin sayfa numarası
            int start = Convert.ToInt32(Request["start"]); ;//listenen ilk kayıtın  index numarası
            int length = Convert.ToInt32(Request["length"]);//sayfadaki toplam listelenecek kayit sayısı
            string search = Request["search[value]"];//arama
            string sortColumnName = Request["columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]"];//Sıralama yapılacak column adı
            string sortDirection = Request["order[0][dir]"];//sıralama türü

            List<MudurlukDTO> model = new List<MudurlukDTO>();

                mudurlukManager.List().ForEach(x => model.Add(new MudurlukDTO() {
                ID = x.Id,
                Ad = x.isim,
                BaskanlikAd= x.Baskanlik.isim,
               

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