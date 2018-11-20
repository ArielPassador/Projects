using System;
using System.Collections.Generic;

using Projeto1.Fundamentos;
using Projeto1.ClassesEMetodos;
using Projeto1.Colecoes;
using Projeto1.OO;
using Projeto1.MetodosEFuncoes;
using Projeto1.Excecoes;
using Projeto1.Api;
using Projeto1.TopicosAvancados;

namespace Projeto1 {
    class Program {
        static void Main(string[] args) {
            var central = new CentralDeExercicios(new Dictionary<string, Action>() {
                // Fundamentos
                {"Primeiro Programa - Fundamentos", PrimeiroPrograma.Executar},
                {"Comentários - Fundamentos", Comentarios.Executar},
                {"Váriaveis e Constantes - Fundamentos", VariaveisEConstantes.Executar},
                {"Inferência - Fundamentos", Inferencia.Executar},
                {"Interpolação - Fundamentos", Interpolacao.Executar},
                {"Notação Ponto - Fundamentos", NotacaoPonto.Executar},
                {"Lendo Dados - Fundamentos", LendoDados.Executar},
                {"Formatando Número - Fundamentos", FormatandoNumero.Executar},
                {"Conversões - Fundamentos", Conversoes.Executar},
                {"Operadores Aritmeticos - Fundamentos", OperadoresAritmeticos.Executar},
                {"Operadores Relacionais - Fundamentos", OperadoresRelacionais.Executar},
                {"Operadores Logicos - Fundamentos", OperadoresLogicos.Executar},
                {"Operadores de Atribuição - Fundamentos", OperadoresAtribuicao.Executar},
                {"Operadores Unários - Fundamentos", OperadoresUnarios.Executar},
                {"Operador Ternário - Fundamentos", OperadorTernario.Executar},

                // Classes e Métodos
                { "Construtores - Classes e Métodos", Construtores.Executar},
                { "Métodos Com Retorno - Classes e Métodos", MetodosComRetorno.Executar},
                { "Métodos Estáticos - Classes e Métodos", MetodosEstaticos.Executar},
                { "Atributos Estáticos - Classes e Métodos", AtributosEstaticos.Executar},
                { "Desafio Atributo - Classes e Métodos", DesafioAtributo.Executar},
                { "Params - Classes e Métodos", Params.Executar},
               
                // Coleções
                { "Array - Coleções", Colecoes.Array.Executar},
                { "List - Coleções", ColecoesList.Executar},
                { "Array List - Coleções", ColecoesArrayList.Executar},
                { "Set - Coleções", ColecoesSet.Executar},
                { "Queue - Coleções", ColecoesQueue.Executar},
                { "Igualdade - Coleções", Igualdade.Executar},
                { "Stack - Coleções", ColecoesStack.Executar},
                { "Dictionary - Coleções", ColecoesDictionary.Executar},

                // OO
                { "Herança - OO", Heranca.Executar},
                { "Construtor This - OO", ConstrutorThis.Executar},
                { "Polimorfismo - OO", Polimorfismo.Executar},
                { "Abstract - OO", Abstract.Executar},
                { "Interface - OO", Interface.Executar},
                { "Sealed - OO", Sealed.Executar},

                // Métodos & Funções
                { "Exemplo Lambda - Métodos & Funções", ExemploLambda.Executar},
                { "Lambdas Como Delegates - Métodos & Funções", LambdasDelegate.Executar},
                { "Usando Delegates - Métodos & Funções", UsandoDelegates.Executar},
                { "Delegates Como Função Anonima - Métodos & Funções", DelegateFunAnonima.Executar},
                { "Delegates Como Parâmetros - Métodos & Funções", DelegatesComoParametros.Executar},
                { "Métodos de Extensão - Métodos & Funções", MetodosDeExtensao.Executar},

                // Exceções
                { "Primeira Exceção - Exceções", PrimeiraExcecao.Executar},
                { "Exceções Personalizadas - Exceções", ExcecoesPersonalizadas.Executar},

                // Api
                { "Primeiro Arquivo - Usando API", PrimeiroArquivo.Executar},
                { "Lendo Arquivos - Usando API", LendoArquivos.Executar},
                { "Exemplo FileInfo - Usando API", ExemploFileInfo.Executar},
                { "Diretórios - Usando API", Diretorios.Executar},
                { "Exemplo DirectoryInfo - Usando API", ExemploDirectoryInfo.Executar},
                { "Exemplo Path - Usando API", ExemploPath.Executar},
                { "Exemplo DateTime - Usando API", ExemploDateTime.Executar},
                { "Exemplo Timespan - Usando API", ExemploTimeSpan.Executar},

				// Tópicos Avançados
                { "LINQ #01 - Tópicos Avançados", LINQ1.Executar},
				{ "LINQ #02 - Tópicos Avançados", LINQ2.Executar},
                { "Nullables - Tópicos Avançados", Nullables.Executar},
                { "Dynamics - Tópicos Avançados", Dynamics.Executar},
				{ "Genéricos - Tópicos Avançados", Genericos.Executar},
            });

            central.SelecionarEExecutar();
        }
    }
}