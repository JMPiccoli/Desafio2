using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    public class Venta
    {
        //Atributos
        private int id;
        private string comentarios;
        private int idUsuario;

        //Propiedades
        public int Id { get; set; }
        public string Comentarios { get; set; } 
        public int IdUsuario { get; set; }  
    }
}
