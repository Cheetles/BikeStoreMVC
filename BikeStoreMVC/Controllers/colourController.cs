using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeStoreMVC.Models;

namespace BikeStoreMVC.Controllers
{
    public class colourController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: colour
        public ActionResult Index()
        {
            return View(db.tbl_colour.OrderBy(x => x.colour).ToList());
        }

        // GET: colour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_colour tbl_colour = db.tbl_colour.Find(id);
            if (tbl_colour == null)
            {
                return HttpNotFound();
            }
            return View(tbl_colour);
        }

        // GET: colour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: colour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "colID,colour")] tbl_colour tbl_colour)
        {
            if (ModelState.IsValid)
            {
                db.tbl_colour.Add(tbl_colour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_colour);
        }

        // GET: colour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_colour tbl_colour = db.tbl_colour.Find(id);
            if (tbl_colour == null)
            {
                return HttpNotFound();
            }
            return View(tbl_colour);
        }

        // POST: colour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "colID,colour")] tbl_colour tbl_colour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_colour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_colour);
        }

        // GET: colour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_colour tbl_colour = db.tbl_colour.Find(id);
            if (tbl_colour == null)
            {
                return HttpNotFound();
            }
            return View(tbl_colour);
        }

        // POST: colour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_colour tbl_colour = db.tbl_colour.Find(id);
            db.tbl_colour.Remove(tbl_colour);
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
