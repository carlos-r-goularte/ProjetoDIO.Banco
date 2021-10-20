using System;
using System.Collections.Generic;

namespace ProjetoDIO.Banco
{
	class Program
	{
		static List<Conta> listContas = new List<Conta>();
		static void Main(string[] args)
		{
			string opcaoUsuario = Menu();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						CriarConta();
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

				opcaoUsuario = Menu();
			}

			Console.WriteLine("Obrigado e volte sempre!.");
			Console.ReadLine();
		}

		private static void Depositar()
		{
			Console.Write("Digite o número da conta a ser realizado o deposito: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.WriteLine();

			Console.Write("Digite o valor para deposito: ");
			double valorDeposito = double.Parse(Console.ReadLine());

			listContas[indiceConta].Depositar(valorDeposito);

			Console.WriteLine();
			Console.WriteLine("Deposito realizado com sucesso!");
			Console.WriteLine();
		}

		private static void Sacar()
		{
			Console.Write("Digite o número da conta para o saque: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.WriteLine();

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

			listContas[indiceConta].Sacar(valorSaque);

			Console.WriteLine();
			Console.WriteLine("Saque realizado com sucesso!");
			Console.WriteLine();
		}

		private static void Transferir()
		{
			Console.Write("Digite o número da conta origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

			Console.WriteLine();

			Console.Write("Digite o número da conta destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.WriteLine();

			Console.Write("Digite o valor para transferência: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

			listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

			Console.WriteLine();
			Console.WriteLine("Transferência realizada com sucesso!");
			Console.WriteLine();
		}

		private static void CriarConta()
		{
			Console.WriteLine("Inserir nova conta");
			Console.WriteLine();

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.WriteLine();

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.WriteLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.WriteLine();

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);

			Console.WriteLine();
			Console.WriteLine("Conta criada com sucesso!");
			Console.WriteLine();
		}

		private static void ListarContas()
		{
			Console.WriteLine("Listar contas");
			Console.WriteLine();

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				Console.WriteLine();
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
			Console.WriteLine();
		}

		private static string Menu()
		{
			Console.WriteLine();
			Console.WriteLine("===================");
			Console.WriteLine("Bem vindo ao Banco!");
			Console.WriteLine("===================");
			Console.WriteLine();
			Console.WriteLine("O que desejas?:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
			Console.WriteLine();
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}