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
    public class Charakter_zdarzeniaController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Charakter_zdarzenia
        public ActionResult Index()
        {
            return View(db.Charakter_Zdarzenia.ToList());
        }

        // GET: Charakter_zdarzenia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charakter_zdarzenia charakter_zdarzenia = db.Charakter_Zdarzenia.Find(id);
            if (charakter_zdarzenia == null)
            {
                return HttpNotFound();
            }
            return View(charakter_zdarzenia);
        }

        // GET: Charakter_zdarzenia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Charakter_zdarzenia/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Id_Rodzaju,Nazwa")] Charakter_zdarzenia charakter_zdarzenia)
        {
            if (ModelState.IsValid)
            {
                db.Charakter_Zdarzenia.Add(charakter_zdarzenia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(charakter_zdarzenia);
        }

        // GET: Charakter_zdarzenia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charakter_zdarzenia charakter_zdarzenia = db.Charakter_Zdarzenia.Find(id);
            if (charakter_zdarzenia == null)
            {
                return HttpNotFound();
            }
            return View(charakter_zdarzenia);
        }

        // POST: Charakter_zdarzenia/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Id_Rodzaju,Nazwa")] Charakter_zdarzenia charakter_zdarzenia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charakter_zdarzenia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(charakter_zdarzenia);
        }

        // GET: Charakter_zdarzenia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charakter_zdarzenia charakter_zdarzenia = db.Charakter_Zdarzenia.Find(id);
            if (charakter_zdarzenia == null)
            {
                return HttpNotFound();
            }
            return View(charakter_zdarzenia);
        }

        // POST: Charakter_zdarzenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Charakter_zdarzenia charakter_zdarzenia = db.Charakter_Zdarzenia.Find(id);
            db.Charakter_Zdarzenia.Remove(charakter_zdarzenia);
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
