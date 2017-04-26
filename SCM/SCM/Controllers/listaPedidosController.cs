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
        public ActionResult Create(PedidoModel pedido)
        {
            try
            {
                // TODO: Add insert logic here
                pedidos.CrearPedido(pedido);
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
            return View(pedidos.PedidoPorId(id));
        }

        // POST: PedidosUI/Edit/5
        [HttpPost]
        public ActionResult Edit(PedidoModel pedido)
        {
            try
            {
                // TODO: Add update logic here
                pedidos.ActualizarPedido(pedido);
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
            return View(pedidos.PedidoPorId(id));
        }

        // POST: PedidosUI/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection notused, int id)
        {
            try
            {
                // TODO: Add delete logic here
                pedidos.BorrarPedido(pedidos.PedidoPorId(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
