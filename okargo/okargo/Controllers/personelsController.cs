using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using okargo.DAL;

namespace okargo.Controllers
{
    public class personelsController : Controller
    {
        private okargoEntities db = new okargoEntities();

        // GET: personels
        public async Task<ActionResult> Index()
        {
            if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["calisan"] != "yonetici")
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            mirascı m = new mirascı();
            ViewBag.bilgi = m.dondur();
            return View(await db.personel.ToListAsync());
        }

        // GET: personels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
             if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["calisan"] != "yonetici")
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mirascı m = new mirascı();
            ViewBag.bilgi = m.dondur();
            personel personel = await db.personel.FindAsync(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: personels/Create
        public ActionResult Create()
        {
            if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["calisan"] != "yonetici")
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            mirascı m = new mirascı();
            ViewBag.bilgi = m.dondur();
            return View();
        }

        // POST: personels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,adi,soyadi,mail,sifre,yetki")] personel personel)
        {
            if (ModelState.IsValid)
            {
                db.personel.Add(personel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(personel);
        }

        // GET: personels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["calisan"] != "yonetici")
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mirascı m = new mirascı();
            ViewBag.bilgi = m.dondur();
            personel personel = await db.personel.FindAsync(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: personels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,adi,soyadi,mail,sifre,yetki")] personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(personel);
        }

        // GET: personels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["calisan"] != "yonetici")
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mirascı m = new mirascı();
            ViewBag.bilgi = m.dondur();
            personel personel = await db.personel.FindAsync(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            personel personel = await db.personel.FindAsync(id);
            db.personel.Remove(personel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
