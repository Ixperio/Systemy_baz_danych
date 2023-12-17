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
    public class StopiensController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Stopiens
        public ActionResult Index()
        {
            return View(db.Stopien.ToList());
        }

        // GET: Stopiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stopien stopien = db.Stopien.Find(id);
            if (stopien == null)
            {
                return HttpNotFound();
            }
            return View(stopien);
        }

        // GET: Stopiens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stopiens/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Stopnia,Nazwa,Zarobki")] Stopien stopien)
        {
            if (ModelState.IsValid)
            {
                db.Stopien.Add(stopien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stopien);
        }

        // GET: Stopiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stopien stopien = db.Stopien.Find(id);
            if (stopien == null)
            {
                return HttpNotFound();
            }
            return View(stopien);
        }

        // POST: Stopiens/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Stopnia,Nazwa,Zarobki")] Stopien stopien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stopien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stopien);
        }

        // GET: Stopiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stopien stopien = db.Stopien.Find(id);
            if (stopien == null)
            {
                return HttpNotFound();
            }
            return View(stopien);
        }

        // POST: Stopiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stopien stopien = db.Stopien.Find(id);
            db.Stopien.Remove(stopien);
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
