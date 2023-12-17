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
    public class ObywatelsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Obywatels
        public ActionResult Index()
        {
            return View(db.Obywatele.ToList());
        }

        // GET: Obywatels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obywatel obywatel = db.Obywatele.Find(id);
            if (obywatel == null)
            {
                return HttpNotFound();
            }
            return View(obywatel);
        }

        // GET: Obywatels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Obywatels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pesel,Imie,Nazwisko,DataUrodzenia,Ulica,Nr_Budynku,Miasto")] Obywatel obywatel)
        {
            if (ModelState.IsValid)
            {
                db.Obywatele.Add(obywatel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obywatel);
        }

        // GET: Obywatels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obywatel obywatel = db.Obywatele.Find(id);
            if (obywatel == null)
            {
                return HttpNotFound();
            }
            ViewData["PoprzedniaDataUrodzenia"] = obywatel.DataUrodzenia;
            return View(obywatel);
        }

        // POST: Obywatels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pesel,Imie,Nazwisko,DataUrodzenia,Ulica,Nr_Budynku,Miasto")] Obywatel obywatel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obywatel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obywatel);
        }

        // GET: Obywatels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obywatel obywatel = db.Obywatele.Find(id);
            if (obywatel == null)
            {
                return HttpNotFound();
            }
            return View(obywatel);
        }

        // POST: Obywatels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obywatel obywatel = db.Obywatele.Find(id);
            db.Obywatele.Remove(obywatel);
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
