using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpcaoSelecionada = ObterOpcaoUsuario();

            while (OpcaoSelecionada != "X")
            {
                switch (OpcaoSelecionada)
                {
                    case "1":
                        ListarContas();
                        break;
                    case  "2":
                        InserirConta();
                        break;
                    case  "3":
                        Transferir();
                        break;
                    case  "4":
                        Sacar();
                        break;
                    case  "5":
                        Depositar();
                        break;
                    case  "C":
                        Console.Clear();
                        break;
                    case  "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                OpcaoSelecionada = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[numConta].DepositarDinheiro(valorDeposito);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int numContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int numContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[numContaOrigem].TransferirDinheiro(valorTransferencia, listContas[numContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[numConta].SacarDinheiro(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i=0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta, informe qual o tipo da conta:");
            Console.WriteLine("1- Conta Fisica.  ou  2- Conta Jurídica.");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o valor do saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("VCM Bank a seu dispor!!!");
            Console.WriteLine("Informe a funcionalidade desejada:");

            Console.WriteLine("1- Listar contas.");
            Console.WriteLine("2- Inserir nova conta.");
            Console.WriteLine("3- Transferir dinheiro.");
            Console.WriteLine("4- Sacar dinheiro.");
            Console.WriteLine("5- Depositar dinheiro.");
            Console.WriteLine("C- Limpar a tela.");
            Console.WriteLine("X- Sair do programa.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
