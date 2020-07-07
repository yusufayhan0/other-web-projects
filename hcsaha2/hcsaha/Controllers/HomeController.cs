using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcsaha.DAL;

namespace hcsaha.Controllers
{
    public class HomeController : Controller
    {
        hcsaha.DAL.hcsahaEntities db = new hcsaha.DAL.hcsahaEntities();
        // GET: Home
        public ActionResult Index()
        {
            var res = db.resimler.Take(6).OrderByDescending(x => x.eklenmeTarihi).ToList();
            var siteyazi = db.siteYazilari.SingleOrDefault();
            return View(Tuple.Create(res, siteyazi));
        }
        
        public ActionResult rezervas()
        {
            ViewBag.gun = db.gunler;
            ViewBag.saat = db.saatler;
            return View();
        }
        public ActionResult giris()
        {
            return View();
        }
        public ActionResult cikis()
        {
            Session.Abandon();
            return RedirectToAction("giris","Home");
        }
        [HttpPost]
        public ActionResult giris(admin adm)
        {
            var admi = db.admin.Where(x => x.kullanici == adm.kullanici && x.sifre == adm.sifre).ToList();
            if (admi.Count == 0)
            {
                ViewBag.kont = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            else
            {
                Session["k"] = adm.kullanici;
                Session["s"] = adm.sifre;
                return RedirectToAction("Index","admins");
            }
            
        }

        [HttpPost]
        public ActionResult rezervas(rezervasyon rez)
        {           
            var rezer = db.rezervasyon.Where(x=>x.gun==rez.gun&&x.saat==rez.saat).ToList();
            if (rezer.Count!=0)
            {
                ViewBag.mesaj = "Dolu";
            }
            else
            {
                rezervasyon kayit = new rezervasyon();
                kayit.adi = rez.adi;
                kayit.soyadi = rez.soyadi;
                kayit.tel = rez.tel;
                kayit.saat = rez.saat;
                kayit.gun = rez.gun;
                db.rezervasyon.Add(rez);
                db.SaveChanges();
                ViewBag.mesaj = "kaydınız başarıyla alınmıştır.";
            }
            ViewBag.gun = db.gunler.ToList();
            ViewBag.saat = db.saatler.ToList();
            return View();
        }
    }
}