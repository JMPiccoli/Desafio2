using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    public class ProductoVendido
    {
        //Atributos
        private int id;
        private int idProducto;
        private double stock;
        private int idVenta;

        //Propiedades
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public double Stock { get; set; }
        public int IdVenta { get; set; }
    }
}
