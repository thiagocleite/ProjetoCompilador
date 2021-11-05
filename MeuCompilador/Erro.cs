using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeuCompilador
{
    class Erro
    {
        private static bool erro;
        private static string mens;

        public static void setErro(bool _erro)
        {
            erro = _erro;
        }
        public static void setErro(String _mens)
        {
            erro = true;
            mens = _mens;
        }
        public static bool getErro() { return erro; }
        public static string getMens() { return mens; }
    }
}
