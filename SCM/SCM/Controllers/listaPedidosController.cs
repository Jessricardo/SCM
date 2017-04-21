using SCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCM.Controllers
{
    public class listaPedidosController : Controller
    {
        private MemoryPedidoRepository pedidos;
        public listaPedidosController()
        {
            pedidos = new MemoryPedidoRepository();
        }
        // GET: PedidosUI
        public ActionResult Index()
        {
            return View(pedidos.TodosLosPedidos());
        }

        // GET: PedidosUI/Details/5
        public ActionResult Details(int id)
        {
            PedidoModel nuevo = pedidos.PedidoPorId(id);
            if (nuevo.estado == "Pedido")
            {
                nuevo.estado = "Aprobado";
            }
            else if (nuevo.estado == "Aprobado")
            {
                nuevo.estado = "Cocinando";
            }
            else if (nuevo.estado == "Cocinando")
            {
                nuevo.estado = "Listo";
            }
            pedidos.ActualizarPedido(nuevo);
            return RedirectToAction("Index", "listaPedidos");
        }

        // GET: PedidosUI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidosUI/Create
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

        // GET: PedidosUI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidosUI/Edit/5
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

        // GET: PedidosUI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidosUI/Delete/5
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
