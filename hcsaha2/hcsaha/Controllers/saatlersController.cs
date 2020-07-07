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
    public class saatlersController : Controller
    {
        private hcsahaEntities db = new hcsahaEntities();

        // GET: saatlers
        public ActionResult Index()
        {
            return View(db.saatler.ToList());
        }

        // GET: saatlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            saatler saatler = db.saatler.Find(id);
            if (saatler == null)
            {
                return HttpNotFound();
            }
            return View(saatler);
        }

        // GET: saatlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: saatlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "saatID,saat")] saatler saatler)
        {
            if (ModelState.IsValid)
            {
                db.saatler.Add(saatler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saatler);
        }

        // GET: saatlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            saatler saatler = db.saatler.Find(id);
            if (saatler == null)
            {
                return HttpNotFound();
            }
            return View(saatler);
        }

        // POST: saatlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "saatID,saat")] saatler saatler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saatler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saatler);
        }

        // GET: saatlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            saatler saatler = db.saatler.Find(id);
            if (saatler == null)
            {
                return HttpNotFound();
            }
            return View(saatler);
        }

        // POST: saatlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            saatler saatler = db.saatler.Find(id);
            db.saatler.Remove(saatler);
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
