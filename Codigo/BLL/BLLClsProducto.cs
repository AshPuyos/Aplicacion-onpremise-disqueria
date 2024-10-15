using System;
using System.Collections.Generic;
using BE;
using MPP;

namespace BLL
{
    public abstract class BLLClsProducto
    {
        public abstract float RealizarDescuento(BEClsProducto oBEProd);
    }
}
