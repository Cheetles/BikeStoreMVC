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
    public class productController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: product
        public ActionResult Index()
        {
            var tbl_product = db.tbl_product.Include(t => t.tbl_category).Include(t => t.tbl_colour).Include(t => t.tbl_description).Include(t => t.tbl_model).Include(t => t.tbl_size).Include(t => t.tbl_sub_category);
            return View(tbl_product.ToList());
        }

        // GET: product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_product);
        }

        // GET: product/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.tbl_category, "catID", "category");
            ViewBag.colourID = new SelectList(db.tbl_colour, "colID", "colour");
            ViewBag.descriptionID = new SelectList(db.tbl_description, "desID", "description");
            ViewBag.modelID = new SelectList(db.tbl_model, "modID", "model");
            ViewBag.sizeID = new SelectList(db.tbl_size, "sizID", "size");
            ViewBag.subCategoryID = new SelectList(db.tbl_sub_category, "subID", "subcategory");
            return View();
        }

        // POST: product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proID,productCode,productName,categoryID,subCategoryID,modelID,price,colourID,sizeID,descriptionID")] tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.tbl_product.Add(tbl_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.tbl_category, "catID", "category", tbl_product.categoryID);
            ViewBag.colourID = new SelectList(db.tbl_colour, "colID", "colour", tbl_product.colourID);
            ViewBag.descriptionID = new SelectList(db.tbl_description, "desID", "description", tbl_product.descriptionID);
            ViewBag.modelID = new SelectList(db.tbl_model, "modID", "model", tbl_product.modelID);
            ViewBag.sizeID = new SelectList(db.tbl_size, "sizID", "size", tbl_product.sizeID);
            ViewBag.subCategoryID = new SelectList(db.tbl_sub_category, "subID", "subcategory", tbl_product.subCategoryID);
            return View(tbl_product);
        }

        // GET: product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.tbl_category, "catID", "category", tbl_product.categoryID);
            ViewBag.colourID = new SelectList(db.tbl_colour, "colID", "colour", tbl_product.colourID);
            ViewBag.descriptionID = new SelectList(db.tbl_description, "desID", "description", tbl_product.descriptionID);
            ViewBag.modelID = new SelectList(db.tbl_model, "modID", "model", tbl_product.modelID);
            ViewBag.sizeID = new SelectList(db.tbl_size, "sizID", "size", tbl_product.sizeID);
            ViewBag.subCategoryID = new SelectList(db.tbl_sub_category, "subID", "subcategory", tbl_product.subCategoryID);
            return View(tbl_product);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proID,productCode,productName,categoryID,subCategoryID,modelID,price,colourID,sizeID,descriptionID")] tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.tbl_category, "catID", "category", tbl_product.categoryID);
            ViewBag.colourID = new SelectList(db.tbl_colour, "colID", "colour", tbl_product.colourID);
            ViewBag.descriptionID = new SelectList(db.tbl_description, "desID", "description", tbl_product.descriptionID);
            ViewBag.modelID = new SelectList(db.tbl_model, "modID", "model", tbl_product.modelID);
            ViewBag.sizeID = new SelectList(db.tbl_size, "sizID", "size", tbl_product.sizeID);
            ViewBag.subCategoryID = new SelectList(db.tbl_sub_category, "subID", "subcategory", tbl_product.subCategoryID);
            return View(tbl_product);
        }

        // GET: product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = db.tbl_product.Find(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_product);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_product tbl_product = db.tbl_product.Find(id);
            db.tbl_product.Remove(tbl_product);
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
