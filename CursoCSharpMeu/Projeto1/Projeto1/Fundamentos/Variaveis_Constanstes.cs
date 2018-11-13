using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1.Fundamentos
{
	class Variaveis_Constanstes
	{
		public static void Executar()
		{
			//area da circunferencia
			double raio = 4.5;
			const double PI = 3.14;

			raio = 5.5;
			//PI = 3.14.15 -- Não pode mudar o valor pois esta const

			double area = PI * raio * raio;
			Console.WriteLine(area);
			Console.WriteLine("Área é "+ area);

			//Tipos Internos
			bool estaChovendo = true;
			Console.WriteLine("Está chovendo " + estaChovendo);

			byte idade = 45;
			Console.WriteLine("Idade é " + idade);

			sbyte saldoDeGols = sbyte.MinValue;
			Console.WriteLine("Saldo de gols " + saldoDeGols);

			short salario = short.MaxValue;
			Console.WriteLine("Sálario " + salario);

			int menorValorInt = int.MinValue;
			Console.WriteLine("Menor valor int é " + menorValorInt);

			uint populacaoBrasileira = 207_600_000;
			Console.WriteLine("População Brasileira " + populacaoBrasileira);

			long menorValorLong = long.MinValue;
			Console.WriteLine("Menor long " + menorValorLong);

			ulong populacaoMundial = 7_600_000_000;
			Console.WriteLine("População Mundial " + populacaoMundial);

			float precoComputador = 1299.99f;
			Console.WriteLine("Preço Computador" + precoComputador);

			decimal distanciaEntreEstrelas = decimal.MaxValue;
			Console.WriteLine("Distancia entre Estrelas " + distanciaEntreEstrelas);

			char letra = 'a';
			Console.WriteLine("Letra " + letra);

			string texto = "Aqui tem uma String";
			Console.WriteLine("String: " + texto);
			

		}
	}
}
