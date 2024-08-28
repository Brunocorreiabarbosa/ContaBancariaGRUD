using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaGRUD.Classe
{
    public abstract class ContaBancaria
    {
        public string NumeroConta { get; set; }
        public string Titular { get; set; }
        public decimal Saldo { get; set; }

        public ContaBancaria(string numeroConta, string titular, decimal saldoInicial)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = saldoInicial;
        }
        public abstract void Depositar(decimal valor);
        public abstract void Sacar(decimal valor);
        public abstract void Transferencia(decimal valor, ContaBancaria contaDestino);
    }
}
