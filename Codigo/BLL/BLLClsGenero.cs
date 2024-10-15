using System;
using System.Collections.Generic;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLClsGenero : IGestor<BEClsGenero>
    {
        private MPPGenero oMPPGenero = new MPPGenero();

        public List<BEClsGenero> ListarTodo()
        {
            return oMPPGenero.ListarTodo();
        }

        public bool Guardar(BEClsGenero oBEGenero)
        {
            return oMPPGenero.Guardar(oBEGenero);
        }

        public bool Baja(BEClsGenero oBEGenero)
        {
            return oMPPGenero.Baja(oBEGenero);
        }

        public BEClsGenero ListarObjeto(BEClsGenero Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
