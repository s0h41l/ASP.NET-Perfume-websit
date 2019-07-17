using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scentasy.Models.Models;
using Microsoft.AspNet.Identity;
using Scentasy.Models;
using Microsoft.AspNet.Identity;

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

                if (Request.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();
                    var result = (from a in db.Carts
                                  join b in db.Perfumes on a.ProductId equals b.Id
                                  where a.UserId == userId
                                  select new CartViewModel
                                  {
                                      Id=a.Id,
                                      ProductId = a.ProductId,
                                      ProductName = b.Name,
                                      Price = b.Price,
                                      Quantity = a.Quantity,
                                      Image=b.Image
                                  }).ToList<CartViewModel>();

                    ViewData["cart"] = result;


                }

                
                var latest = db.Perfumes.Take(5).ToList<Perfume>();
                List<ProductViewModel> products = new List<ProductViewModel>();
                foreach (var i in latest as List<Perfume>)
                {
                    ProductViewModel pr = new ProductViewModel()
                    {
                        
                        Id =i.Id,
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

                if (Request.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();
                    var result = (from a in db.Carts
                                  join b in db.Perfumes on a.ProductId equals b.Id
                                  where a.UserId == userId
                                  select new CartViewModel
                                  {
                                      Id = a.Id,
                                      ProductId = a.ProductId,
                                      ProductName = b.Name,
                                      Price = b.Price,
                                      Quantity = a.Quantity,
                                      Image = b.Image
                                  }).ToList<CartViewModel>();

                    ViewData["cart"] = result;


                }
                List<Perfume> per = db.Perfumes.Where(x => x.Id == id).ToList<Perfume>();
                ViewData["perfume"] = per;
                return View();
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
        }
           [HttpPost]
        public ActionResult AddToCart(CartViewModel collection)
        {

           

            try
            {
                DBEntities db = new DBEntities();

                if (Request.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();
                    var result = (from a in db.Carts
                                  join b in db.Perfumes on a.ProductId equals b.Id
                                  where a.UserId == userId
                                  select new CartViewModel
                                  {
                                      Id = a.Id,
                                      ProductId = a.ProductId,
                                      ProductName = b.Name,
                                      Price = b.Price,
                                      Quantity = a.Quantity,
                                      Image = b.Image
                                  }).ToList<CartViewModel>();

                    ViewData["cart"] = result;


                }

                Cart cart = new Cart()
                {
                    ProductId = collection.ProductId,
                    UserId = User.Identity.GetUserId(),
                    Quantity = collection.Quantity
                };
                db.Carts.Add(cart);
                db.SaveChanges();
                Alert.AddedToCart = true;
                return Redirect("~/Client/ViewPerfume/" + collection.ProductId);
            }
            catch(Exception exp)
            {
                return Content(exp.Message);
            }
        }

        public ActionResult DeleteCartItem(int? id)
        {
            try
            {
                DBEntities db = new DBEntities();

                if (Request.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();
                    var result = (from a in db.Carts
                                  join b in db.Perfumes on a.ProductId equals b.Id
                                  where a.UserId == userId
                                  select new CartViewModel
                                  {
                                      Id = a.Id,
                                      ProductId = a.ProductId,
                                      ProductName = b.Name,
                                      Price = b.Price,
                                      Quantity = a.Quantity,
                                      Image = b.Image
                                  }).ToList<CartViewModel>();

                    ViewData["cart"] = result;
                }
                var item = db.Carts.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                Alert.DeletedFromCart = true;
                return RedirectToAction("Index", "Client");
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
        }

        public ActionResult All()
        {

            try
            {
                DBEntities db = new DBEntities();
                var perfumes = db.Perfumes.ToList<Perfume>();
                if (Request.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();
                    var result = (from a in db.Carts
                                  join b in db.Perfumes on a.ProductId equals b.Id
                                  where a.UserId == userId
                                  select new CartViewModel
                                  {
                                      Id = a.Id,
                                      ProductId = a.ProductId,
                                      ProductName = b.Name,
                                      Price = b.Price,
                                      Quantity = a.Quantity,
                                      Image = b.Image
                                  }).ToList<CartViewModel>();

                    ViewData["cart"] = result;
                }

                var latest = db.Perfumes.Take(5).ToList<Perfume>();
                List<ProductViewModel> products = new List<ProductViewModel>();
                foreach (var i in latest as List<Perfume>)
                {
                    ProductViewModel pr = new ProductViewModel()
                    {

                        Id = i.Id,
                        Name = i.Name,
                        Price = i.Price,
                        Photo = i.Image
                    };
                    products.Add(pr);
                }

                ViewData["latest"] = products;

                ViewData["all"] = perfumes;
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }

            return View();
        }


        public ActionResult Men()
        {
            try
            {
                DBEntities db = new DBEntities();
                var perfumes = db.Perfumes.Where(x=>x.Type==1).ToList<Perfume>();
                if (Request.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();
                    var result = (from a in db.Carts
                                  join b in db.Perfumes on a.ProductId equals b.Id
                                  where a.UserId == userId
                                  select new CartViewModel
                                  {
                                      Id = a.Id,
                                      ProductId = a.ProductId,
                                      ProductName = b.Name,
                                      Price = b.Price,
                                      Quantity = a.Quantity,
                                      Image = b.Image
                                  }).ToList<CartViewModel>();

                    ViewData["cart"] = result;
                }

                var latest = db.Perfumes.Take(5).ToList<Perfume>();
                List<ProductViewModel> products = new List<ProductViewModel>();
                foreach (var i in latest as List<Perfume>)
                {
                    ProductViewModel pr = new ProductViewModel()
                    {

                        Id = i.Id,
                        Name = i.Name,
                        Price = i.Price,
                        Photo = i.Image
                    };
                    products.Add(pr);
                }

                ViewData["latest"] = products;

                ViewData["all"] = perfumes;
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }

            return View();
        }


        public ActionResult Women()
        {
            try
            {
                DBEntities db = new DBEntities();
                var perfumes = db.Perfumes.Where(x => x.Type == 2).ToList<Perfume>();
                if (Request.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();
                    var result = (from a in db.Carts
                                  join b in db.Perfumes on a.ProductId equals b.Id
                                  where a.UserId == userId
                                  select new CartViewModel
                                  {
                                      Id = a.Id,
                                      ProductId = a.ProductId,
                                      ProductName = b.Name,
                                      Price = b.Price,
                                      Quantity = a.Quantity,
                                      Image = b.Image
                                  }).ToList<CartViewModel>();

                    ViewData["cart"] = result;
                }

                var latest = db.Perfumes.Take(5).ToList<Perfume>();
                List<ProductViewModel> products = new List<ProductViewModel>();
                foreach (var i in latest as List<Perfume>)
                {
                    ProductViewModel pr = new ProductViewModel()
                    {

                        Id = i.Id,
                        Name = i.Name,
                        Price = i.Price,
                        Photo = i.Image
                    };
                    products.Add(pr);
                }

                ViewData["latest"] = products;

                ViewData["all"] = perfumes;
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }

            return View();
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
