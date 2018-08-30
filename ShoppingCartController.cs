using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterViewCartV1.Models;

namespace InterViewCartV1.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Cart()
        {
            return View((List<Product>)Session["cartV1"]);
        }

        public ActionResult AddToCart(Product product)
        {
            try
            {
                if (Session["cartV1"] == null)
                {
                    List<Product> products = new List<Product>();
                    products.Add(product);
                    Session["cartV1"] = products;
                    //ViewBag.count = products.Count;
                    Session["count"] = 1;
                }
                else
                {
                    List<Product> products = (List<Product>) Session["cartV1"];
                    products.Add(product);
                    Session["cartV1"] = products;
                    //ViewBag.count = products.Count;
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
            }
            catch (Exception e)
            {
                    
                throw e;
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
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

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingCart/Edit/5
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

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                List<Product> list = (List<Product>) Session["cartV1"];
                list.RemoveAll(x => x.MobileId == product.MobileId);
                Session["cartV1"] = list;
                Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
