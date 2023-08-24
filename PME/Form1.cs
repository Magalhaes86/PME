using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace PME
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonWrapLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            frmAtualizacoes Formtualizacoes = new frmAtualizacoes();
            Formtualizacoes.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

            frmClientes FormClientes = new frmClientes();
            FormClientes.ShowDialog();
        }
    }
}
