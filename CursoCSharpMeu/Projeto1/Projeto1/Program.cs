using System;
using System.Collections.Generic;

using Projeto1.Fundamentos;

namespace Projeto1 {
    class Program {
        static void Main(string[] args) {
			var central = new CentralDeExercicios(new Dictionary<string, Action>() {
				{"Primeiro Programa - Fundamentos", PrimeiroPrograma.Executar},
				{"Comentário - Fundamentos", Comentario.Executar },
				{"Variaves & Constantes - Fundamentos", Variaveis_Constanstes.Executar},
				{"Inferencia - Fundamentos", Inferencia.Executar},
				{"Interpolação - Fundamentos", Interpolacao.Executar},
				{"Notação Ponto - Fundamentos", NotacaoPonto.Executar},
				{"Lendo dados do Console - Fundamentos", LendoDados.Executar},
				{"Formatando dados - Fundamentos", FormatandoNumeros.Executar},
				{"Conversoes - Fundamentos", Conversoes.Executar},
				{"Operadores Aritmeticos - Fundamentos", OperadoresAritmeticos.Executar},
				{"Operadores Relacionais - Fundamentos", OperadoresRelacionais.Executar},
				{"Operadores Lógicos - Fundamentos", OperadoresLogicos.Executar},
				{"Operadores de Atribuição - Fundamentos", OperadoresAtribuicao.Executar},



            });

            central.SelecionarEExecutar();
        }
    }
}