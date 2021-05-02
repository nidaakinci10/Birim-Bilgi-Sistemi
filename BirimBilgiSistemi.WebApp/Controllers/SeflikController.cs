using BirimBilgiSistemi.BusinessLayer;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.WebApp.Models;
using BirimBilgiSistemi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BirimBilgiSistemi.WebApp.Controllers
{
    public class SeflikController : Controller
    {
       public baskanlikMaganer baskanlikMaganer = new baskanlikMaganer();
        public mudurlukManager mudurlukManager = new mudurlukManager();
        public seflikManager seflikManager = new seflikManager();
        // GET: Seflik
        public ActionResult Index()
        {
            return View(seflikManager.List());
        }
        public ActionResult Create() {


            ViewBag.BaskanlikId = new SelectList(baskanlikMaganer.List(), "ID", "Isim");
            ViewBag.MudurlukId = new SelectList(mudurlukManager.List(), "ID", "Isim");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeflikViewModel seflikViewModel)
        {

            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (!ModelState.IsValid)
            {
                seflik result = new seflik()
                {
                     isim = seflikViewModel.Isim,
                     BaskanlikId=seflikViewModel.BaskanlikId.Value,
                     MudurlukId=seflikViewModel.MudurlukId.Value,
                };
                seflikManager.Insert(result);
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

            List<SeflikDTO> model = new List<SeflikDTO>();

            seflikManager.List().ForEach(x => model.Add(new SeflikDTO()
            {
                ID = x.Id,
                Ad= x.isim,
             //  BaskanlikID= x.BaskanlikId,
                BaskanlikAd =x.Baskanlik.isim,
               // MudurlukID= x.MudurlukId.Value,
                MudurlukAd=x.Mudurluk.isim
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