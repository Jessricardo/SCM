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
        List<PedidoModel> pedidos = new List<PedidoModel>();
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