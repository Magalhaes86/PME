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
using MySql.Data.MySqlClient;

namespace PME
{
    public partial class frmListaClientes : Form
    {


        private frmClientes clienteForm;


        public frmListaClientes()
        {
            InitializeComponent();
            //kryptonDataGridView1.CellClick += kryptonDataGridView1_CellClick;
        }

        private string connectionString = "Server=localhost;Port=3308;Database=PmeCrm;Uid=root;Pwd=xd;";

        private void frmListaClientes_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT clientes.*, erp1.* " +
                               "FROM clientes " +
                               "LEFT JOIN erp1 ON erp1.CodCliente = clientes.ID";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    kryptonDataGridView1.DataSource = dataTable;
                }
            }
        }

        private void kryptonDataGridView1_Click(object sender, EventArgs e)
        {

        }
        private void CloseFormListaClientes()
        {
            Close();
        }
        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = kryptonDataGridView1.Rows[e.RowIndex];

                if (clienteForm == null || clienteForm.IsDisposed)
                {
                    clienteForm = new frmClientes();
                }

                clienteForm.txtCodCliente.Text = selectedRow.Cells[0].Value.ToString();
                clienteForm.txtNif.Text = selectedRow.Cells[1].Value.ToString();
                clienteForm.txtNome.Text = selectedRow.Cells[2].Value.ToString();
                clienteForm.txtNomeComercial.Text = selectedRow.Cells[3].Value.ToString();
                clienteForm.txtTlm.Text = selectedRow.Cells[4].Value.ToString();
                clienteForm.txtTlmSecundario.Text = selectedRow.Cells[5].Value.ToString();
                clienteForm.txtEmail.Text = selectedRow.Cells[6].Value.ToString();
                clienteForm.txtEmailSecundario.Text = selectedRow.Cells[7].Value.ToString();
                clienteForm.txtEstadoEmpresa.Text = selectedRow.Cells[8].Value.ToString();
                clienteForm.cbxTecnicoResponsavel.Text = selectedRow.Cells[9].Value.ToString();
                clienteForm.cbxTecnicoDeApoio.Text = selectedRow.Cells[10].Value.ToString();
                clienteForm.txtGestorDeConta.Text = selectedRow.Cells[11].Value.ToString();
                clienteForm.cbxERP1.Text = selectedRow.Cells[12].Value.ToString();
                clienteForm.cbxERP2.Text = selectedRow.Cells[13].Value.ToString();
                clienteForm.cbxERP3.Text = selectedRow.Cells[14].Value.ToString();
                clienteForm.txtCodErp1.Text = selectedRow.Cells[15].Value.ToString();
                clienteForm.cbx1ERP1.Text = selectedRow.Cells[16].Value.ToString();
                clienteForm.txt1Npostos1.Text = selectedRow.Cells[17].Value.ToString();
                clienteForm.txt1Nempresas1.Text = selectedRow.Cells[18].Value.ToString();
                clienteForm.cbx1Produto1.Text = selectedRow.Cells[19].Value.ToString();
                clienteForm.cbx1Produto2.Text = selectedRow.Cells[20].Value.ToString();
                clienteForm.cbx1Produto3.Text = selectedRow.Cells[21].Value.ToString();
                clienteForm.cbx1Produto4.Text = selectedRow.Cells[22].Value.ToString();
                clienteForm.cbx1Produto5.Text = selectedRow.Cells[23].Value.ToString();
                clienteForm.txtVersao1Instalada1.Text = selectedRow.Cells[24].Value.ToString();
                clienteForm.txtVersao1Instalada2.Text = selectedRow.Cells[25].Value.ToString();
                clienteForm.txtVersao1Instalada3.Text = selectedRow.Cells[26].Value.ToString();
                clienteForm.txtVersao1Instalada4.Text = selectedRow.Cells[27].Value.ToString();
                clienteForm.txtVersao1Instalada5.Text = selectedRow.Cells[28].Value.ToString();
                clienteForm.cbEstado1Lic1.Text = selectedRow.Cells[29].Value.ToString();
                clienteForm.cbEstado1Lic2.Text = selectedRow.Cells[30].Value.ToString();
                clienteForm.cbEstado1Lic3.Text = selectedRow.Cells[31].Value.ToString();
                clienteForm.cbEstado1Lic4.Text = selectedRow.Cells[32].Value.ToString();
                clienteForm.cbEstado1Lic5.Text = selectedRow.Cells[33].Value.ToString();
                clienteForm.cbTecnico1Responsa1.Text = selectedRow.Cells[34].Value.ToString();
                clienteForm.cbTecnico1Responsa2.Text = selectedRow.Cells[35].Value.ToString();
                clienteForm.cbTecnico1Responsa3.Text = selectedRow.Cells[36].Value.ToString();
                clienteForm.cbTecnico1Responsa4.Text = selectedRow.Cells[37].Value.ToString();
                clienteForm.cbTecnico1Responsa5.Text = selectedRow.Cells[38].Value.ToString();
                clienteForm.cbx1ModulosExtra1.Text = selectedRow.Cells[39].Value.ToString();
                clienteForm.txt1DescricaoModulos1.Text = selectedRow.Cells[40].Value.ToString();
                clienteForm.cbx1Desenvolvimentos1.Text = selectedRow.Cells[41].Value.ToString();

        
            }
        }
    }
}
