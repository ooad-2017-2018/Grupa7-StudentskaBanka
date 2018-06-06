using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentskaBanka.Models;

namespace StudentskaBanka.Controllers
{
    public class TransakcijasController : Controller
    {
        private BankaContext db = new BankaContext();

        // GET: Transakcijas
        public ActionResult Index()
        {
            return View(db.Transakcija.ToList());
        }

        // GET: Transakcijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcija transakcija = db.Transakcija.Find(id);
            if (transakcija == null)
            {
                return HttpNotFound();
            }
            return View(transakcija);
        }

        // GET: Transakcijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transakcijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,posiljalacId,primalacId,vrijeme,iznos")] Transakcija transakcija)
        {
            if (ModelState.IsValid)
            {
                db.Transakcija.Add(transakcija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transakcija);
        }

        // GET: Transakcijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcija transakcija = db.Transakcija.Find(id);
            if (transakcija == null)
            {
                return HttpNotFound();
            }
            return View(transakcija);
        }

        // POST: Transakcijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,posiljalacId,primalacId,vrijeme,iznos")] Transakcija transakcija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transakcija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transakcija);
        }

        // GET: Transakcijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcija transakcija = db.Transakcija.Find(id);
            if (transakcija == null)
            {
                return HttpNotFound();
            }
            return View(transakcija);
        }

        // POST: Transakcijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transakcija transakcija = db.Transakcija.Find(id);
            db.Transakcija.Remove(transakcija);
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
