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
    public class gunlersController : Controller
    {
        private hcsahaEntities db = new hcsahaEntities();

        // GET: gunlers
        public ActionResult Index()
        {
            return View(db.gunler.ToList());
        }

        // GET: gunlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gunler gunler = db.gunler.Find(id);
            if (gunler == null)
            {
                return HttpNotFound();
            }
            return View(gunler);
        }

        // GET: gunlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gunlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gunID,gun")] gunler gunler)
        {
            if (ModelState.IsValid)
            {
                db.gunler.Add(gunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gunler);
        }

        // GET: gunlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gunler gunler = db.gunler.Find(id);
            if (gunler == null)
            {
                return HttpNotFound();
            }
            return View(gunler);
        }

        // POST: gunlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gunID,gun")] gunler gunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gunler);
        }

        // GET: gunlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gunler gunler = db.gunler.Find(id);
            if (gunler == null)
            {
                return HttpNotFound();
            }
            return View(gunler);
        }

        // POST: gunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gunler gunler = db.gunler.Find(id);
            db.gunler.Remove(gunler);
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
