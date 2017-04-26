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
            return View(pizzas.PizzaPorId(id));
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
            return View(pizzas.PizzaPorId(id));
        }

        // POST: Pizzas/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaModel pizza)
        {
            try
            {
                // TODO: Add update logic here
                pizzas.ActualizarPizza(pizza);
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
            return View(pizzas.PizzaPorId(id));
        }

        // POST: Pizzas/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection notused, int id)
        {
            try
            {
                // TODO: Add delete logic here
                pizzas.BorrarPizza(pizzas.PizzaPorId(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
