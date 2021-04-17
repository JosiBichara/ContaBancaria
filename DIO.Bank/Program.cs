using System;
using System.Collections.Generic;
namespace DIO.Bank
{
    class Program
    {
        static List<Conta> ListaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario)
                {
                    case "1":
                        Listarcontas();
                        break;
                    case "2":
                        Inserirconta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigada por utilizar nossos serviços.");
            Console.ReadLine();

        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido:");
            double valorTransferencia = double.Parse(Console.ReadLine());

            ListaContas[indiceContaOrigem].Transferir(valorTransferencia, ListaContas[indiceContaDestino]);

        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado:");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Sacar(valorSaque);

        }

        private static void Listarcontas()
        {
            Console.WriteLine("Listar contas");

            if(ListaContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for(int i = 0; i < ListaContas.Count; i++){
                Conta conta = ListaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void Inserirconta(){
            Console.WriteLine("Inserir nova conta.");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaChequeEspecial = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta:(TipoConta) entradaTipoConta, entradaSaldo, entradaChequeEspecial, entradaNome);

            ListaContas.Add(novaConta);


        }
        public static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO BANK a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
