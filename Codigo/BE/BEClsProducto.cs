using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEClsProducto : Entidad
    {
        public string Artista { get; set; }
        public string Album { get; set; }
        public float Precio { get; set; }
        public int Lanzamiento { get; set; }
        public bool Estado { get; set; }
        public float Descuento { get; set; }

        //Relacion 1 a 1
        public BEClsGenero oGenero { get; set; }
    }    
}