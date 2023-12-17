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
    public class Samochod_ZarejestrowanyController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Samochod_Zarejestrowany
        public ActionResult Index()
        {
            var samochody_Zarejestrowane = db.Samochody_Zarejestrowane.Include(s => s.Samochod).Include(s=>s.Obywatel);
            return View(samochody_Zarejestrowane.ToList());
        }

        // GET: Samochod_Zarejestrowany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod_Zarejestrowany samochod_Zarejestrowany = db.Samochody_Zarejestrowane.Find(id);
            if (samochod_Zarejestrowany == null)
            {
                return HttpNotFound();
            }
            return View(samochod_Zarejestrowany);
        }

        // GET: Samochod_Zarejestrowany/Create
        public ActionResult Create()
        {
            ViewBag.Id_Samochodu = new SelectList(db.Samochody, "Id_Samochodu", "Marka");
            ViewBag.id_Obywatela = new SelectList(db.Obywatele, "Id", "Imie");
            return View();
        }

        // POST: Samochod_Zarejestrowany/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nr_Rejestracyjny,Przebieg,Id_Obywatela,Id_Samochodu,Rocznik,Ubezpieczenie")] Samochod_Zarejestrowany samochod_Zarejestrowany)
        {
            if (ModelState.IsValid)
            {
                db.Samochody_Zarejestrowane.Add(samochod_Zarejestrowany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Obywatela = new SelectList(db.Obywatele, "Id", "Imie");
            ViewBag.Id_Samochodu = new SelectList(db.Samochody, "Id_Samochodu", "Marka", samochod_Zarejestrowany.Id_Samochodu);
            return View(samochod_Zarejestrowany);
        }

        // GET: Samochod_Zarejestrowany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod_Zarejestrowany samochod_Zarejestrowany = db.Samochody_Zarejestrowane.Find(id);
            if (samochod_Zarejestrowany == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Samochodu = new SelectList(db.Samochody, "Id_Samochodu", "Marka", samochod_Zarejestrowany.Id_Samochodu);
            ViewBag.id_Obywatela = new SelectList(db.Obywatele, "Id", "Imie", "Nazwisko");
            return View(samochod_Zarejestrowany);
        }

        // POST: Samochod_Zarejestrowany/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nr_Rejestracyjny,Przebieg,Pesel,Id_Samochodu,Rocznik,Ubezpieczenie")] Samochod_Zarejestrowany samochod_Zarejestrowany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samochod_Zarejestrowany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Samochodu = new SelectList(db.Samochody, "Id_Samochodu", "Marka", samochod_Zarejestrowany.Id_Samochodu);
            return View(samochod_Zarejestrowany);
        }

        // GET: Samochod_Zarejestrowany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod_Zarejestrowany samochod_Zarejestrowany = db.Samochody_Zarejestrowane.Find(id);
            if (samochod_Zarejestrowany == null)
            {
                return HttpNotFound();
            }
            return View(samochod_Zarejestrowany);
        }

        // POST: Samochod_Zarejestrowany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samochod_Zarejestrowany samochod_Zarejestrowany = db.Samochody_Zarejestrowane.Find(id);
            db.Samochody_Zarejestrowane.Remove(samochod_Zarejestrowany);
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
