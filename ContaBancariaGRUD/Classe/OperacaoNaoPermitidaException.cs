using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaGRUD.Classe
{
    public class OperacaoNaoPermitidaException : Exception
    {
        public OperacaoNaoPermitidaException(string message) : base (message) { }
    }
}
