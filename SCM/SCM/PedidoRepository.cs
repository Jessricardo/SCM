using SCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM
{
    public interface IPedidoRepository
    {
        PedidoModel PedidoPorId(int id);
        List<PedidoModel> TodosLosPedidos();
        void CrearPedido(PedidoModel pedidox);
        void ActualizarPedido(PedidoModel pedidox);
        void BorrarPedido(PedidoModel pedidox);
    }
    public class MemoryPedidoRepository : IPedidoRepository
    {
        private static List<PedidoModel> pedidos;
        static MemoryPedidoRepository()
        {
            pedidos = new List<PedidoModel>();
            var p = new PedidoModel()
            {
                id = 1,
                nombre = "Mengano",
                estado = "Pedido",
                fecha = "Hoy",
                hora = "10am",
                latitud = 40.777,
                longitud = 20.111,
                nombrerepartidor = "Julion alvarez",
                pizza = 1,
                telefono = 6688323243
            };
            pedidos.Add(p);
        }
        public void ActualizarPedido(PedidoModel pedidox)
        {
            PedidoModel viejo = this.PedidoPorId(pedidox.id);
            pedidos.Remove(viejo);
            pedidos.Add(pedidox);
        }

        public void BorrarPedido(PedidoModel pedidox)
        {
            pedidos.Remove(pedidox);
        }

        public void CrearPedido(PedidoModel pedidox)
        {
            pedidos.Add(pedidox);
        }

        public PedidoModel PedidoPorId(int id)
        {
            return pedidos.FirstOrDefault(p => p.id == id);
        }

        public List<PedidoModel> TodosLosPedidos()
        {
            return pedidos.ToList();
        }
    }
}