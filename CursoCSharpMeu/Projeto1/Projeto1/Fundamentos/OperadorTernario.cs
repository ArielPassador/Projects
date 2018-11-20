using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1.Fundamentos
{
    class OperadorTernario
    {
        public static void Executar() {
            var nota = 9.0;
            bool bomComportamento = true;
            string resultado = nota >= 7.0 && bomComportamento 
                ? "Aprovado" : "Reprovado";
            Console.WriteLine(resultado);
        }
    }
}
