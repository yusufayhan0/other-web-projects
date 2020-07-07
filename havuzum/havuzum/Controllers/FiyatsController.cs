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
    public class FiyatsController : Controller
    {
        private BekohavuzEntities db = new BekohavuzEntities();

        // GET: Fiyats
        public ActionResult Index()
        {
            return View(db.Fiyat.ToList());
        }

        // GET: Fiyats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fiyat fiyat = db.Fiyat.Find(id);
            if (fiyat == null)
            {
                return HttpNotFound();
            }
            return View(fiyat);
        }

        // GET: Fiyats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fiyats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fiyat1,Ogrenci,Sivil,AylıkOgrenci,AylıkSivil,HaftalıkOgrenci,HaftalıkSivil")] Fiyat fiyat)
        {
            if (ModelState.IsValid)
            {
                db.Fiyat.Add(fiyat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fiyat);
        }

        // GET: Fiyats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fiyat fiyat = db.Fiyat.Find(id);
            if (fiyat == null)
            {
                return HttpNotFound();
            }
            return View(fiyat);
        }

        // POST: Fiyats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fiyat1,Ogrenci,Sivil,AylıkOgrenci,AylıkSivil,HaftalıkOgrenci,HaftalıkSivil")] Fiyat fiyat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiyat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fiyat);
        }

        // GET: Fiyats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fiyat fiyat = db.Fiyat.Find(id);
            if (fiyat == null)
            {
                return HttpNotFound();
            }
            return View(fiyat);
        }

        // POST: Fiyats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fiyat fiyat = db.Fiyat.Find(id);
            db.Fiyat.Remove(fiyat);
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
