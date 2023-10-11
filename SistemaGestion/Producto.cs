using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    public class Producto
    {
        //Atributos
        private int id;
        private string descripcion;
        private double costo;
        private double precioVenta;
        private double stock;
        private int idUsuario;

        //Propiedades
        public int Id { get; set; } 
        public string Descripcion { get; set; } 
        public double Costo { get; set; } 
        public double PrecioVenta { get; set; }
        public double Stock { get; set; }
        public int IdUsuario { get; set;}
    }
}
