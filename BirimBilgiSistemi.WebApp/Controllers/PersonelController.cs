using BirimBilgiSistemi.BusinessLayer;
using BirimBilgiSistemi.DTO;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.WebApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace BirimBilgiSistemi.WebApp.Controllers
{

    public class PersonelController : Controller
    {
        public personelManager personelManager = new personelManager();
        public baskanlikMaganer baskanlikManager = new baskanlikMaganer();
        public mudurlukManager mudurlukManager = new mudurlukManager();
        public seflikManager seflikManager = new seflikManager();
        public ActionResult Index()
        {
            return View(personelManager.List());
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
            List<PersonelDTO> model = new List<PersonelDTO>();

            personelManager.List().ForEach(x => model.Add(new PersonelDTO()
            {
                ID = x.Id,
                sicilNo = x.sicilNo,
                tcKimlik = x.tcKimlik,
                ad = x.ad,
                soyad = x.soyad,
                telefon = x.telefon,
                dahili = x.dahili,
                eposta = x.eposta,
                meslegi = x.meslegi,
                unvani = x.unvani,
                adres = x.adres,
                //Delete="<a class='btn btn-danger' href='"+(data - toggle = "modal" data - target = "#myModal")+"'> Delete</a>",
                Delete = "<a class='btn btn-danger' href='" + this.Url.Action("Delete", "Personel", new { Id = x.Id }) + "'>Delete</a>",
                Update = "<a class='btn btn-warning ' href='" + this.Url.Action("Update", "Personel", new { Id = x.Id }) + "'>Update</a>",
                //Details = "<a class='btn btn-info ' href='" + this.Url.Action("Details", "Personel", new { Id = x.Id }) + "'>Details</a>", data-targeturl="@Url.Action("Details","Home",new { id = item.Id })"
                 Details = "<a class='det btn btn-info' href='#' data-toggle = 'modal', data-target = '#myModal' data-id='new { Id = x.Id }'>Details</a>"
                //  Details = "<a class='det btn btn-info ' href='#' data-toggle = 'modal', data-targeturl = '@Url.Action('Details', 'Personel', new { Id = x.Id })'>Details</a>"
            }));

            if (!string.IsNullOrEmpty(search))//filter
            {
                model = model.Where(x => x.ad.Contains(search)).ToList();
            }
            int FiltrelenmisKayitSayisi = model.Count;
            //short
            model = model.OrderBy(x => x.ad == sortColumnName).ToList();
            //paging
            model = model.Skip(start).Take(length).ToList();

            int toplamKayit = model.Count();

            return Json(new { data = model, draw = Request["draw"], recordsTotal = toplamKayit, recordsFiltered = FiltrelenmisKayitSayisi });

        }

        //Create metodu
    
        public ActionResult Create()

        {
            ViewBag.BaskanlikId = new SelectList(baskanlikManager.List(), "Id", "Isim");
            ViewBag.MudurlukId = new SelectList(mudurlukManager.List(), "Id", "Isim");
            ViewBag.SeflikId = new SelectList(seflikManager.List(), "Id", "Isim");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(PersonelViewModel personelView)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)

            {
                personel result = new personel()
                {
                    ad = personelView.ad,
                    soyad = personelView.soyad,
                    sicilNo = personelView.sicilNo,
                    tcKimlik = personelView.tcKimlik,
                    telefon = personelView.telefon,
                    dahili = personelView.dahili,
                    eposta = personelView.eposta,
                    meslegi = personelView.meslegi,
                    unvani = personelView.unvani,
                    adres = personelView.adres,
                    kanGrubu = personelView.kanGrubu,
                    kullanici_adi = personelView.kullaniciAdi,
                    sifre = personelView.sifre,
                    yakininAdSoyadi = personelView.yakininAdSoyadi,
                    yakininTelefon = personelView.yakininTelefon,
                    baskanlikId = personelView.BaskanlikId,
                    mudurlukId = personelView.MudurlukId,
                    seflikId = personelView.SeflikId,

                };

                personelManager.Insert(result);

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
            personel personel = personelManager.Find(x => x.Id == id.Value);

            if (personel == null)
            {
                return HttpNotFound();
            }

            return View(personel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {

            personel personel = personelManager.Find(x => x.Id == id);
            if (personel != null)
            {
                personelManager.Delete(personel);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personel personel = personelManager.Find(x => x.Id == id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
   
        public ActionResult Update(personel personel)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                personel per = personelManager.Find(x => x.Id == personel.Id);
                if (per != null)
                {

                    per.Id = personel.Id;
                    per.ad = personel.ad;
                    per.soyad = personel.soyad;
                    per.sicilNo = personel.sicilNo;
                    per.tcKimlik = personel.tcKimlik;
                    per.telefon = personel.telefon;
                    per.dahili = personel.dahili;
                    per.eposta = personel.eposta;
                    per.meslegi = personel.meslegi;
                    per.unvani = personel.unvani;
                    per.adres = personel.adres;
                    per.kanGrubu = personel.kanGrubu;
                    per.kullanici_adi = personel.kullanici_adi;
                    per.sifre = personel.sifre;
                    per.yakininAdSoyadi = personel.yakininAdSoyadi;
                    per.yakininTelefon = personel.yakininTelefon;
                 };
                    personelManager.Update(per);
                    return RedirectToAction("Index");

                }
                  return View();
            }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personel personel = personelManager.Find(x => x.Id == id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

    }
}


//public ActionResult Details(PersonelViewModel personel)
//{

//    int id = personel.id;
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    personel result = new personel()
//    {
//        Id = personel.id,
//    };
//    result = personelManager.Find(x => x.Id == id);
//    if (result == null)
//    {
//        return HttpNotFound();
//    }
//    return View(result);
//}




//bu kısım web api için kullanılacak
//string apiUrl = "http://localhost:54057/api/apipersonel";
//WebClient client = new WebClient();
//client.Headers["Content-type"] = "application/json";
//client.Encoding = Encoding.UTF8;
//string json = client.UploadString(apiUrl, null);


//List<personel> model = new List<personel>();
//model = personelManager.List();