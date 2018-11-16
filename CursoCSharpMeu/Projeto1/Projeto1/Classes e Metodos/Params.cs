using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1.Classes_e_Metodos
{
	class Params
	{
		private static string[] nome;

		public static void Recepcionar(params string[] pessoas)
		{
			foreach (var pessoa in pessoas)
			{
				Console.WriteLine("Ola {0}", pessoa);
			}
		}

		public static void Executar()
		{ 
			Console.Write("Digite seu nome: ");
			string nome = Console.ReadLine();
			Recepcionar(nome);
		}
	}
}
