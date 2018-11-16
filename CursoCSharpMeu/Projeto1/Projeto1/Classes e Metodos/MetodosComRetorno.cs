using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1.Classes_e_Metodos
{

	class Calculadora
	{
		public int somar(int a, int b)
		{
			return a + b;
		}

		public int subtrair(int a, int b)
		{
			return a - b;
		}

		public int multiplicar(int a, int b)
		{
			return a * b;
		}

		public int dividir(int a, int b)
		{
			return a / b;
		}
	}

	class CalculadoraCadeia
	{
		int memoria;

		public CalculadoraCadeia Somar(int a)
		{
			memoria += a;
			return this;
		}
		public CalculadoraCadeia Subtrair(int a)
		{
			memoria -= a;
			return this;
		}

		public CalculadoraCadeia Multiplicar(int a)
		{
			memoria *= a;
			return this;
		}
	}
	class MetodosComRetorno
	{
		public static void Executar()
		{
			Calculadora c1 = new Calculadora();

			Console.WriteLine(c1.somar(1, 2));
			Console.WriteLine(c1.subtrair(5, 2));
			Console.WriteLine(c1.multiplicar(2, 2));
			Console.WriteLine(c1.dividir(6, 2));
		}
	}
}
