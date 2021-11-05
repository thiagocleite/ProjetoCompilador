using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeuCompilador
{
    public partial class CompiladorIHM : Form
    {
        OpenFileDialog fd = new OpenFileDialog();
        public CompiladorIHM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fd.ShowDialog();
            textBoxPrograma.Text = fd.FileName;
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBoxPrograma.Clear();
        }

        private void textBoxPrograma_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPrograma.Text != "")
                buttonCompilar.Enabled = true;
            else
                buttonCompilar.Enabled = false;
        }

        private void buttonCompilar_Click(object sender, EventArgs e)
        {
            CompiladorBLL cbll = new CompiladorBLL();
            cbll.CaminhoArquivo = textBoxPrograma.Text;
            cbll.Filtro();
            cbll.extrairTokensValidos();
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMens());
            }
            else
            {
                MessageBox.Show("Compilado com sucesso!");
            }
        }
    }
}
