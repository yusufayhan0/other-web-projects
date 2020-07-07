using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using okargo.DAL;

namespace okargo.Controllers
{
    public class HomeController : Controller
    {
        public static string bilgi;
        private okargoEntities db = new okargoEntities();
        // GET: Home
        public ActionResult Index(string Aranacakkargo)
        {
           
            if (Aranacakkargo != null)
            {
                paketler paket = db.paketler.Where(x => x.gonderi_no == Aranacakkargo).SingleOrDefault();
                if (paket != null)
                {
                    return View(paket);
                }
                ViewBag.mesaj = "Böyle bir korgo yoktur";
            }
            return View();

        }
        public ActionResult login()
        {
            if (Session["kullanici"] == "var")
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            return View();
        }
        [HttpPost, ActionName("login")]
        public ActionResult Giris(personel model)
        {
            personel per = db.personel.Where(x => x.mail == model.mail && x.sifre == model.sifre).SingleOrDefault();
            if (per != null)
            {
                Session["kullanici"] = "var";
                if (per.yetki != false)
                {
                    Session["calisan"] = "yonetici";
                }
                else
                {
                    Session["calisan"] = "calısan";
                }
                
                bilgi = per.adi + " " + per.soyadi;
                
                return RedirectToAction("Anasayfa", "Home");
            }
            return View();
        }
        public ActionResult Anasayfa()
        {
            
            if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            mirascı m = new mirascı();
            m.mirascik(bilgi);
            ViewBag.bilgi = bilgi;
            return View(db.paketler.Where(c => c.dagitimacikti != true).OrderByDescending(x=>x.alimsaati).ToList());
        }
        public ActionResult CikisYap()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}