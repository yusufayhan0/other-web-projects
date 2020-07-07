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
    public class rezervasyonsController : Controller
    {
        private hcsahaEntities db = new hcsahaEntities();

        // GET: rezervasyons
        public ActionResult Index()
        {
            return View(db.rezervasyon.ToList());
        }

        // GET: rezervasyons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezervasyon rezervasyon = db.rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }

        // GET: rezervasyons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rezervasyons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rezervasyonID,gun,saat,adi,soyadi,tel,onay")] rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                db.rezervasyon.Add(rezervasyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezervasyon);
        }

        // GET: rezervasyons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezervasyon rezervasyon = db.rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }

        // POST: rezervasyons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rezervasyonID,gun,saat,adi,soyadi,tel,onay")] rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervasyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezervasyon);
        }

        // GET: rezervasyons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezervasyon rezervasyon = db.rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }

        // POST: rezervasyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rezervasyon rezervasyon = db.rezervasyon.Find(id);
            db.rezervasyon.Remove(rezervasyon);
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
