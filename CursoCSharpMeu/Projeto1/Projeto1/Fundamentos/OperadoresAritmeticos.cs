using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1.Fundamentos
{
	class OperadoresAritmeticos
	{
		public static void Executar()
		{
			//Preço Desconto
			var preco = 1000.0;
			var imposto = 355;
			var desconto = 0.1;

			double total = preco + imposto;

			double totalComDesconto = total - (total * desconto);
			Console.WriteLine("O preço total é {0}", totalComDesconto);

			//IMC

			double peso = 91.2;
			double altura = 1.82;
			double imc = peso / Math.Pow(altura, 2);
			Console.WriteLine(imc);


			//Numero Par ou Impar
			int par = 24;
			int impar = 55;
			Console.WriteLine("{0}/2 tem resto de {1}", par, par % 2);
			Console.WriteLine("{0}/2 tem resto de {1}", impar, impar % 2);



		}
	}
}