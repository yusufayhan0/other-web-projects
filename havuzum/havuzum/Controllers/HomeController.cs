using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using havuzum.DAL;

namespace havuzum.Controllers
{
    public class HomeController : Controller
    {
        BekohavuzEntities db = new BekohavuzEntities();
        public ActionResult Index()
        {
            var fiyatliste = db.Fiyat.SingleOrDefault();
            var saat = db.saatler.ToList();
            var gun = db.gunler.ToList();
            return View(Tuple.Create(fiyatliste,saat,gun));
        }
        public ActionResult rezervasyon()
        {
            ViewBag.gun = db.gunler.Where(x=>x.gunID!=1);
            ViewBag.saat = db.saatler;
            ViewBag.cins = db.cinsiyetler;
            ViewBag.dur = db.durumlar;
            return View();
        }
        [HttpPost]
        public ActionResult rezervasyon(Rezervasyon rez)
        {
            if ((rez.gunID==3||rez.gunID==5)&&rez.cinsID==1)
            {
                ViewBag.mesaj = "Çarşamba ve Cuma Günleri Kadınların Seansıdır.";
            }
            else if((rez.gunID != 3 || rez.gunID != 5) && rez.cinsID == 2)
            {
                ViewBag.mesaj = "Çarşamba ve Cuma Günleri Haric Diğer Günler Erkeklerin Seansıdır.";
            }
            else
            {
                var varmi = db.Rezervasyon.Where(x => x.gunID == rez.gunID && x.saatID == rez.saatID).ToList();
                if (30-varmi.Count==0)
                {                    
                    ViewBag.mesaj = "Kota Dolmuştur";
                }
                else
                {
                    Rezervasyon kayit = new Rezervasyon();
                    kayit.adi = rez.adi;
                    kayit.soyadi = rez.soyadi;
                    kayit.tc = rez.tc;
                    kayit.saatID = rez.saatID;
                    kayit.gunID = rez.gunID;
                    kayit.cinsID = rez.cinsID;
                    db.Rezervasyon.Add(rez);
                    db.SaveChanges();
                    varmi = db.Rezervasyon.Where(x => x.gunID == rez.gunID && x.saatID == rez.saatID).ToList();
                    ViewBag.mesaj = 30 - varmi.Count +" kişilik daha boş yer vardır. Kaydınız alınmıştır";
                }
            }
            
            ViewBag.gun = db.gunler.ToList();
            ViewBag.saat = db.saatler.ToList();
            ViewBag.cins = db.cinsiyetler;
            ViewBag.dur = db.durumlar;
            return View();
        }
        public ActionResult giris()
        {
            if (Session["admin"]=="admin")
            {
                return RedirectToAction("Index", "admins");
            }
            return View();
        }
        [HttpPost,ActionName("giris")]

        public ActionResult girisyap(admin adm)
        {
            admin admin = db.admin.Where(x => x.KullanıcıAdı == adm.KullanıcıAdı && x.Şifre == adm.Şifre).SingleOrDefault();
            if(admin!=null)
            {
                Session["admin"] = "admin";
                return RedirectToAction("Index","admins");
            }
            return View();
        }
        public ActionResult cikis()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }

}