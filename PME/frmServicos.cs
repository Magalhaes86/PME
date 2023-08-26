using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PME
{
    public partial class frmServicos : Form
    {
        public frmServicos()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Port=3308;Database=PmeCrm;Uid=root;Pwd=xd;";

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Servicos (Servico) VALUES (@Servico); SELECT LAST_INSERT_ID();";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Servico", txtServico.Text);

                    connection.Open();
                    int id = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();

                    txtID.Text = id.ToString(); // Mostrar o ID na txtID
                }
            }

            MessageBox.Show("Serviço gravado com sucesso!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                int id = Convert.ToInt32(txtID.Text);
                string updateQuery = "UPDATE Servicos SET Servico = @Servico WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Servico", txtServico.Text);
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
    }
}

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                int id = Convert.ToInt32(txtID.Text);
                string deleteQuery = "DELETE FROM Servicos WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Serviço excluído com sucesso!");
                            LimparCampos(); // Chamada à função para limpar os campos após a exclusão
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