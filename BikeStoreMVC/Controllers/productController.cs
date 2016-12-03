using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeStoreMVC.Models;
using PagedList;

namespace BikeStoreMVC.Controllers
{
    public class productController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: product
        /*
        public ActionResult Index()
        {
            var tbl_product = db.tbl_product.Include(t => t.tbl_category).Include(t => t.tbl_colour).Include(t => t.tbl_description).Include(t => t.tbl_model).Include(t => t.tbl_size).Include(t => t.tbl_sub_category);
            return View(tbl_product.ToList());
        }
        */

            

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ModelSortParam = string.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            ViewBag.CategorySortParam = string.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewBag.SubCategorySortParam = string.IsNullOrEmpty(sortOrder) ? "subcategory_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            

            ViewBag.CurrentFilter = searchString;
            var tbl_product = db.tbl_product.Include(t => t.tbl_category).Include(t => t.tbl_colour).Include(t => t.tbl_model).Include(t => t.tbl_size).Include(t => t.tbl_sub_category);

            if (!String.IsNullOrEmpty(searchString))
            {
                tbl_product = tbl_product.Where(s => s.productName.Contains(searchString) || s.productCode.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "model_desc":
                    tbl_product = tbl_product.OrderByDescending(s => s.tbl_model.model);
                    break;
                case "category_desc":
                    tbl_product = tbl_product.OrderByDescending(s => s.tbl_category.category);
                    break;
                case "subcategory_desc":
                    tbl_product = tbl_product.OrderByDescending(s => s.tbl_sub_category.subcategory);
                    break;
                default:
                    tbl_product = tbl_product.OrderBy(s => s.tbl_model.model);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            //return View(tbl_product.ToList());
            return View(tbl_product.ToPagedList(pageNumber, pageSize));
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
            var category = db.tbl_category.ToList();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "[Select a category]", Value = "0" });
            foreach (var c in category)
            {
                li.Add(new SelectListItem { Text = c.category, Value = c.catID.ToString() });
                ViewBag.category = li;
            }

            //ViewBag.categoryID = new SelectList(db.tbl_category, "catID", "category");
            //ViewBag.subCategoryID = new SelectList(db.tbl_sub_category, "subID", "subCategory");
            ViewBag.colourID = new SelectList(db.tbl_colour, "colID", "colour");
            //ViewBag.modelID = new SelectList(db.tbl_model, "modID", "model");
            ViewBag.sizeID = new SelectList(db.tbl_size, "sizID", "size");
           
            return View();
        }

        public JsonResult getSubCategory(int id)
        {
            var subcats = db.tbl_sub_category.Where(x => x.catID == id).ToList();
            List<SelectListItem> lstSubCats = new List<SelectListItem>();
            lstSubCats.Add(new SelectListItem { Text = "[Select Sub Category]", Value = "0" });
            if (subcats != null)
            {
                foreach (var c in subcats)
                {
                    lstSubCats.Add(new SelectListItem { Text = c.subcategory, Value = c.subID.ToString() });
                }
            }
            return Json(new SelectList(lstSubCats, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        public JsonResult getModel(int id)
        {
            var models = db.tbl_model.Where(x => x.subID == id).ToList();
            List<SelectListItem> lstModels = new List<SelectListItem>();
            lstModels.Add(new SelectListItem { Text = "[Select Model]", Value = "0" });
            if (models != null)
            {
                foreach (var c in models)
                {
                    lstModels.Add(new SelectListItem { Text = c.model, Value = c.modID.ToString() });
                }
            }
            return Json(new SelectList(lstModels, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        // POST: product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "proID,productCode,productName,categoryID,subCategoryID,modelID,price,colourID,sizeID,description")] tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.tbl_product.Add(tbl_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.tbl_category, "catID", "category", tbl_product.categoryID);
            ViewBag.colourID = new SelectList(db.tbl_colour, "colID", "colour", tbl_product.colourID);
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
            var category = db.tbl_category.ToList();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "[Select a category]", Value = "0" });
            foreach (var c in category)
            {
                li.Add(new SelectListItem { Text = c.category, Value = c.catID.ToString() });
                ViewBag.category = li;
            }
            //ViewBag.categoryID = new SelectList(db.tbl_category, "catID", "category", tbl_product.categoryID);
            ViewBag.colourID = new SelectList(db.tbl_colour, "colID", "colour", tbl_product.colourID);
            //ViewBag.modelID = new SelectList(db.tbl_model, "modID", "model", tbl_product.modelID);
            ViewBag.sizeID = new SelectList(db.tbl_size, "sizID", "size", tbl_product.sizeID);
            //ViewBag.subCategoryID = new SelectList(db.tbl_sub_category, "subID", "subcategory", tbl_product.subCategoryID);
            return View(tbl_product);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "proID,productCode,productName,categoryID,subCategoryID,modelID,price,colourID,sizeID,description")] tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.tbl_category, "catID", "category", tbl_product.categoryID);
            ViewBag.colourID = new SelectList(db.tbl_colour, "colID", "colour", tbl_product.colourID);
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
