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
    public class sub_categoryController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: sub_category
        public ActionResult Index()
        {
            var tbl_sub_category = db.tbl_sub_category.Include(t => t.tbl_category).OrderBy(x => x.subcategory);
            return View(tbl_sub_category.ToList());
        }

        // GET: sub_category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_sub_category tbl_sub_category = db.tbl_sub_category.Find(id);
            if (tbl_sub_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_sub_category);
        }

        // GET: sub_category/Create
        public ActionResult Create()
        {
            ViewBag.catID = new SelectList(db.tbl_category, "catID", "category");
            return View();
        }

        // POST: sub_category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subID,catID,subcategory")] tbl_sub_category tbl_sub_category)
        {
            if (ModelState.IsValid)
            {
                db.tbl_sub_category.Add(tbl_sub_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catID = new SelectList(db.tbl_category, "catID", "category", tbl_sub_category.catID);
            return View(tbl_sub_category);
        }

        // GET: sub_category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_sub_category tbl_sub_category = db.tbl_sub_category.Find(id);
            if (tbl_sub_category == null)
            {
                return HttpNotFound();
            }
            ViewBag.catID = new SelectList(db.tbl_category, "catID", "category", tbl_sub_category.catID);
            return View(tbl_sub_category);
        }

        // POST: sub_category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subID,catID,subcategory")] tbl_sub_category tbl_sub_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_sub_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catID = new SelectList(db.tbl_category, "catID", "category", tbl_sub_category.catID);
            return View(tbl_sub_category);
        }

        // GET: sub_category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_sub_category tbl_sub_category = db.tbl_sub_category.Find(id);
            if (tbl_sub_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_sub_category);
        }

        // POST: sub_category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_sub_category tbl_sub_category = db.tbl_sub_category.Find(id);
            db.tbl_sub_category.Remove(tbl_sub_category);
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
