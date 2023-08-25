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
    public partial class frmVisita : KryptonForm
    {
        public frmVisita()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Port=3308;Database=PmeCrm;Uid=root;Pwd=xd;";


        private void frmVisita_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Visita (Consultor, NomeCliente, RecebidoPor, Assunto, OutrosTemas, Obs, IDCliente, IDConsultor, Data, HoraInicio, HoraFim, Tempo) " +
                      "VALUES (@Consultor, @NomeCliente, @RecebidoPor, @Assunto, @OutrosTemas, @Obs, @IDCliente, @IDConsultor, @Data, @HoraInicio, @HoraFim, @Tempo);" +
                      "SELECT LAST_INSERT_ID();"; // Recupera o ID gerado

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Consultor", txtConsultor.Text);
                    command.Parameters.AddWithValue("@NomeCliente", txtNomeCliente.Text);
                    command.Parameters.AddWithValue("@RecebidoPor", txtRecebidoPor.Text);
                    command.Parameters.AddWithValue("@Assunto", txtAssunto.Text);
                    command.Parameters.AddWithValue("@OutrosTemas", txtOutrosTemas.Text);
                    command.Parameters.AddWithValue("@Obs", txtObs.Text);
                    command.Parameters.AddWithValue("@IDCliente", txtIDCliente.Text);
                    command.Parameters.AddWithValue("@IDConsultor", txtIDConsultor.Text);
                    command.Parameters.AddWithValue("@Data", dtpDataVisita.Value.Date);
                    command.Parameters.AddWithValue("@HoraInicio", dtpHoraInicio.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@HoraFim", dtpHoraFim.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Tempo", decimal.Parse(txtTempo.Text));

                    connection.Open();
                    int insertedId = Convert.ToInt32(command.ExecuteScalar()); // Recupera o ID gerado
                    connection.Close();

                    txtCodVisita.Text = insertedId.ToString(); // Exibe o ID gerado no campo txtCodVisita
                }
            }

            MessageBox.Show("Dados de visita gravados com sucesso!");

            //    string query = "INSERT INTO Visita (Consultor, NomeCliente, RecebidoPor, Assunto, OutrosTemas, Obs, IDCliente, IDConsultor, Data, HoraInicio, HoraFim, Tempo) " +
            //         "VALUES (@Consultor, @NomeCliente, @RecebidoPor, @Assunto, @OutrosTemas, @Obs, @IDCliente, @IDConsultor, @Data, @HoraInicio, @HoraFim, @Tempo)";

            //    using (MySqlConnection connection = new MySqlConnection(connectionString))
            //    {
            //        using (MySqlCommand command = new MySqlCommand(query, connection))
            //        {
            //            command.Parameters.AddWithValue("@Consultor", txtConsultor.Text);
            //            command.Parameters.AddWithValue("@NomeCliente", txtNomeCliente.Text);
            //            command.Parameters.AddWithValue("@RecebidoPor", txtRecebidoPor.Text);
            //            command.Parameters.AddWithValue("@Assunto", txtAssunto.Text);
            //            command.Parameters.AddWithValue("@OutrosTemas", txtOutrosTemas.Text);
            //            command.Parameters.AddWithValue("@Obs", txtObs.Text);
            //            command.Parameters.AddWithValue("@IDCliente", txtIDCliente.Text);
            //            command.Parameters.AddWithValue("@IDConsultor", txtIDConsultor.Text);
            //            command.Parameters.AddWithValue("@Data", dtpDataVisita.Value.Date);
            //            command.Parameters.AddWithValue("@HoraInicio", dtpHoraInicio.Value.TimeOfDay);
            //            command.Parameters.AddWithValue("@HoraFim", dtpHoraFim.Value.TimeOfDay);
            //            command.Parameters.AddWithValue("@Tempo", decimal.Parse(txtTempo.Text));

            //            connection.Open();
            //            command.ExecuteNonQuery();
            //            connection.Close();
            //        }
            //    }

            //    MessageBox.Show("Dados de visita gravados com sucesso!");
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodVisita.Text))
            {
                string updateQuery = "UPDATE Visita " +
                                    "SET Consultor = @Consultor, NomeCliente = @NomeCliente, RecebidoPor = @RecebidoPor, " +
                                    "Assunto = @Assunto, OutrosTemas = @OutrosTemas, Obs = @Obs, " +
                                    "IDCliente = @IDCliente, IDConsultor = @IDConsultor, " +
                                    "Data = @Data, HoraInicio = @HoraInicio, HoraFim = @HoraFim, Tempo = @Tempo " +
                                    "WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Consultor", txtConsultor.Text);
                        command.Parameters.AddWithValue("@NomeCliente", txtNomeCliente.Text);
                        command.Parameters.AddWithValue("@RecebidoPor", txtRecebidoPor.Text);
                        command.Parameters.AddWithValue("@Assunto", txtAssunto.Text);
                        command.Parameters.AddWithValue("@OutrosTemas", txtOutrosTemas.Text);
                        command.Parameters.AddWithValue("@Obs", txtObs.Text);
                        command.Parameters.AddWithValue("@IDCliente", txtIDCliente.Text);
                        command.Parameters.AddWithValue("@IDConsultor", txtIDConsultor.Text);
                        command.Parameters.AddWithValue("@Data", dtpDataVisita.Value.Date);
                        command.Parameters.AddWithValue("@HoraInicio", dtpHoraInicio.Value.TimeOfDay);
                        command.Parameters.AddWithValue("@HoraFim", dtpHoraFim.Value.TimeOfDay);
                        command.Parameters.AddWithValue("@Tempo", decimal.Parse(txtTempo.Text));
                        command.Parameters.AddWithValue("@ID", txtCodVisita.Text);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dados de visita atualizados com sucesso!");
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
                MessageBox.Show("Digite um ID válido para atualizar.");
            }
        }


        private void LimparCampos()
        {
            txtCodVisita.Text = "";
            txtConsultor.Text = "";
            txtNomeCliente.Text = "";
            txtRecebidoPor.Text = "";
            txtAssunto.Text = "";
            txtOutrosTemas.Text = "";
            txtObs.Text = "";
            txtIDCliente.Text = "";
            txtIDConsultor.Text = "";
            dtpDataVisita.Value = DateTime.Now;
            dtpHoraInicio.Value = DateTime.Now;
            dtpHoraFim.Value = DateTime.Now;
            txtTempo.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodVisita.Text))
            {
                string deleteQuery = "DELETE FROM Visita WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", txtCodVisita.Text);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro de visita excluído com sucesso!");
                            LimparCampos();
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