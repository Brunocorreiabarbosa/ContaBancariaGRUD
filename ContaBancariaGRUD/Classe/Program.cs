using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaGRUD.Classe
{
    class Program
    {
        static void Main (string[] args)
        {
            List<ContaBancaria> contas = new List<ContaBancaria>();

            ContaCorrente contaCorrente = new ContaCorrente("1234", "João Silva", 1000);
            ContaPoupanca contaPoupanca = new ContaPoupanca("5678", "Maria Oliveira", 2000);
            ContaInvestimento contaInvestimento = new ContaInvestimento("9012", "Carlos Souza", 5000);

            contas.Add(contaCorrente);
            contas.Add(contaPoupanca);
            contas.Add(contaInvestimento);

            try
            {
                contaCorrente.Depositar(500);
                contaCorrente.Sacar(200);
                contaCorrente.Transferencia(300, contaPoupanca);
                contaPoupanca.Sacar(100);
                contaPoupanca.Transferencia(100, contaInvestimento);
                contaInvestimento.Transferencia(100, contaCorrente);

                foreach(var conta in contas)
                {
                    Console.WriteLine($"Conta: {conta.NumeroConta}, Titular: {conta.Titular}, Saldo: {conta.Saldo:C}");

                }
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine($"Erro de saldo Insuficiente {ex.Message}");
            }
            catch (OperacaoNaoPermitidaException ex)
            {
                Console.WriteLine($"Erro de operação não permitida: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            Console.ReadKey();
    }
    }
}
