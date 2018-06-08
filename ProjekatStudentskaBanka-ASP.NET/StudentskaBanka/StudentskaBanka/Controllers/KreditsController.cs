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
    public class KreditsController : Controller
    {
        private BankaContext db = new BankaContext();

        // GET: Kredits
        public ActionResult Index()
        {
            return View(db.Kredit.ToList());
        }

        // GET: Kredits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kredit kredit = db.Kredit.Find(id);
            if (kredit == null)
            {
                return HttpNotFound();
            }
            return View(kredit);
        }

        // GET: Kredits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kredits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ukupnoUzeto,ukupnoZaVratiti,kamata,racunId")] Kredit kredit)
        {
            if (ModelState.IsValid)
            {
                db.Kredit.Add(kredit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kredit);
        }

        // GET: Kredits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kredit kredit = db.Kredit.Find(id);
            if (kredit == null)
            {
                return HttpNotFound();
            }
            return View(kredit);
        }

        // POST: Kredits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ukupnoUzeto,ukupnoZaVratiti,kamata,racunId")] Kredit kredit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kredit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kredit);
        }

        // GET: Kredits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kredit kredit = db.Kredit.Find(id);
            if (kredit == null)
            {
                return HttpNotFound();
            }
            return View(kredit);
        }

        // POST: Kredits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kredit kredit = db.Kredit.Find(id);
            db.Kredit.Remove(kredit);
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
