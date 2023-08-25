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
using System.Globalization;
using MySqlX.XDevAPI;
using System.CodeDom.Compiler;
using System.Runtime.ConstrainedExecution;

namespace PME
{
    public partial class frmEquipa : KryptonForm
    {
        public frmEquipa()
        {
            InitializeComponent();
        }


        private string connectionString = "Server=localhost;Port=3308;Database=PmeCrm;Uid=root;Pwd=xd;";


        private void ListarEquipas()
        {
            string query = "SELECT * FROM Equipa";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        System.Data.DataTable dataTable = new System.Data.DataTable();
                        adapter.Fill(dataTable);

                        dtgDados.DataSource = dataTable; // Preenche o DataGridView com os dados
                    }

                    connection.Close();
                }
            }
        }


        private void frmEquipa_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLabel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            string insertQuery = "INSERT INTO Equipa (Nome, Especialidades, Tlm, Email, Obs) " +
                        "VALUES (@Nome, @Especialidades, @Tlm, @Email, @Obs);" +
                        "SELECT LAST_INSERT_ID();"; // Recupera o ID gerado

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Nome", txtNome.Text);
                    command.Parameters.AddWithValue("@Especialidades", txtEspecialidade.Text);
                    command.Parameters.AddWithValue("@Tlm", txtTlm.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Obs", txtObs.Text);

                    connection.Open();
                    int insertedId = Convert.ToInt32(command.ExecuteScalar()); // Recupera o ID gerado
                    connection.Close();

                    txtCod.Text = insertedId.ToString(); // Exibe o ID gerado no campo txtCod
                }
            }

            MessageBox.Show("Dados gravados com sucesso!");

            ListarEquipas();

            //string query = "INSERT INTO Equipa (Nome, Especialidades, Tlm, Email, Obs) " +
            //     "VALUES (@Nome, @Especialidades, @Tlm, @Email, @Obs)";

            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            //{
            //    using (MySqlCommand command = new MySqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Nome", txtNome.Text);
            //        command.Parameters.AddWithValue("@Especialidades", txtEspecialidade.Text);
            //        command.Parameters.AddWithValue("@Tlm", txtTlm.Text);
            //        command.Parameters.AddWithValue("@Email", txtEmail.Text);
            //        command.Parameters.AddWithValue("@Obs", txtObs.Text);

            //        connection.Open();
            //        command.ExecuteNonQuery();
            //        connection.Close();
            //    }
            //}

            //MessageBox.Show("Dados gravados com sucesso!");
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Equipa " +
                  "SET Nome = @Nome, Especialidades = @Especialidades, Tlm = @Tlm, " +
                  "Email = @Email, Obs = @Obs " +
                  "WHERE ID = @ID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", txtNome.Text);
                    command.Parameters.AddWithValue("@Especialidades", txtEspecialidade.Text);
                    command.Parameters.AddWithValue("@Tlm", txtTlm.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Obs", txtObs.Text);
                    command.Parameters.AddWithValue("@ID", txtCod.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            ListarEquipas();
        }


        private void LimparCampos()
        {
            txtCod.Text = "";
            txtNome.Text = "";
            txtEspecialidade.Text = "";
            txtTlm.Text = "";
            txtEmail.Text = "";
            txtObs.Text = "";
        }
       

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCod.Text))
            {
                string query = "DELETE FROM Equipa WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", txtCod.Text);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro excluído com sucesso!");
                            LimparCampos();
                            ListarEquipas();
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
