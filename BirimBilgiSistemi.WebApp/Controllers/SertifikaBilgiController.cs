using BirimBilgiSistemi.BusinessLayer;
using BirimBilgiSistemi.WebApp.Models;
using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirimBilgiSistemi.WebApp.Controllers
{
    public class SertifikaBilgiController : Controller
    {
        // GET: SertifikaBilgi
        sertifikaBilgiManager sertifikaBilgiManager = new sertifikaBilgiManager();
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
        public ActionResult Create(SertifikaBilgiViewModel sertifikaBilgiViewModel)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            //model state isvalid true hatasına bak false olması lazım
            {
                sertifikaBilgi result = new sertifikaBilgi()
                {
                    sertifikaAdi = sertifikaBilgiViewModel.sertifikaAdi,
                    sertifikaTarihi = sertifikaBilgiViewModel.sertifikaTarihi,
                    sertifikaKurum = sertifikaBilgiViewModel.sertifikaKurum,
                    sertifikaAciklama = sertifikaBilgiViewModel.sertifikaAciklama
                };
                sertifikaBilgiManager.Insert(result);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}