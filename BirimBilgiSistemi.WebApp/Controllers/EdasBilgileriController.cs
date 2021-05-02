using BirimBilgiSistemi.WebApp.Models;
using BirimBilgiSistemi.Entity.Entity;
using BirimBilgiSistemi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirimBilgiSistemi.WebApp.Controllers
{
    public class EdasBilgileriController : Controller
    {
        EdasBilgileriManager EdasBilgileriManager = new EdasBilgileriManager();
        // GET: EdasBilgileri
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create() {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  Create(EdasBilgileriViewModel edasBiligleriViewModel) {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            //model state isvalid true hatasına bak false olması lazım
            {
                edasBilgileri result = new edasBilgileri()
                {
                 dagitimSirketi = edasBiligleriViewModel.dagitimSirketi,
                 sorumluIl = edasBiligleriViewModel.sorumluIl,
                 baglantiDurumu= edasBiligleriViewModel.baglantiDurumu,
                 adres = edasBiligleriViewModel.adres,
                 kepAdresi= edasBiligleriViewModel.kepAdresi
                    
                };
                EdasBilgileriManager.Insert(result);
                return RedirectToAction("Index");
            }

            return View();
        }
    }    
}