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
    public class ZmianasController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Zmianas
        public ActionResult Index()
        {
            return View(db.Zmiana.ToList());
        }

        // GET: Zmianas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zmiana zmiana = db.Zmiana.Find(id);
            if (zmiana == null)
            {
                return HttpNotFound();
            }
            return View(zmiana);
        }

        // GET: Zmianas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zmianas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Zmiany,Godzina_Rozpoczecia,Godzina_Zakonczenia")] Zmiana zmiana)
        {
            if (ModelState.IsValid)
            {
                db.Zmiana.Add(zmiana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zmiana);
        }

        // GET: Zmianas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zmiana zmiana = db.Zmiana.Find(id);
            if (zmiana == null)
            {
                return HttpNotFound();
            }
            return View(zmiana);
        }

        // POST: Zmianas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Zmiany,Godzina_Rozpoczecia,Godzina_Zakonczenia")] Zmiana zmiana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zmiana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zmiana);
        }

        // GET: Zmianas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zmiana zmiana = db.Zmiana.Find(id);
            if (zmiana == null)
            {
                return HttpNotFound();
            }
            return View(zmiana);
        }

        // POST: Zmianas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zmiana zmiana = db.Zmiana.Find(id);
            db.Zmiana.Remove(zmiana);
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
