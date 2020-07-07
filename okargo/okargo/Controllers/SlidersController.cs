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
using System.IO;

namespace okargo.Controllers
{
    public class SlidersController : Controller
    {
        private okargoEntities db = new okargoEntities();

        // GET: Sliders
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
            return View(await db.Slider.ToListAsync());
        }

        // GET: Sliders/Details/5
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
            Slider slider = await db.Slider.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
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

        // POST: Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Create")]
        public ActionResult kayit()
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Resimler/"), fileName);
                        file.SaveAs(path);
                        Slider slider = new Slider();
                        //Resim Url sini döndürüyor
                        slider.yol = "/Resimler/" + fileName;
                        db.Slider.Add(slider);
                         db.SaveChangesAsync();
                        return RedirectToAction("Index");

                    }
                }

            }

            return View();
        }

        // GET: Sliders/Edit/5
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
            Slider slider = await db.Slider.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "sliderID,yol")] Slider slider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Sliders/Delete/5
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
            Slider slider = await db.Slider.FindAsync(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Slider slider = await db.Slider.FindAsync(id);
            db.Slider.Remove(slider);
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
