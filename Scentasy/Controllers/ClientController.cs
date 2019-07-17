using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scentasy.Models.Models;

namespace Scentasy.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            try
            {
                DBEntities db = new DBEntities();
                var latest = db.Perfumes.Take(5).ToList<Perfume>();
                List<ProductViewModel> products = new List<ProductViewModel>();
                foreach (var i in latest as List<Perfume>)
                {
                    ProductViewModel pr = new ProductViewModel()
                    {
                        Name = i.Name,
                        Price = i.Price,
                        Photo = i.Image
                    };
                    products.Add(pr);
                }

                ViewData["latest"] = products;
                return View();
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
        }



        public ActionResult ViewPerfume(int? id)
        {
            try
            {
                DBEntities db = new DBEntities();
                Perfume per = db.Perfumes.Where(x => x.Id == id).FirstOrDefault();
                ViewData["perfume"] = per;
                return View();
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
        }

        public ActionResult Products()
        {
            return View();
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }




        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
