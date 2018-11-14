using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1.Fundamentos
{
	class OperadoresRelacionais
	{
		public static void Executar()
		{
			for (int i = 0; i < 5; i++)
			{
				Console.Write("Digite a primeira nota do aluno: ");
				double nota1 = double.Parse(Console.ReadLine());

				Console.Write("Digite a segunda nota no aluno: ");
				double nota2 = double.Parse(Console.ReadLine());

				var media = (nota1 + nota2) / 2;

				if (media >= 7)
				{
					Console.WriteLine("Você esta aprovado e a sua média foi {0}: ", media);

				}
				else
				{
					Console.WriteLine("Você foi reprovado e a sua média foi {0}: ", media);
				}

			}	
			/*Console.WriteLine("Nota Invalida? {0}", nota1 > 10.0 && nota2 > 10.0);
			Console.WriteLine("Nota Invalida? {0}", nota1 > 10.0 && nota2 < 0.0);
			Console.WriteLine("Perfeito? {0}", media == 10.0);
			Console.WriteLine("Tem como melhorar? {0}", media != 10.0);
			Console.WriteLine("Reprovado? {0}", media <= 3.0);*/
		}
	}
}
