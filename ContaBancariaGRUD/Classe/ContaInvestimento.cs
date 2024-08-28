using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaGRUD.Classe
{
    public class ContaInvestimento : ContaBancaria
    {
        private int transferenciasMensais;

        public ContaInvestimento(string numeroConta, string titular, decimal saldoInicial)
            : base (numeroConta, titular, saldoInicial)
        {
            transferenciasMensais = 0;
        }
        public override void Depositar (decimal valor)
        {
            Saldo += valor;
        }
        public override void Sacar(decimal valor)
        {
            if (Saldo < valor)
                throw new SaldoInsuficienteException("Saldo insuficiente para saque.");

            Saldo -= valor;
        }
        public override void Transferencia(decimal valor, ContaBancaria contaDestino)
        {
            if (transferenciasMensais >=1)
                throw new OperacaoNaoPermitidaException("Apenas uma transferência é permitida por mês para contas de investimento.");

            if (Saldo < valor)
                throw new SaldoInsuficienteException("Saldo insuficiente para transferência.");

            Saldo -= valor;
            contaDestino.Depositar(valor);
            transferenciasMensais++;

        }
    }
}
