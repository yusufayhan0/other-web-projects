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
    public class resimlersController : Controller
    {
        private hcsahaEntities db = new hcsahaEntities();

        // GET: resimlers
        public ActionResult Index()
        {
            return View(db.resimler.ToList());
        }

        // GET: resimlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resimler resimler = db.resimler.Find(id);
            if (resimler == null)
            {
                return HttpNotFound();
            }
            return View(resimler);
        }

        // GET: resimlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: resimlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resimID,resim,eklenmeTarihi")] resimler resimler)
        {
            if (ModelState.IsValid)
            {
                resimler.eklenmeTarihi = DateTime.Now;
                db.resimler.Add(resimler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resimler);
        }

        // GET: resimlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resimler resimler = db.resimler.Find(id);
            if (resimler == null)
            {
                return HttpNotFound();
            }
            return View(resimler);
        }

        // POST: resimlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resimID,resim,eklenmeTarihi")] resimler resimler)
        {
            if (ModelState.IsValid)
            {
                resimler.eklenmeTarihi = DateTime.Now;
                db.Entry(resimler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resimler);
        }

        // GET: resimlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resimler resimler = db.resimler.Find(id);
            if (resimler == null)
            {
                return HttpNotFound();
            }
            return View(resimler);
        }

        // POST: resimlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resimler resimler = db.resimler.Find(id);
            db.resimler.Remove(resimler);
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
