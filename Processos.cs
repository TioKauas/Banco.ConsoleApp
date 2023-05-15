using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.ConsoleApp
{
    internal class Processos
    {
        public double saldo;
        public int numero;
        public int limite;
        public bool saldoEspecial;

        public dadosMovimentacao[] Movimentacoes;

        public bool Sacar(double Quantia)
        {
            if (Quantia > saldo + limite)
            {
                return false;
            }

            if (Quantia < saldo + limite)
            {
                double novoSaldo = saldo - Quantia;

                saldo = novoSaldo;

                dadosMovimentacao movimentacao = new dadosMovimentacao();
                movimentacao.Valor = Quantia;
                movimentacao.Tipo = "Débito";
                movimentacao.Descricao = $"Débito de R${Quantia} reais";

                int posicaoVazia = PegaPosicaoVazia();

                Movimentacoes[posicaoVazia] = movimentacao;
            }

            return true;
        }

        public void Depositar(double Quantia)
        {
            double novoSaldo = saldo + Quantia;

            saldo = novoSaldo;

            dadosMovimentacao movimentacao = new dadosMovimentacao();
            movimentacao.Valor = Quantia;
            movimentacao.Tipo = "Crédito";
            movimentacao.Descricao = $"Crédito de R${Quantia} reais";


            int posicaoVazia = PegaPosicaoVazia();

            Movimentacoes[posicaoVazia] = movimentacao;
        }

        public void Transerencia(Processos contaDestino, double Quantia)
        {
            bool Sacou = this.Sacar(Quantia);

            if (Sacou) 
            {
                contaDestino.Depositar(Quantia);
            }
        }

        public void Extrato()
        {
            Console.WriteLine($"Número de conta {numero}\n");

            Console.WriteLine("Movimentações:\n");

            if (Movimentacoes != null)
            {
                foreach (dadosMovimentacao m in Movimentacoes)
                {
                    Console.WriteLine(m.Descricao);
                }
            }
            else
            {
                Console.WriteLine("Lista de movimentações é nula.");
            }


            Console.WriteLine($"Saldo atual: {saldo + limite}");
        }

        public int PegaPosicaoVazia()
        {
            for (int i = 0; i < Movimentacoes.Length; i++)
            {
                if (Movimentacoes[i] == null)
                    return i;
            }

            return -1;
        }
    }
}
