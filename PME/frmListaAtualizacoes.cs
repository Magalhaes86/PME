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
    public partial class frmListaAtualizacoes : KryptonForm
    {
        public frmListaAtualizacoes()
        {
            InitializeComponent();
        }

        private void frmListaAtualizacoes_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            frmAtualizacoes frmAtualizacoes = new frmAtualizacoes();
            frmAtualizacoes.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
