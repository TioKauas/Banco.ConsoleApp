namespace Banco.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Processos Conta1 = new Processos();
            Conta1.saldo = 1000;
            Conta1.numero = 12;
            Conta1.limite = 0;
            Conta1.saldoEspecial = true;
            Conta1.Movimentacoes = new dadosMovimentacao[10];

            Conta1.Sacar(200);

            Conta1.Depositar(300);

            Conta1.Depositar(500);

            Conta1.Sacar(200);

            Processos Conta2 = new Processos();
            Conta2.saldo = 300;
            Conta2.numero = 13;
            Conta2.limite = 0;
            Conta2.saldoEspecial = true;
            Conta2.Movimentacoes = new dadosMovimentacao[10];

            Conta2.Transerencia(Conta1, 400);

            Conta1.Extrato();

            Console.ReadKey();
        }
    }
}