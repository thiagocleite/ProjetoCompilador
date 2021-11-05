using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeuCompilador
{
    class TokensValidos
    {
        private static string codigo;
        private static string token;
        private static string tipo;
        private static string linha;

        public TokensValidos() { }
        public static void setCodigo(string _codigo) { codigo = _codigo; }
        public static void setToken(string _token) { token = _token; }
        public static void setTipo(string _tipo) { tipo = _tipo; }
        public static void setLinha(string _linha) { linha = _linha; }

        public static string getCodigo() { return codigo; }
        public static string getToken() { return token; }
        public static string getTipo() { return tipo; }
        public static string getLinha() { return linha; }
    }
}
