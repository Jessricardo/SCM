using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Models
{
    public class PizzaModel
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public List<string> Ingredientes { get; set; } = new List<string>();
        public int Calificacion { get; set; }
        public int TiempoDePreparacion { get; set; }
        public Decimal Precio { get; set; }

    }
}