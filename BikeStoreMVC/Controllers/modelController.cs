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
    public class modelController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: model
        public ActionResult Index()
        {
            return View(db.tbl_model.ToList());
        }

        // GET: model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_model tbl_model = db.tbl_model.Find(id);
            if (tbl_model == null)
            {
                return HttpNotFound();
            }
            return View(tbl_model);
        }

        // GET: model/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "modID,model")] tbl_model tbl_model)
        {
            if (ModelState.IsValid)
            {
                db.tbl_model.Add(tbl_model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_model);
        }

        // GET: model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_model tbl_model = db.tbl_model.Find(id);
            if (tbl_model == null)
            {
                return HttpNotFound();
            }
            return View(tbl_model);
        }

        // POST: model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "modID,model")] tbl_model tbl_model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_model);
        }

        // GET: model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_model tbl_model = db.tbl_model.Find(id);
            if (tbl_model == null)
            {
                return HttpNotFound();
            }
            return View(tbl_model);
        }

        // POST: model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_model tbl_model = db.tbl_model.Find(id);
            db.tbl_model.Remove(tbl_model);
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
