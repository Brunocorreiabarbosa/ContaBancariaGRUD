using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaGRUD.Classe
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(string numeroConta, string titular, decimal saldoInicial)
            : base (numeroConta, titular, saldoInicial) { }
        public override void Depositar(decimal valor)
        {
            Saldo += valor;
        }
        public override void Sacar(decimal valor)
        {
            if (Saldo - valor < 50)
                throw new SaldoInsuficienteException("Não é permitido sacar.Saldo mínimo deve ser de R$ 50, 00.");

            Saldo -= valor; 
            
        }
        public override void Transferencia(decimal valor, ContaBancaria contaDestino)
        {
            if (Saldo - valor < 50)
                throw new SaldoInsuficienteException("Não é permitido transferir. Saldo mínimo deve ser de R$ 50,00.");

            Saldo -= valor;
            contaDestino.Depositar(valor);
        }
    }
}
