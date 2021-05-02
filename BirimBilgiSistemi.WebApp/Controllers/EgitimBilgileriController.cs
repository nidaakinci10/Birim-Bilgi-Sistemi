using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirimBilgiSistemi.BusinessLayer;
using BirimBilgiSistemi.WebApp.Models;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.DTO;
using System.Net;

namespace BirimBilgiSistemi.WebApp.Controllers
{
    public class EgitimBilgileriController : Controller
    {
       public  egitimBilgiManager egitimBilgiManager = new egitimBilgiManager();
        public personelManager personelManager = new personelManager();
        PersonelViewModel PersonelViewModel = new PersonelViewModel();
        // GET: EgitimBilgileri
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
            List<EgitimBilgileriDTO> model = new List<EgitimBilgileriDTO>();

            egitimBilgiManager.List().ForEach(x => model.Add(new EgitimBilgileriDTO()
            {
                Id = x.Id,
                personelId =x.personelId,
                egitimTuru = x.egitimTuru,
                okulAdi = x.okulAdi,
                okulBolum = x.okulBolum,
                mezuniyetYili =x.mezuniyetYili,
                Delete = "<a class='btn btn-danger' href='" + this.Url.Action("Delete", "EgitimBilgileri", new { Id = x.Id }) + "'>Delete</a>",
                Update = "<a class='btn btn-warning ' href='" + this.Url.Action("Update", "EgitimBilgileri", new { Id = x.Id }) + "'>Update</a>",

            }));

            if (!string.IsNullOrEmpty(search))//filter
            {
                model = model.Where(x => x.okulAdi.Contains(search)).ToList();
            }
            int FiltrelenmisKayitSayisi = model.Count;
            //short
            model = model.OrderBy(x => x.okulAdi == sortColumnName).ToList();
            //paging
            model = model.Skip(start).Take(length).ToList();

            int toplamKayit = model.Count();

            return Json(new { data = model, draw = Request["draw"], recordsTotal = toplamKayit, recordsFiltered = FiltrelenmisKayitSayisi });

        }
        public ActionResult Create()
        {
            ViewBag.personelId = new SelectList(personelManager.List(), "Id", "sicilNo");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EgitimBilgileriViewModel egitimBilgileriViewModel) {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            //model state isvalid true hatasına bak false olması lazım
            {
                egitimBilgileri result = new egitimBilgileri()
                {
                    personelId=egitimBilgileriViewModel.personelId,
                    egitimTuru= egitimBilgileriViewModel.egitimTuru,
                    okulAdi= egitimBilgileriViewModel.okulAdi,
                    okulBolum= egitimBilgileriViewModel.okulBolum,
                    mezuniyetYili = egitimBilgileriViewModel.mezuniyetYili,

                };
                egitimBilgiManager.Insert(result);
                return RedirectToAction("Index");
            }

                return View();

        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           egitimBilgileri egitimBilgileri = egitimBilgiManager.Find(x => x.Id == id.Value);

            if (egitimBilgileri == null)
            {
                return HttpNotFound();
            }

            return View(egitimBilgileri);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            egitimBilgileri egitimBilgileri = egitimBilgiManager.Find(x => x.Id == id);

            if (egitimBilgileri != null)
            {
                egitimBilgiManager.Delete(egitimBilgileri);
            }
            return RedirectToAction("Index");
        }
    }  
}