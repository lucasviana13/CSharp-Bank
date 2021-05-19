using System;
using System.Collections.Generic;

namespace Banco
{
    class Program
    {
        static List<Conta> listacontas = new List<Conta>();
        static void Main(string[] args)
        {            
            string opcaoUsuario = OpcaoUsuario();

            while (opcaoUsuario!="S")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListaContas();
                    break;
                    
                    case "2":
                        NovaConta();
                    break;  
                    
                    case "3":
                        Transferencia();
                    break;  
                    
                    case "4":
                        Deposito();
                    break;  
                    
                    case "5":
                        Saque();
                    break;

                    case "C":
                        Console.Clear();
                    break;

                    //default:
                     //   throw new ArgumentOutOfRangeException();
                }
            opcaoUsuario = OpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços");
            Console.ReadLine();
        }

        private static void Deposito()
        {
            Console.Write("Digite o numero da conta de destino: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDepositado = double.Parse(Console.ReadLine());
            
            listacontas[indice].Deposito(valorDepositado);        
        
        }

        private static void Transferencia()
        {
            Console.Write("Digite o numero da conta de origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferido = double.Parse(Console.ReadLine());
            
            listacontas[indiceOrigem].Transferencia(listacontas[indiceDestino],valorTransferido);        

        }

        private static void Saque()
        {
            Console.Write("Digite o numero da conta: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
            
            listacontas[indice].Saque(valorSaque);        
        }

        private static void ListaContas()
        {
            Console.WriteLine("Listar Contas");

            if (listacontas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada no sistema");
                return;
            }
            for (int i=0; i<listacontas.Count; i++)
            {
                Conta contalista = listacontas[i];
                Console.WriteLine("Conta {0}:",i);
                Console.WriteLine(contalista);
            }
        }

        private static void NovaConta()
        {
            Console.WriteLine("Nova Conta:");

            Console.Write("Digite 1 para Conta Física e 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            
            Console.Write("Digite o Saldo: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            
            Conta conta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                    credito: entradaCredito,
                                    nome: entradaNome,
                                    saldo: entradaSaldo
                                    );
            listacontas.Add(conta);
        }

        private static string OpcaoUsuario()
            {
                Console.WriteLine("\nBem vindo ao nosso Banco");
                Console.WriteLine("Opções:");
                Console.WriteLine("1- Listar Contas");
                Console.WriteLine("2- Inserir Conta");
                Console.WriteLine("3- Transferir");
                Console.WriteLine("4- Depositar");
                Console.WriteLine("5- Sacar");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("S- Sair\n");
                Console.Write("Digite a opção que desejar: ");


                string opcao = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcao;
                
            }
        }
}

