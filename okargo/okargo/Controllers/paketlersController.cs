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

namespace okargo.Controllers
{
    public class paketlersController : Controller
    {
        HomeController hm = new HomeController();
        public int fiyat;
        private okargoEntities db = new okargoEntities();

        // GET: paketlers
        public async Task<ActionResult> Index()
        {
            if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            mirascı m = new mirascı();
            ViewBag.bilgi = m.dondur();
            var paketler = db.paketler.Include(p => p.sehirler).Include(p => p.sehirler1);
            return View(await paketler.OrderByDescending(x=>x.alimsaati).ToListAsync());
        }

        // GET: paketlers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mirascı m = new mirascı();
            ViewBag.bilgi = m.dondur();
            paketler paketler = await db.paketler.FindAsync(id);
            if (paketler == null)
            {
                return HttpNotFound();
            }
            return View(paketler);
        }

        // GET: paketlers/Create
        public ActionResult Create()
        {
            if (Session["kullanici"] != "var")
            {
                return RedirectToAction("Index", "Home");
            }
            mirascı m = new mirascı();
            ViewBag.bilgi = m.dondur();
            ViewBag.nereden = new SelectList(db.sehirler, "sehirID", "sehir");
            ViewBag.nereye = new SelectList(db.sehirler, "sehirID", "sehir");
            return View();
        }

        // POST: paketlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "gonderiID,gonderi_no,tc,adi,soyadi,nereden,nereye,aliciadisoyadi,adres,nerede,fiyat,agirlik")] paketler paketler)
        {
            int kilo = Convert.ToInt32(paketler.agirlik);
            if (ModelState.IsValid)
            {
                if(kilo<=5)
                {
                    fiyat =  15;
                }
                else if(kilo<=10)
                {
                    int a = 15;
                    for(int i=6;i<=kilo;i++)
                    {
                        a = a + 1;
                    }
                    fiyat = a;
                }
                paketler.alimsaati = DateTime.Now;
                Random rastgele = new Random();
                paketler.gonderi_no = rastgele.Next(10000, 999999999).ToString();
                paketler.fiyat = fiyat;
                Convert.ToInt32(paketler.fiyat);
                db.paketler.Add(paketler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.nereden = new SelectList(db.sehirler, "sehirID", "sehir", paketler.nereden);
            ViewBag.nereye = new SelectList(db.sehirler, "sehirID", "sehir", paketler.nereye);
            return View(paketler);
        }

        // GET: paketlers/Edit/5
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
            paketler paketler = await db.paketler.FindAsync(id);
            if (paketler == null)
            {
                return HttpNotFound();
            }
            ViewBag.nereden = new SelectList(db.sehirler, "sehirID", "sehir", paketler.nereden);
            ViewBag.nereye = new SelectList(db.sehirler, "sehirID", "sehir", paketler.nereye);
            return View(paketler);
        }

        // POST: paketlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "gonderiID,gonderi_no,tc,adi,soyadi,nereden,nereye,alicıadisoyadi,adres,nerede,fiyat,agirlik")] paketler paketler)
        {
            if (ModelState.IsValid)
            {
                Convert.ToDateTime(paketler.tahminiteslim);
                paketler.dagitimacikti = true;
                db.Entry(paketler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.nereden = new SelectList(db.sehirler, "sehirID", "sehir", paketler.nereden);
            ViewBag.nereye = new SelectList(db.sehirler, "sehirID", "sehir", paketler.nereye);
            return View(paketler);
        }

        // GET: paketlers/Delete/5
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
            paketler paketler = await db.paketler.FindAsync(id);
            if (paketler == null)
            {
                return HttpNotFound();
            }
            return View(paketler);
        }

        // POST: paketlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            paketler paketler = await db.paketler.FindAsync(id);
            db.paketler.Remove(paketler);
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
