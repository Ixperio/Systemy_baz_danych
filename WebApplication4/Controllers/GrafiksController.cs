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
    public class GrafiksController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Grafiks
        public ActionResult Index()
        {
            var grafik = db.Grafik.Include(g => g.Funkcjonariusz);
            return View(grafik.ToList());
        }

        // GET: Grafiks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grafik grafik = db.Grafik.Find(id);
            if (grafik == null)
            {
                return HttpNotFound();
            }
            return View(grafik);
        }

        // GET: Grafiks/Create
        public ActionResult Create()
        {
            ViewBag.Id_Zmiany = new SelectList(db.Zmiana, "Id", "Id_Zmiany");
            ViewBag.Id_Funkcjonariusza = new SelectList(db.Funkcjonariusze, "id_Funkcjonariusza", "adres_Email");
            return View();
        }

        // POST: Grafiks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Id_Funkcjonariusza,Godzina_Przyjscia,Godzina_Wyjscia,Id_Zmiany")] Grafik grafik)
        {
            if (ModelState.IsValid)
            {
                db.Grafik.Add(grafik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Funkcjonariusza = new SelectList(db.Funkcjonariusze, "id_Funkcjonariusza", "adres_Email", grafik.Id_Funkcjonariusza);
            return View(grafik);
        }

        // GET: Grafiks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grafik grafik = db.Grafik.Find(id);
            if (grafik == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Funkcjonariusza = new SelectList(db.Funkcjonariusze, "id_Funkcjonariusza", "adres_Email", grafik.Id_Funkcjonariusza);
            return View(grafik);
        }

        // POST: Grafiks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Id_Funkcjonariusza,Godzina_Przyjscia,Godzina_Wyjscia,Id_Zmiany")] Grafik grafik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grafik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Funkcjonariusza = new SelectList(db.Funkcjonariusze, "id_Funkcjonariusza", "adres_Email", grafik.Id_Funkcjonariusza);
            return View(grafik);
        }

        // GET: Grafiks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grafik grafik = db.Grafik.Find(id);
            if (grafik == null)
            {
                return HttpNotFound();
            }
            return View(grafik);
        }

        // POST: Grafiks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grafik grafik = db.Grafik.Find(id);
            db.Grafik.Remove(grafik);
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
