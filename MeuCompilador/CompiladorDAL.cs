using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace MeuCompilador
{
    class CompiladorDAL
    {
        private static OleDbConnection con;
        private static OleDbCommand cmd;
        private static OleDbDataReader dr;
        public static void Conecta()
        {
            try
            {
                con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Compilador.mdb");
                con.Open();
            }
            catch (Exception e)
            {
                Erro.setErro(e.ToString());
            }
        }
        public static void Desconecta()
        {
            try
            {
                con.Close();
            }
            catch (Exception e)
            {
                Erro.setErro(e.ToString());
            }
        }
        public static bool VerificaToken(string token)
        {
            Tokens.setToken(token);
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT codigo,token FROM TTokens where token='"+Tokens.getToken()+"'";
            dr = cmd.ExecuteReader();
            dr.Read();
            if(dr["codigo"].ToString()!=""){
                Tokens.setCodigo(dr["codigo"].ToString());
                Tokens.setToken(dr["token"].ToString());
                return true;
            }else{
                return false;
            }
        }
        public static void inseriTokenValido()
        {
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO TTokensValidos(Codigo,Token,Tipo,Linha)VALUES('"+TokensValidos.getCodigo()+"','"+TokensValidos.getToken()+"','"+TokensValidos.getTipo()+"','"+TokensValidos.getLinha()+"')";
            cmd.ExecuteNonQuery();

        }
    }
}
