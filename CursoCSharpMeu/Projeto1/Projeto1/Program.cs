using System;
using System.Collections.Generic;

using Projeto1.Fundamentos;
using Projeto1.Classes_e_Metodos;

namespace Projeto1 {
    class Program {
        static void Main(string[] args) {
			var central = new CentralDeExercicios(new Dictionary<string, Action>() {
				//Fundamentos
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

				//Classes e Metodos
				{"Metodos com Retorno - Classes e Metodos", MetodosComRetorno.Executar},
				{"Desafio Atributo - Classes e Metodos", DesafioAtributo.Executar},
				{"Params - Classes e Metodos", Params.Executar},
				{"Params Nomeados - Classes e Metodos", ParamsNomeados.Executar},
				{"Getter e Setter - Classes e Metodos", GetESet.Executar},
				{"Props - Classes e Metodos", Props.Executar},
				






			});

            central.SelecionarEExecutar();
        }
    }
}