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
    public class ZdarzeniesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Zdarzenies
        public ActionResult Index()
        {
             var zdarzenia = db.Zdarzenia.Include(f => f.Obywatel).Include(f=>f.Patrol).Include(f=>f.Charakter_Zdarzenia);
            
            return View(zdarzenia.ToList());
           
        }

        // GET: Zdarzenies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdarzenie zdarzenie = db.Zdarzenia.Find(id);
            if (zdarzenie == null)
            {
                return HttpNotFound();
            }
            return View(zdarzenie);
        }

        // GET: Zdarzenies/Create
        public ActionResult Create()
        {
            ViewBag.id_Patrolu = new SelectList(db.Patrol, "Id_Patrolu", "Id_Patrolu");
           ViewBag.Samochod_Id = new SelectList(db.Samochody_Zarejestrowane, "Id", "Nr_Rejestracyjny");
            ViewBag.id_Obywatela = new SelectList(db.Obywatele, "Id", "Imie");
            ViewBag.Id_Rodzaju = new SelectList(db.Charakter_Zdarzenia, "id", "Nazwa");
            return View();
        }

        // POST: Zdarzenies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Zdarzenia,Samochod_Id,Id_Obywatela,Data,Id_Patrolu,Id_Rodzaju")] Zdarzenie zdarzenie)
        {
            if (ModelState.IsValid)
            {
                db.Zdarzenia.Add(zdarzenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zdarzenie);
        }

        // GET: Zdarzenies/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.Id_Patrolu = new SelectList(db.Patrol, "Id_Patrolu", "Id_Patrolu");
            ViewBag.Samochod_Id = new SelectList(db.Samochody_Zarejestrowane, "Id", "Nr_Rejestracyjny");
            ViewBag.Id_Obywatela = new SelectList(db.Obywatele, "Id", "Imie");
            ViewBag.Id_Rodzaju = new SelectList(db.Charakter_Zdarzenia, "id", "Nazwa");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdarzenie zdarzenie = db.Zdarzenia.Find(id);
            if (zdarzenie == null)
            {
                return HttpNotFound();
            }
            return View(zdarzenie);
        }

        // POST: Zdarzenies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Zdarzenia,Samochod_Id,Id_Obywatela,Data,Id_Patrolu,Id_Rodzaju")] Zdarzenie zdarzenie)
        {
            ViewBag.Id_Patrolu = new SelectList(db.Patrol, "Id_Patrolu", "Id_Patrolu");
            ViewBag.Samochod_Id = new SelectList(db.Samochody_Zarejestrowane, "Id", "Nr_Rejestracyjny");
            ViewBag.Id_Obywatela = new SelectList(db.Obywatele, "Id", "Imie");
            ViewBag.Id_Rodzaju = new SelectList(db.Charakter_Zdarzenia, "id", "Nazwa");
            if (ModelState.IsValid)
            {
                db.Entry(zdarzenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zdarzenie);
        }

        // GET: Zdarzenies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdarzenie zdarzenie = db.Zdarzenia.Find(id);
            if (zdarzenie == null)
            {
                return HttpNotFound();
            }
            return View(zdarzenie);
        }

        // POST: Zdarzenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zdarzenie zdarzenie = db.Zdarzenia.Find(id);
            db.Zdarzenia.Remove(zdarzenie);
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
