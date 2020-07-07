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
    public class cinsiyetlersController : Controller
    {
        private BekohavuzEntities db = new BekohavuzEntities();

        // GET: cinsiyetlers
        public ActionResult Index()
        {
            return View(db.cinsiyetler.ToList());
        }

        // GET: cinsiyetlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cinsiyetler cinsiyetler = db.cinsiyetler.Find(id);
            if (cinsiyetler == null)
            {
                return HttpNotFound();
            }
            return View(cinsiyetler);
        }

        // GET: cinsiyetlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cinsiyetlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cinsID,cinsiyet")] cinsiyetler cinsiyetler)
        {
            if (ModelState.IsValid)
            {
                db.cinsiyetler.Add(cinsiyetler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cinsiyetler);
        }

        // GET: cinsiyetlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cinsiyetler cinsiyetler = db.cinsiyetler.Find(id);
            if (cinsiyetler == null)
            {
                return HttpNotFound();
            }
            return View(cinsiyetler);
        }

        // POST: cinsiyetlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cinsID,cinsiyet")] cinsiyetler cinsiyetler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinsiyetler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinsiyetler);
        }

        // GET: cinsiyetlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cinsiyetler cinsiyetler = db.cinsiyetler.Find(id);
            if (cinsiyetler == null)
            {
                return HttpNotFound();
            }
            return View(cinsiyetler);
        }

        // POST: cinsiyetlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cinsiyetler cinsiyetler = db.cinsiyetler.Find(id);
            db.cinsiyetler.Remove(cinsiyetler);
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
