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
            frmListaAtualizacoes frmListaAtualizacoes = new frmListaAtualizacoes();
            frmListaAtualizacoes.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

            frmClientes FormClientes = new frmClientes();
            FormClientes.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            frmEquipa frmEquipa = new frmEquipa();
            frmEquipa.ShowDialog();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            frmVisita frmVisita = new frmVisita();
            frmVisita.ShowDialog();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            frmProduto frmProduto = new frmProduto();
            frmProduto.ShowDialog();
        }
    }
    }

