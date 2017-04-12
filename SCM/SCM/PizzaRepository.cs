using SCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM
{
    public interface IPizzaRepository
    {
        PizzaModel PizzaPorId(int id);
        List<PizzaModel> TodasLasPizzas();
        void CrearPizza(PizzaModel nuevaPizza);
        void ActualizarPizza(PizzaModel pizza);
        void BorrarPizza(PizzaModel thaPizza);
    }
    public class MemoryPizzaRepository : IPizzaRepository
    {
        private static List<PizzaModel> pizzas;

        static MemoryPizzaRepository()
        {
            pizzas = new List<PizzaModel>();
            var p = new PizzaModel()
            {
                Nombre = "Pepperoni Pizza",
                Id = 1,
                Calificacion = 5,
                Precio = 100,
                TiempoDePreparacion = 10
            };
            p.Ingredientes.Add("Pepperoni");
            p.Ingredientes.Add("Queso");
            pizzas.Add(p);
        }

        public void ActualizarPizza(PizzaModel pizza)
        {
            PizzaModel viejo = this.PizzaPorId(pizza.Id);
            pizzas.Remove(viejo);
            pizzas.Add(pizza);
        }

        public void BorrarPizza(PizzaModel thaPizza)
        {
            pizzas.Remove(thaPizza);
        }

        public void CrearPizza(PizzaModel nuevaPizza)
        {
            pizzas.Add(nuevaPizza);
        }

        public PizzaModel PizzaPorId(int id)
        {
            return pizzas.FirstOrDefault(p => p.Id == id);
        }

        public List<PizzaModel> TodasLasPizzas()
        {
            return pizzas.ToList();
        }
    }
    public class PizzaRepository
    {
    }
}