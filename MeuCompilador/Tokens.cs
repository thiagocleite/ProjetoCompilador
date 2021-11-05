using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeuCompilador
{
    class Tokens
    {
        private static string codigo;
        private static string token;

        public Tokens() { }
        public static void setCodigo(string _codigo) { codigo = _codigo; }
        public static void setToken(string _token) { token = _token; }

        public static string getCodigo() { return codigo; }
        public static string getToken() { return token; }

    }
}
