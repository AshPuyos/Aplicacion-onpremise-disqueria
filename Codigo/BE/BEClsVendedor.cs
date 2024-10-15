using System;
using System.Collections.Generic;

namespace BE
{
    public class BEClsVendedor : Entidad
    {
        #region Propiedades
        public string Nombre { get; set; }
        public List<BEClsProducto> ListaProductos { get; set; }
        #endregion

        #region Constructores
        public BEClsVendedor()
        {
            ListaProductos = new List<BEClsProducto>();
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            return $"{Codigo} {Nombre}";
        }
        #endregion
    }
}