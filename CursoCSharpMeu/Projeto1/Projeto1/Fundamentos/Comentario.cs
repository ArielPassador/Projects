using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1.Fundamentos
{
	class Comentario
	{
		public static void Executar()
		{
			Console.Write("Digite o seu nome: ");
			string nome = Console.ReadLine();

			Console.Write("Digite sua idade: ");
			int idade = int.Parse(Console.ReadLine());

			double valorTotal = 0.0;
			Console.WriteLine("O que você deseja fazer?");
			Console.WriteLine("1 - Depositar");
			Console.WriteLine("2 - Sacar");
			Console.WriteLine("3 - Verificar o saldo");
			int c = int.Parse(Console.ReadLine());

			switch (c)
			{
				case 1:
					{
						Console.Write("Qual o valor que você deseja depositar?");
						double valorDepositado = double.Parse(Console.ReadLine());
						valorTotal = valorTotal + valorDepositado;
						break;
					}
				case 2:
					{
						Console.Write("Qual o valor que você deseja sacar?");
						double valorSacado = double.Parse(Console.ReadLine());
						valorTotal = valorTotal - valorSacado;
						break;
					}
				case 3:
					{
						if (valorTotal == 0)
						{
							Console.Write("Você não possui valor no saldo!");
						}
						else
						{
							Console.Write("Você possui um saldo de {0}", valorTotal);
						}
						break;

					}

			}
		}
	}
}
