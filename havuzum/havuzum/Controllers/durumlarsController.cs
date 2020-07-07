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
    public class durumlarsController : Controller
    {
        private BekohavuzEntities db = new BekohavuzEntities();

        // GET: durumlars
        public ActionResult Index()
        {
            return View(db.durumlar.ToList());
        }

        // GET: durumlars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            durumlar durumlar = db.durumlar.Find(id);
            if (durumlar == null)
            {
                return HttpNotFound();
            }
            return View(durumlar);
        }

        // GET: durumlars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: durumlars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "durumID,durum")] durumlar durumlar)
        {
            if (ModelState.IsValid)
            {
                db.durumlar.Add(durumlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(durumlar);
        }

        // GET: durumlars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            durumlar durumlar = db.durumlar.Find(id);
            if (durumlar == null)
            {
                return HttpNotFound();
            }
            return View(durumlar);
        }

        // POST: durumlars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "durumID,durum")] durumlar durumlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(durumlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(durumlar);
        }

        // GET: durumlars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            durumlar durumlar = db.durumlar.Find(id);
            if (durumlar == null)
            {
                return HttpNotFound();
            }
            return View(durumlar);
        }

        // POST: durumlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            durumlar durumlar = db.durumlar.Find(id);
            db.durumlar.Remove(durumlar);
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
