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
    public class sizeController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: size
        public ActionResult Index()
        {
            return View(db.tbl_size.OrderBy(x => x.size).ToList());
        }

        // GET: size/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_size tbl_size = db.tbl_size.Find(id);
            if (tbl_size == null)
            {
                return HttpNotFound();
            }
            return View(tbl_size);
        }

        // GET: size/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: size/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sizID,size")] tbl_size tbl_size)
        {
            if (ModelState.IsValid)
            {
                db.tbl_size.Add(tbl_size);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_size);
        }

        // GET: size/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_size tbl_size = db.tbl_size.Find(id);
            if (tbl_size == null)
            {
                return HttpNotFound();
            }
            return View(tbl_size);
        }

        // POST: size/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sizID,size")] tbl_size tbl_size)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_size).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_size);
        }

        // GET: size/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_size tbl_size = db.tbl_size.Find(id);
            if (tbl_size == null)
            {
                return HttpNotFound();
            }
            return View(tbl_size);
        }

        // POST: size/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_size tbl_size = db.tbl_size.Find(id);
            db.tbl_size.Remove(tbl_size);
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
