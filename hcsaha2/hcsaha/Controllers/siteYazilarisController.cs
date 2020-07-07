using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hcsaha.DAL;

namespace hcsaha.Controllers
{
    public class siteYazilarisController : Controller
    {
        private hcsahaEntities db = new hcsahaEntities();

        // GET: siteYazilaris
        public ActionResult Index()
        {
            return View(db.siteYazilari.ToList());
        }

        // GET: siteYazilaris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siteYazilari siteYazilari = db.siteYazilari.Find(id);
            if (siteYazilari == null)
            {
                return HttpNotFound();
            }
            return View(siteYazilari);
        }

        // GET: siteYazilaris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: siteYazilaris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "yaziID,baslik,yazi,tel,mail,iletisimBaslik,iletisimYazi,rezervasyonbaslik,rezervasyonyazi,hakkimizda,header")] siteYazilari siteYazilari)
        {
            if (ModelState.IsValid)
            {
                db.siteYazilari.Add(siteYazilari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteYazilari);
        }

        // GET: siteYazilaris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siteYazilari siteYazilari = db.siteYazilari.Find(id);
            if (siteYazilari == null)
            {
                return HttpNotFound();
            }
            return View(siteYazilari);
        }

        // POST: siteYazilaris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "yaziID,baslik,yazi,tel,mail,iletisimBaslik,iletisimYazi,rezervasyonbaslik,rezervasyonyazi,hakkimizda,header")] siteYazilari siteYazilari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteYazilari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteYazilari);
        }

        // GET: siteYazilaris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siteYazilari siteYazilari = db.siteYazilari.Find(id);
            if (siteYazilari == null)
            {
                return HttpNotFound();
            }
            return View(siteYazilari);
        }

        // POST: siteYazilaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            siteYazilari siteYazilari = db.siteYazilari.Find(id);
            db.siteYazilari.Remove(siteYazilari);
            db.SaveChanges();
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
