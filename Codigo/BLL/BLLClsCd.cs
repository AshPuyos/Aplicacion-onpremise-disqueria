using System;
using System.Collections.Generic;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLClsCd : IGestor<BEClsCd>
    {
        private MPPCd oMPPCd = new MPPCd();

        public List<BEClsCd> ListarTodo()
        {
            var cds = oMPPCd.ListarTodo();
            foreach (var cd in cds)
            {
                cd.Descuento = RealizarDescuento(cd);
            }
            return cds;
        }

        public bool Guardar(BEClsCd oBEClsCd)
        {
            oBEClsCd.Descuento = RealizarDescuento(oBEClsCd);
            return oMPPCd.Guardar(oBEClsCd);
        }

        public bool Baja(BEClsCd oBEClsCd)
        {
            return oMPPCd.Baja(oBEClsCd);
        }

        public BEClsCd ListarObjeto(BEClsCd oBEClsCd)
        {
            return oMPPCd.ListarObjeto(oBEClsCd);
        }

        public float RealizarDescuento(BEClsCd oBEClsCd)
        {
            return oBEClsCd.Precio * 0.9f; // 10% de descuento
        }
    }
}