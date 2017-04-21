using Newtonsoft.Json;
using SCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace SCM.Controllers
{
    public class PedidosController : ApiController
    {
        
        private MemoryPizzaRepository pizzas;
        private MemoryPedidoRepository pedidos;
        public PedidosController()
        {
            pedidos = new MemoryPedidoRepository();
            pizzas = new MemoryPizzaRepository();
        }
        // GET api/pedidos
        public IEnumerable<PedidoModel> Get()
        {
            return pedidos.TodosLosPedidos();
        }
        [HttpGet]
        [Route("api/allpizzas")]
        public IEnumerable<PizzaModel> Pizzas()
        {
            return pizzas.TodasLasPizzas();
        }

        // GET api/pedidos/5
        public PedidoModel Get(int id)
        {
            return pedidos.PedidoPorId(id) ;
        }

        // POST api/pedidos
        public void Post([FromBody]PedidoModel value)
        {
            value.fecha = DateTime.Today.ToString("dd/MM/yyyy");
            value.hora = DateTime.Now.ToShortTimeString();
            pedidos.CrearPedido(value);
        }

        // PUT api/pedidos/5
        public void Put(int id, [FromBody]string value)
        {
            PedidoModel nuevo = JsonConvert.DeserializeObject<PedidoModel>(value);
            pedidos.ActualizarPedido(nuevo);
        }

        // DELETE api/pedidos/5
        public void Delete(int id)
        {
            pedidos.BorrarPedido(pedidos.PedidoPorId(id));
        }
    }
}
