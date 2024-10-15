using System;
using System.Collections.Generic;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLClsVinilo : BLLClsProducto, IGestor<BEClsVinilo>
    {
        MPPVinilo _mppVinilo;

        public BLLClsVinilo()
        {
            _mppVinilo = new MPPVinilo();
        }

        public override float RealizarDescuento(BEClsProducto oBEProd)
        {
            return (float)(oBEProd.Precio * 0.90f); // 10% de descuento
        }

        public List<BEClsVinilo> ListarTodo()
        {
            var vinilos = _mppVinilo.ListarTodo();
            foreach (var vinilo in vinilos)
            {
                vinilo.Descuento = RealizarDescuento(vinilo);
            }
            return vinilos;
        }

        public bool Guardar(BEClsVinilo oBEClsVinilo)
        {
            oBEClsVinilo.Descuento = RealizarDescuento(oBEClsVinilo);
            return _mppVinilo.Guardar(oBEClsVinilo);
        }

        public bool Baja(BEClsVinilo oBEClsVinilo)
        {
            return _mppVinilo.Baja(oBEClsVinilo);
        }

        public BEClsVinilo ListarObjeto(BEClsVinilo oBEClsVinilo)
        {
            return _mppVinilo.ListarObjeto(oBEClsVinilo);
        }
    }
}