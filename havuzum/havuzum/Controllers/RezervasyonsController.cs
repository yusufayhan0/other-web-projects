using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using havuzum.DAL;

namespace havuzum.Controllers
{
    public class RezervasyonsController : Controller
    {
        private BekohavuzEntities db = new BekohavuzEntities();

        // GET: Rezervasyons
        public ActionResult Index()
        {
            return View(db.Rezervasyon.ToList());
        }

        // GET: Rezervasyons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyon rezervasyon = db.Rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }

        // GET: Rezervasyons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezervasyons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RezervasyonId,gunID,saatID,adi,soyadi,tc,cinsID,onay,durumID")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                db.Rezervasyon.Add(rezervasyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezervasyon);
        }

        // GET: Rezervasyons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyon rezervasyon = db.Rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }

        // POST: Rezervasyons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RezervasyonId,gunID,saatID,adi,soyadi,tc,cinsID,onay,durumID")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervasyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezervasyon);
        }

        // GET: Rezervasyons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyon rezervasyon = db.Rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }

        // POST: Rezervasyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervasyon rezervasyon = db.Rezervasyon.Find(id);
            db.Rezervasyon.Remove(rezervasyon);
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
