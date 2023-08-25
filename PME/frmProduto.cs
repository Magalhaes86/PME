using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PME
{
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Port=3308;Database=PmeCrm;Uid=root;Pwd=xd;";

        private void kryptonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmProduto_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO ERP (ERP) " +
                       "VALUES (@ERP);" +
                       "SELECT LAST_INSERT_ID();"; // Recupera o ID gerado

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ERP", txtErp.Text);

                    connection.Open();
                    int insertedId = Convert.ToInt32(command.ExecuteScalar()); // Recupera o ID gerado
                    connection.Close();

                    txtIdERP.Text = insertedId.ToString(); // Exibe o ID gerado no campo txtIdERP
                    MessageBox.Show("Dados do produto gravados com sucesso!");
                }
            }
    }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdERP.Text))
            {
                string updateQuery = "UPDATE ERP " +
                                    "SET ERP = @ERP " +
                                    "WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ERP", txtErp.Text);
                        command.Parameters.AddWithValue("@ID", txtIdERP.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Dados do produto atualizados com sucesso!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Digite um ID válido para atualizar.");
            }
        }

        private void LimparCampos()
        {
            txtIdERP.Text = "";
            txtErp.Text = "";
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdERP.Text))
            {
                string deleteQuery = "DELETE FROM ERP WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", txtIdERP.Text);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro de produto excluído com sucesso!");
                            LimparCampos(); // Função para limpar os campos do formulário
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro encontrado para o ID especificado.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Digite um ID válido para excluir.");
            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Produto (ERP, PRODUTO) " +
                        "VALUES (@ERP, @PRODUTO);" +
                        "SELECT LAST_INSERT_ID();"; // Recupera o ID gerado

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ERP", cbxErp.Text);
                    command.Parameters.AddWithValue("@PRODUTO", txtProduto.Text);

                    connection.Open();
                    int insertedId = Convert.ToInt32(command.ExecuteScalar()); // Recupera o ID gerado
                    connection.Close();

                    txtIdProduto.Text = insertedId.ToString(); // Exibe o ID gerado no campo txtIdProduto
                    MessageBox.Show("Dados do produto gravados com sucesso!");
                }
            }
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdProduto.Text))
            {
                string updateQuery = "UPDATE Produto " +
                                    "SET ERP = @ERP, PRODUTO = @PRODUTO " +
                                    "WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ERP", cbxErp.Text);
                        command.Parameters.AddWithValue("@PRODUTO", txtProduto.Text);
                        command.Parameters.AddWithValue("@ID", txtIdProduto.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Dados do produto atualizados com sucesso!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Digite um ID válido para atualizar.");
            }
        }

        private void LimparCamposProduto()
        {
            txtIdProduto.Text = "";
            cbxErp.SelectedIndex = -1; // Limpa a seleção da ComboBox
            txtProduto.Text = "";
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdProduto.Text))
            {
                string deleteQuery = "DELETE FROM Produto WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", txtIdProduto.Text);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro de produto excluído com sucesso!");
                            LimparCamposProduto();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro encontrado para o ID especificado.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Digite um ID válido para excluir.");
            }
        }
    }
}
