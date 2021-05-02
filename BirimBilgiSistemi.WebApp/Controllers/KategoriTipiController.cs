using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirimBilgiSistemi.WebApp.Models;
using BirimBilgiSistemi.DTO;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.BusinessLayer;
namespace BirimBilgiSistemi.WebApp.Controllers
{
    public class KategoriTipiController : Controller
    {
        kategoriTipiManager kategoriTipiManager = new kategoriTipiManager();
        // GET: KategoriTipi
        public ActionResult Index()
        {
            return View();
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
            List<KategoriTipiDTO> model = new List<KategoriTipiDTO>();

            kategoriTipiManager.List().ForEach(x => model.Add(new KategoriTipiDTO()
            {
                id=x.Id,
                KategoriTipi=x.KategoriTipi,
                RenkKodu=x.RenkKodu,
                Delete = "<a class='btn btn-danger' href='" + this.Url.Action("Delete", "Takvim", new { Id = x.Id }) + "'>Delete</a>",
                Update = "<a class='btn btn-warning ' href='" + this.Url.Action("Update", "Takvim", new { Id = x.Id }) + "'>Update</a>",
              

            }));

            if (!string.IsNullOrEmpty(search))//filter
            {
                model = model.Where(x => x.KategoriTipi.Contains(search)).ToList();

            }
            int FiltrelenmisKayitSayisi = model.Count;
            //short
            model = model.OrderBy(x => x.KategoriTipi == sortColumnName).ToList();

            //paging
            model = model.Skip(start).Take(length).ToList();

            int toplamKayit = model.Count();

            return Json(new { data = model, draw = Request["draw"], recordsTotal = toplamKayit, recordsFiltered = FiltrelenmisKayitSayisi });

        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KategoriTipiViewModel kategoriTipiViewModel) {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            {
                kategoriTipi result = new kategoriTipi()
                {
                    KategoriTipi = kategoriTipiViewModel.KategoriTipi,
                    RenkKodu = kategoriTipiViewModel.RenkKodu,
                };
                kategoriTipiManager.Insert(result);
                return RedirectToAction("Index");
            }
                return View();
        }
    }
}