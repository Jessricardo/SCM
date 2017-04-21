using SCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCM.Controllers
{
    public class PizzasController : Controller
    {
        private MemoryPizzaRepository pizzas;

        public PizzasController(){
            pizzas = new MemoryPizzaRepository();
        }
        // GET: Pizzas
        public ActionResult Index(bool? isjson)
        {
            var model = pizzas.TodasLasPizzas();
            if(isjson.HasValue && isjson.Value)
            {
                var json = new JsonResult();
                json.Data = model;
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return json;
            }
            return View(model);
        }

        // GET: Pizzas/Details/5
        public ActionResult Details(int id)
        {
            var p = pizzas.PizzaPorId(id);
            return View(p);
        }

        // GET: Pizzas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        [HttpPost]
        public ActionResult Create(PizzaModel pizza)
        {
            try
            {
                pizzas.CrearPizza(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizzas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizzas/Edit/5
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

        // GET: Pizzas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizzas/Delete/5
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
