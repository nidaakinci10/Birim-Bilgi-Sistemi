using BirimBilgiSistemi.BusinessLayer;
using BirimBilgiSistemi.DTO;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirimBilgiSistemi.WebApp.Controllers
{
    public class TakvimController : Controller
    {
        kategoriTipiManager kategoriTipiManager = new kategoriTipiManager();
        personelManager personelManager = new personelManager();
        TakvimViewModel takvimViewModel = new TakvimViewModel();
        takvimManager takvimManager = new takvimManager();
        PersonelViewModel PersonelViewModel = new PersonelViewModel();
        // GET: Takvim
        public ActionResult Index()
        {
            return View(takvimManager.List());
        }
        [HttpPost]
        public ActionResult verisayfalama()
        {
            int draw = Convert.ToInt32(Request.Form["draw"]);// etkin sayfa numarası
            int start = Convert.ToInt32(Request["start"]); ;//listenen ilk kayıtın  index numarası
            int length = Convert.ToInt32(Request["length"]);//sayfadaki toplam listelenecek kayit sayısı
            string search = Request["search[value]"];//arama
            string sortColumnName = Request["columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]"];//Sıralama yapılacak column adı
            string sortDirection = Request["order[0][dir]"];//sıralama türü
            //string row= Request["rows["+Request.Form()]
            List<TakvimDTO> model = new List<TakvimDTO>();

            takvimManager.List().ForEach(x => model.Add(new TakvimDTO()
            {
                Id=x.Id,
                personel_id=x.personel_id,
                etkinlikAd=x.etkinlikAd,
                etkinlikAciklama =x.etkinlikAciklama,
                etkinlikKategori=x.etkinlikKategori,
                etkinlikKonum=x.etkinlikKonum,
                baslangicTarihi=x.baslangicTarihi,
                bitisTarihi=x.bitisTarihi,
                katilimci=x.katilimci,
                Delete = "<a class='btn btn-danger' href='" + this.Url.Action("Delete", "Takvim", new { Id = x.Id }) + "'>Delete</a>",
                Update = "<a class='btn btn-warning ' href='" + this.Url.Action("Update", "Takvim", new { Id = x.Id }) + "'>Update</a>",
                Details = "<a class='btn btn-info ' href='" + this.Url.Action("Details", "Takvim", new { Id = x.Id }) + "'>Details</a>",
                
            }));

            if (!string.IsNullOrEmpty(search))//filter
            {
                model = model.Where(x => x.etkinlikAd.Contains(search)).ToList();
               
            }
            int FiltrelenmisKayitSayisi = model.Count;
            //short
            model = model.OrderBy(x => x.etkinlikAd == sortColumnName).ToList();
          
            //paging
            model = model.Skip(start).Take(length).ToList();

            int toplamKayit = model.Count();

            return Json(new { data = model, draw = Request["draw"], recordsTotal = toplamKayit, recordsFiltered = FiltrelenmisKayitSayisi });

        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.KategoriTipi = new SelectList(kategoriTipiManager.List(), "Id", "KategoriTipi");
            ViewBag.katilimci = new SelectList(personelManager.List(), "Id", "kullanici_adi");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //normal create.cshtml üzerinden takvime ekleme yaptım. bunu sidebar da etkinlik ekle için kullandım.
        //modal dan ekleme ise sadece anasayfa üzerindeki etkinlik ekleden yapacak.
        public ActionResult Create(TakvimViewModel takvimViewModel)
        {
            
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            {
                takvim result = new takvim()
                {
                  //  personel_id = takvimViewModel.personel_id,
                    etkinlikAd = takvimViewModel.etkinlikAd,
                    etkinlikAciklama = takvimViewModel.etkinlikAciklama,
                    etkinlikKonum = takvimViewModel.etkinlikKonum,
                    etkinlikKategori = takvimViewModel.etkinlikKategori,
                    baslangicTarihi = takvimViewModel.baslangicTarihi,
                    bitisTarihi = takvimViewModel.bitisTarihi,
                    katilimci = takvimViewModel.katilimci
                };
                takvimManager.Insert(result);
                return RedirectToAction("Index");
            }
            return View();
        }
        public JsonResult GetPerson(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var users = personelManager.List(x => x.ad.Contains(term)).Select(s => s.Id + " - " + s.sicilNo + " - " + s.ad + " " + s.soyad).ToList();
                return Json(users, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var users = personelManager.List().Select(s => s.Id + " - " + s.sicilNo + " - " + s.ad + " " + s.soyad);
                return Json(users, JsonRequestBehavior.AllowGet);
            }
        }
    }
}