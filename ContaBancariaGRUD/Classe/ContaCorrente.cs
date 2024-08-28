using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaGRUD.Classe
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(string numeroConta, string titular, decimal saldoInicial)
            : base (numeroConta, titular, saldoInicial) { }

        public override void Depositar(decimal valor)
        {
            Saldo += valor;
        }
        public override void Sacar(decimal valor)
        {
            if (Saldo < valor + 5)
                throw new SaldoInsuficienteException("Saldo insuficiente para saque com taxa. ");

            Saldo -= valor + 5;
        }
        public override void Transferencia(decimal valor, ContaBancaria contaDestino)
        {
            if (Saldo < valor + 5)
                throw new SaldoInsuficienteException("Salso insuficiente para tranferencia com taxa. ");

            Saldo -= valor + 5; contaDestino.Depositar(valor);
        }

    }
}
