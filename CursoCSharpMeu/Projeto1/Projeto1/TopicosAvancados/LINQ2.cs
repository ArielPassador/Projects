using System;
using System.Collections.Generic;
using System.Linq;
using static Projeto1.TopicosAvancados.LINQ1;

namespace Projeto1.TopicosAvancados
{
	class LINQ2
	{
		public static void Executar()
		{
			var alunos = new List<Aluno>
			{
				new Aluno() {Nome = "Pedro", Idade = 24, Nota = 8.0},
				new Aluno() {Nome = "Andre", Idade = 21, Nota = 4.3},
				new Aluno() {Nome = "Ana", Idade = 25, Nota = 9.5},
				new Aluno() {Nome = "Jorge", Idade = 20, Nota = 8.5},
				new Aluno() {Nome = "Ana", Idade = 21, Nota = 7.7},
				new Aluno() {Nome = "Julia", Idade = 22, Nota = 7.5},
				new Aluno() {Nome = "Marcio", Idade = 18, Nota = 6.8}
			};

			var pedro = alunos.Single(aluno => aluno.Nome.Equals("Pedro"));
			Console.WriteLine($"{pedro.Nome} {pedro.Nota}");

			var fulano = alunos.SingleOrDefault(aluno => aluno.Nome.Equals("Fulano"));
			if (fulano == null)
			{
				Console.WriteLine("Aluno Inexistente!");
			}

			var ana = alunos.First(aluno => aluno.Nome.Equals("Ana"));
			Console.WriteLine(ana.Nota);

			var mediaTurma = alunos.Average(a => a.Nota);
			Console.WriteLine(mediaTurma);

		}
	}
}
