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
    public class PatrolsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Patrols
        public ActionResult Index()
        {
            return View(db.Patrol.ToList());
        }

        // GET: Patrols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrol patrol = db.Patrol.Find(id);
            if (patrol == null)
            {
                return HttpNotFound();
            }
            return View(patrol);
        }

        // GET: Patrols/Create
        public ActionResult Create()
        {
            ViewBag.id_Radiowozu = new SelectList(db.Radiowowzy_policyjne,"Id","Nr_Rejestracyjny");
            return View();
        }

        // POST: Patrols/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Patrolu,Data,Radiowozy_Policyjne_Nr_Rejestracyjny")] Patrol patrol)
        {
            if (ModelState.IsValid)
            {
                db.Patrol.Add(patrol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patrol);
        }

        // GET: Patrols/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.id_Radiowozu = new SelectList(db.Radiowowzy_policyjne, "Id", "Nr_Rejestracyjny");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrol patrol = db.Patrol.Find(id);
            if (patrol == null)
            {
                return HttpNotFound();
            }
            return View(patrol);
        }

        // POST: Patrols/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Patrolu,Data,Radiowozy_Policyjne_Nr_Rejestracyjny")] Patrol patrol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patrol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patrol);
        }

        // GET: Patrols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patrol patrol = db.Patrol.Find(id);
            if (patrol == null)
            {
                return HttpNotFound();
            }
            return View(patrol);
        }

        // POST: Patrols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patrol patrol = db.Patrol.Find(id);
            db.Patrol.Remove(patrol);
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
