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
    public class descriptionController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: description
        public ActionResult Index()
        {
            return View(db.tbl_description.ToList());
        }

        // GET: description/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_description tbl_description = db.tbl_description.Find(id);
            if (tbl_description == null)
            {
                return HttpNotFound();
            }
            return View(tbl_description);
        }

        // GET: description/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: description/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "desID,description")] tbl_description tbl_description)
        {
            if (ModelState.IsValid)
            {
                db.tbl_description.Add(tbl_description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_description);
        }

        // GET: description/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_description tbl_description = db.tbl_description.Find(id);
            if (tbl_description == null)
            {
                return HttpNotFound();
            }
            return View(tbl_description);
        }

        // POST: description/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "desID,description")] tbl_description tbl_description)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_description).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_description);
        }

        // GET: description/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_description tbl_description = db.tbl_description.Find(id);
            if (tbl_description == null)
            {
                return HttpNotFound();
            }
            return View(tbl_description);
        }

        // POST: description/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_description tbl_description = db.tbl_description.Find(id);
            db.tbl_description.Remove(tbl_description);
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
