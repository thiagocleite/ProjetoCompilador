using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace MeuCompilador
{
    class CompiladorBLL
    {
        private const string TEMP = @"C:\Users\thiag\AppData\Local\Temp\";
        //private FileStream fs;
        private string caminhoArquivo;

        public string CaminhoArquivo
        {
            get { return caminhoArquivo; }
            set { caminhoArquivo = value; }
        }
        public void Filtro()
        {
            FileStream infile, outfile;
            int tam;
            char x;

            infile = new System.IO.FileStream(caminhoArquivo,
                                               System.IO.FileMode.Open,
                                               System.IO.FileAccess.Read);
            outfile = new System.IO.FileStream(TEMP + "PFTMP.txt",
                                               System.IO.FileMode.Create,
                                               System.IO.FileAccess.Write);

            tam = (int)infile.Length;
            for (int i = 0; i < tam; ++i)
            {
                x = (char)infile.ReadByte();
                x = char.ToUpper(x);
                if (x == '#')
                {
                    do
                    {
                        x = (char)infile.ReadByte();
                        ++i;
                    }
                    while (x != '#');
                }
                else
                    if (x == '"')
                    {
                        do
                        {
                            outfile.WriteByte((byte)x);
                            x = (char)infile.ReadByte();
                            ++i;
                        }
                        while (x != '"');
                        outfile.WriteByte((byte)x);
                    }
                    else
                        if (x != ' ')
                            outfile.WriteByte((byte)x);
            }
            infile.Close();
            outfile.Close();
        }
        public void extrairTokensValidos()
        {
            CompiladorDAL.Conecta();
            FileStream infile;
            int tam;
            int kl = 1;
            char x;
            String aux = "";

            infile = new System.IO.FileStream(TEMP + "PFTMP.txt",
                                               System.IO.FileMode.Open,
                                               System.IO.FileAccess.ReadWrite);

            tam = (int)infile.Length;
            for (int i = 0; i < tam; ++i)
            {
                x = (char)infile.ReadByte();

                //if (char.IsDigit(x))
                //{
                //    while (char.IsDigit(x))
                //    {
                //        aux = aux + x;
                //        x = (char)infile.ReadByte();
                //        ++i;
                //    }
                //    Console.WriteLine("Linha " + kl + " (Inteiro)..: " + aux);
                //    aux = "";
                //}

                if (char.IsLetter(x))
                {
                    aux = "";
                    while (char.IsLetter(x))
                    {
                        aux = aux + x;
                        x = (char)infile.ReadByte();
                        ++i;
                    }
                    if(CompiladorDAL.VerificaToken(aux)){
                        TokensValidos.setCodigo(Tokens.getCodigo());
                        TokensValidos.setToken(Tokens.getToken());
                        TokensValidos.setLinha(kl.ToString());
                        TokensValidos.setTipo("STRING");
                        CompiladorDAL.inseriTokenValido();
                    }
                    aux = "";
                }

                if (char.IsPunctuation(x) || char.IsSymbol(x))
                {
                    Console.WriteLine("Linha " + kl + " (Delimitador)...: " + x);
                }

                if (x == 13) ++kl;

            }
            infile.Close();
            CompiladorDAL.Desconecta();
        }
    }
}
