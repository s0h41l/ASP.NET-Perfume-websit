using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scentasy.Models.Models;
using System.IO;

namespace Scentasy.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPerfume()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult AddPerfume(ProductViewModel collection)
        {
            try
            {
                DBEntities db = new DBEntities();
                string filename = Path.GetFileNameWithoutExtension(collection.Image.FileName);
                string ext = Path.GetExtension(collection.Image.FileName);
                filename = filename + DateTime.Now.Millisecond.ToString();
                filename = filename + ext;
                string filetodb = filename;
                filename = Path.Combine(Server.MapPath("~/image/product/"), filename);
                collection.Image.SaveAs(filename);
                collection.Photo = filetodb;
                Perfume per = new Perfume()
                {
                    Name = collection.Name,
                    Price = collection.Price,
                    Type = collection.TypeId,
                    Image = collection.Photo
                };
                db.Perfumes.Add(per);
                db.SaveChanges();
                Alert.PerfumeAdd = true;
                return RedirectToAction("ViewPerfumes", "Admin");
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
        }

        public ActionResult ViewPerfumes()
        {
            try
            {
                DBEntities db = new DBEntities();
                var perfume = db.Perfumes.ToList<Perfume>();
                List<ProductViewModel> perfumes = new List<ProductViewModel>();
                string type = "";
                foreach (Perfume i in perfume)
                {
                    if (i.Type == 1)
                    {
                        type = "Men";
                    }
                    if (i.Type == 2)
                    {
                        type = "Women";
                    }
                    if (i.Type == 3)
                    {
                        type = "Both";
                    }

                    ProductViewModel pr = new ProductViewModel()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Photo = i.Image,
                        Price = i.Price,
                        Type = type
                    };
                    perfumes.Add(pr);
                }

                ViewData["perfumes"] = perfumes;
                return View();

            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
            return Content("Error");
        }


        public ActionResult DeletePerfume(int? id)
        {
            try
            {
                DBEntities db = new DBEntities();
                var perfume = db.Perfumes.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(perfume).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                Alert.PerfumeDelete = true;
                return RedirectToAction("ViewPerfumes", "Admin");
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
            
        }










        public ActionResult AddScent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddScent(ProductViewModel collection)
        {
            try
            {
                DBEntities db = new DBEntities();
                string filename = Path.GetFileNameWithoutExtension(collection.Image.FileName);
                string ext = Path.GetExtension(collection.Image.FileName);
                filename = filename + DateTime.Now.Millisecond.ToString();
                filename = filename + ext;
                string filetodb = filename;
                filename = Path.Combine(Server.MapPath("~/image/product/"), filename);
                collection.Image.SaveAs(filename);
                collection.Photo = filetodb;
                Scent per = new Scent()
                {
                    Name = collection.Name,
                    Price = collection.Price,
                    Type = collection.TypeId,
                    Image = collection.Photo
                };
                db.Scents.Add(per);
                db.SaveChanges();
                Alert.ScentAdd = true;
                return RedirectToAction("ViewScents", "Admin");
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
        }

        public ActionResult ViewScents()
        {
            try
            {
                DBEntities db = new DBEntities();
                var scent = db.Scents.ToList<Scent>();
                List<ProductViewModel> scents = new List<ProductViewModel>();
                string type = "";
                
                foreach (Scent i in scent)
                {
                    if (i.Type==1)
                    {
                        type = "Men";
                    }
                    if (i.Type == 2)
                    {
                        type = "Women";
                    }
                    if (i.Type == 3)
                    {
                        type = "Both";
                    }
                    ProductViewModel pr = new ProductViewModel()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Photo = i.Image,
                        Price = i.Price,
                        Type = type
                    };
                    scents.Add(pr);
                }

                ViewData["scents"] = scents;
                return View();

            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
            return Content("Error");
        }


        public ActionResult DeleteScent(int? id)
        {
            try
            {
                DBEntities db = new DBEntities();
                var perfume = db.Scents.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(perfume).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                Alert.ScentDelete = true;
                return RedirectToAction("ViewScents", "Admin");
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }

        }

  


        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
