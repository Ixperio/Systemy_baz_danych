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
    public class FunkcjonariuszsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Funkcjonariuszs
        public ActionResult Index()
        {
            var funkcjonariusze = db.Funkcjonariusze.Include(f => f.Obywatel).Include(f => f.Stopien);
           
            return View(funkcjonariusze.ToList());
        }

        // GET: Funkcjonariuszs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcjonariusz funkcjonariusz = db.Funkcjonariusze.Find(id);
            if (funkcjonariusz == null)
            {
                return HttpNotFound();
            }
            return View(funkcjonariusz);
        }

        // GET: Funkcjonariuszs/Create
        public ActionResult Create()
        {
            ViewBag.id_Stopnia = new SelectList(db.Stopien, "Id_Stopnia", "Nazwa");
            ViewBag.id_Obywatela = new SelectList(db.Obywatele, "Id", "Imie");
            return View();
        }

        // POST: Funkcjonariuszs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Funkcjonariusza,telefon,id_Obywatela,id_Stopnia,adres_Email,Wyksztalcenie")] Funkcjonariusz funkcjonariusz)
        {
            if (ModelState.IsValid)
            {
                db.Funkcjonariusze.Add(funkcjonariusz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Stopnia = new SelectList(db.Stopien, "Id_Stopnia", "Nazwa", funkcjonariusz.id_Stopnia);
            return View(funkcjonariusz);
        }

        // GET: Funkcjonariuszs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcjonariusz funkcjonariusz = db.Funkcjonariusze.Find(id);
            if (funkcjonariusz == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Obywatela = new SelectList(db.Obywatele, "Id", "Imie");
            ViewBag.id_Stopnia = new SelectList(db.Stopien, "Id_Stopnia", "Nazwa", funkcjonariusz.id_Stopnia);
            return View(funkcjonariusz);
        }

        // POST: Funkcjonariuszs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Funkcjonariusza,telefon,id_Obywatela,id_Stopnia,adres_Email,Wyksztalcenie")] Funkcjonariusz funkcjonariusz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funkcjonariusz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Stopnia = new SelectList(db.Stopien, "Id_Stopnia", "Nazwa", funkcjonariusz.id_Stopnia);
            return View(funkcjonariusz);
        }

        // GET: Funkcjonariuszs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcjonariusz funkcjonariusz = db.Funkcjonariusze.Find(id);
            if (funkcjonariusz == null)
            {
                return HttpNotFound();
            }
            return View(funkcjonariusz);
        }

        // POST: Funkcjonariuszs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funkcjonariusz funkcjonariusz = db.Funkcjonariusze.Find(id);
            db.Funkcjonariusze.Remove(funkcjonariusz);
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
