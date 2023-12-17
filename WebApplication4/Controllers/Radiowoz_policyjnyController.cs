using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class Radiowoz_policyjnyController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Radiowoz_policyjny
        public ActionResult Index()
        {
            var radiowowzy_policyjne = db.Radiowowzy_policyjne.Include(r => r.Samochod);
            return View(radiowowzy_policyjne.ToList());
        }

        // GET: Radiowoz_policyjny/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiowoz_policyjny radiowoz_policyjny = db.Radiowowzy_policyjne.Find(id);
            if (radiowoz_policyjny == null)
            {
                return HttpNotFound();
            }
            return View(radiowoz_policyjny);
        }

        // GET: Radiowoz_policyjny/Create
        public ActionResult Create()
        {
            ViewBag.id_Samochodu = new SelectList(db.Samochody, "Id_Samochodu", "Marka");
            return View();
        }

        // POST: Radiowoz_policyjny/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nr_Rejestracyjny,Rocznik,id_Samochodu,Ubezpieczenie,Przebieg,Przeglad")] Radiowoz_policyjny radiowoz_policyjny)
        {
            if (ModelState.IsValid)
            {
                db.Radiowowzy_policyjne.Add(radiowoz_policyjny);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Samochodu = new SelectList(db.Samochody, "Id_Samochodu", "Marka", radiowoz_policyjny.id_Samochodu);
            return View(radiowoz_policyjny);
        }

        // GET: Radiowoz_policyjny/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiowoz_policyjny radiowoz_policyjny = db.Radiowowzy_policyjne.Find(id);
            if (radiowoz_policyjny == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Samochodu = new SelectList(db.Samochody, "Id_Samochodu", "Marka", radiowoz_policyjny.id_Samochodu);
            return View(radiowoz_policyjny);
        }

        // POST: Radiowoz_policyjny/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nr_Rejestracyjny,Rocznik,id_Samochodu,Ubezpieczenie,Przebieg,Przeglad")] Radiowoz_policyjny radiowoz_policyjny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radiowoz_policyjny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Samochodu = new SelectList(db.Samochody, "Id_Samochodu", "Marka", radiowoz_policyjny.id_Samochodu);
            return View(radiowoz_policyjny);
        }

        // GET: Radiowoz_policyjny/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiowoz_policyjny radiowoz_policyjny = db.Radiowowzy_policyjne.Find(id);
            if (radiowoz_policyjny == null)
            {
                return HttpNotFound();
            }
            return View(radiowoz_policyjny);
        }

        // POST: Radiowoz_policyjny/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Radiowoz_policyjny radiowoz_policyjny = db.Radiowowzy_policyjne.Find(id);
            db.Radiowowzy_policyjne.Remove(radiowoz_policyjny);
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
