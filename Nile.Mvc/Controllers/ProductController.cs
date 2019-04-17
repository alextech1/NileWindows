using ProductsData;
using ClassProject2.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassProject2.Mvc.Extensions;

namespace ClassProject2.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public ProductController() : this(new Database("Database"))
        {
        }

        public ProductController(Database database)
        {
            _database = database;
        }

        // GET: Product
        public ActionResult Index()
        {
            var items = _database.Products.GetAll();

            return View(items.ToModel());
        }

        //GET
        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _database.Products.Add(model.ToBusiness());

                    return RedirectToAction("Index");
                };
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _database.Products.Get(id);
            if (item == null)
                return HttpNotFound();

            return View(new ProductModel(item));
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _database.Products.Update(model.ToBusiness());

                    return RedirectToAction("Index");
                };
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _database.Dispose();
            };
        }

        private readonly Database _database;
    }
}