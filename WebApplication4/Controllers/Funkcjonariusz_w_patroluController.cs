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
    public class Funkcjonariusz_w_patroluController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Funkcjonariusz_w_patrolu
        public ActionResult Index()
        {
            var funkcjonariusze_W_Patrolu = db.Funkcjonariusze_W_Patrolu.Include(f => f.Funkcjonariusz).Include(f => f.Patrol);
            return View(funkcjonariusze_W_Patrolu.ToList());
        }

        // GET: Funkcjonariusz_w_patrolu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcjonariusz_w_patrolu funkcjonariusz_w_patrolu = db.Funkcjonariusze_W_Patrolu.Find(id);
            if (funkcjonariusz_w_patrolu == null)
            {
                return HttpNotFound();
            }
            return View(funkcjonariusz_w_patrolu);
        }

        // GET: Funkcjonariusz_w_patrolu/Create
        public ActionResult Create()
        {
            ViewBag.id_Funkcjonariusza = new SelectList(db.Funkcjonariusze, "id_Funkcjonariusza", "adres_Email");
            ViewBag.id_Patrolu = new SelectList(db.Patrol, "Id_Patrolu", "Radiowozy_Policyjne_Nr_Rejestracyjny");
            return View();
        }

        // POST: Funkcjonariusz_w_patrolu/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_Patrolu,id_Funkcjonariusza")] Funkcjonariusz_w_patrolu funkcjonariusz_w_patrolu)
        {
            if (ModelState.IsValid)
            {
                db.Funkcjonariusze_W_Patrolu.Add(funkcjonariusz_w_patrolu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Funkcjonariusza = new SelectList(db.Funkcjonariusze, "id_Funkcjonariusza", "adres_Email", funkcjonariusz_w_patrolu.id_Funkcjonariusza);
            ViewBag.id_Patrolu = new SelectList(db.Patrol, "Id_Patrolu", "Radiowozy_Policyjne_Nr_Rejestracyjny", funkcjonariusz_w_patrolu.id_Patrolu);
            return View(funkcjonariusz_w_patrolu);
        }

        // GET: Funkcjonariusz_w_patrolu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcjonariusz_w_patrolu funkcjonariusz_w_patrolu = db.Funkcjonariusze_W_Patrolu.Find(id);
            if (funkcjonariusz_w_patrolu == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Funkcjonariusza = new SelectList(db.Funkcjonariusze, "id_Funkcjonariusza", "adres_Email", funkcjonariusz_w_patrolu.id_Funkcjonariusza);
            ViewBag.id_Patrolu = new SelectList(db.Patrol, "Id_Patrolu", "Radiowozy_Policyjne_Nr_Rejestracyjny", funkcjonariusz_w_patrolu.id_Patrolu);
            return View(funkcjonariusz_w_patrolu);
        }

        // POST: Funkcjonariusz_w_patrolu/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_Patrolu,id_Funkcjonariusza")] Funkcjonariusz_w_patrolu funkcjonariusz_w_patrolu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funkcjonariusz_w_patrolu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Funkcjonariusza = new SelectList(db.Funkcjonariusze, "id_Funkcjonariusza", "adres_Email", funkcjonariusz_w_patrolu.id_Funkcjonariusza);
            ViewBag.id_Patrolu = new SelectList(db.Patrol, "Id_Patrolu", "Radiowozy_Policyjne_Nr_Rejestracyjny", funkcjonariusz_w_patrolu.id_Patrolu);
            return View(funkcjonariusz_w_patrolu);
        }

        // GET: Funkcjonariusz_w_patrolu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funkcjonariusz_w_patrolu funkcjonariusz_w_patrolu = db.Funkcjonariusze_W_Patrolu.Find(id);
            if (funkcjonariusz_w_patrolu == null)
            {
                return HttpNotFound();
            }
            return View(funkcjonariusz_w_patrolu);
        }

        // POST: Funkcjonariusz_w_patrolu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funkcjonariusz_w_patrolu funkcjonariusz_w_patrolu = db.Funkcjonariusze_W_Patrolu.Find(id);
            db.Funkcjonariusze_W_Patrolu.Remove(funkcjonariusz_w_patrolu);
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
