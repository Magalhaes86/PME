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
    public partial class frmAtualizacoes : Form
    {
        public frmAtualizacoes()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Port=3308;Database=PmeCrm;Uid=root;Pwd=xd;";

        private void frmAtualizacoes_Load(object sender, EventArgs e)
        {

        }


        private void LimparCampos()
        {
            txtIDCliente.Clear();
            txtNomeCliente.Clear();
            txtNomeComercial.Clear();
            txtIDConsultorPreferencial.Clear();
            txtNomeConsultor.Clear();
            txtIDConsultorAssistencia.Clear();
            cbxConsultorAssistencia.SelectedIndex = -1;
            dtpDataContato.Value = DateTime.Now;
            dtpDataAgendamento.Value = DateTime.Now;
            txtIdServico.Clear();
            cbxTipoServico.SelectedIndex = -1;
            txtVersaoAtualizada.Clear();
            dtpDataAssistencia.Value = DateTime.Now;
            txtObservacoes.Clear();
            txtAspetosEmConsideracao.Clear();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO assistencia (IDCliente, NomeCliente, NomeComercial, IDConsultorPreferencial, NomeConsultorPreferencial, IDConsultorAssistencia, NomeConsultorAssistencia, DataContato, DataAgendamento, IDTipoServico, TipoServico, VersaoInstalada, DataAtualizacao, Observacoes, AspetosEmConsideracao) " +
                    "VALUES (@IDCliente, @NomeCliente, @NomeComercial, @IDConsultorPreferencial, @NomeConsultorPreferencial, @IDConsultorAssistencia, @NomeConsultorAssistencia, @DataContato, @DataAgendamento, @IDTipoServico, @TipoServico, @VersaoInstalada, @DataAtualizacao, @Observacoes, @AspetosEmConsideracao)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@IDCliente", Convert.ToInt32(txtIDCliente.Text));
                    command.Parameters.AddWithValue("@NomeCliente", txtNomeCliente.Text);
                    command.Parameters.AddWithValue("@NomeComercial", txtNomeComercial.Text);
                    command.Parameters.AddWithValue("@IDConsultorPreferencial", Convert.ToInt32(txtIDConsultorPreferencial.Text));
                    command.Parameters.AddWithValue("@NomeConsultorPreferencial", txtNomeConsultor.Text);
                    command.Parameters.AddWithValue("@IDConsultorAssistencia", Convert.ToInt32(txtIDConsultorAssistencia.Text));
                    command.Parameters.AddWithValue("@NomeConsultorAssistencia", cbxConsultorAssistencia.Text);
                    command.Parameters.AddWithValue("@DataContato", dtpDataContato.Value);
                    command.Parameters.AddWithValue("@DataAgendamento", dtpDataAgendamento.Value);
                    command.Parameters.AddWithValue("@IDTipoServico", Convert.ToInt32(txtIdServico.Text));
                    command.Parameters.AddWithValue("@TipoServico", cbxTipoServico.Text);
                    command.Parameters.AddWithValue("@VersaoInstalada", txtVersaoAtualizada.Text);
                    command.Parameters.AddWithValue("@DataAtualizacao", dtpDataAssistencia.Value);
                    command.Parameters.AddWithValue("@Observacoes", txtObservacoes.Text);
                    command.Parameters.AddWithValue("@AspetosEmConsideracao", txtAspetosEmConsideracao.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            int lastInsertedId;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    lastInsertedId = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
            }

            txtCodAtualizacao.Text = lastInsertedId.ToString();

            MessageBox.Show("Dados de atualização gravados com sucesso!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodAtualizacao.Text))
            {
                string updateQuery = "UPDATE assistencia " +
                                    "SET IDCliente = @IDCliente, NomeCliente = @NomeCliente, NomeComercial = @NomeComercial, " +
                                    "IDConsultorPreferencial = @IDConsultorPreferencial, NomeConsultorPreferencial = @NomeConsultorPreferencial, " +
                                    "IDConsultorAssistencia = @IDConsultorAssistencia, NomeConsultorAssistencia = @NomeConsultorAssistencia, " +
                                    "DataContato = @DataContato, DataAgendamento = @DataAgendamento, " +
                                    "IDTipoServico = @IDTipoServico, TipoServico = @TipoServico, " +
                                    "VersaoInstalada = @VersaoInstalada, DataAtualizacao = @DataAtualizacao, " +
                                    "Observacoes = @Observacoes, AspetosEmConsideracao = @AspetosEmConsideracao " +
                                    "WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IDCliente", txtIDCliente.Text);
                        command.Parameters.AddWithValue("@NomeCliente", txtNomeCliente.Text);
                        command.Parameters.AddWithValue("@NomeComercial", txtNomeComercial.Text);
                        command.Parameters.AddWithValue("@IDConsultorPreferencial", txtIDConsultorPreferencial.Text);
                        command.Parameters.AddWithValue("@NomeConsultorPreferencial", txtNomeConsultor.Text);
                        command.Parameters.AddWithValue("@IDConsultorAssistencia", txtIDConsultorAssistencia.Text);
                        command.Parameters.AddWithValue("@NomeConsultorAssistencia", cbxConsultorAssistencia.Text);
                        command.Parameters.AddWithValue("@DataContato", dtpDataContato.Value);
                        command.Parameters.AddWithValue("@DataAgendamento", dtpDataAgendamento.Value);
                        command.Parameters.AddWithValue("@IDTipoServico", txtIdServico.Text);
                        command.Parameters.AddWithValue("@TipoServico", cbxTipoServico.Text);
                        command.Parameters.AddWithValue("@VersaoInstalada", txtVersaoAtualizada.Text);
                        command.Parameters.AddWithValue("@DataAtualizacao", dtpDataAssistencia.Value);
                        command.Parameters.AddWithValue("@Observacoes", txtObservacoes.Text);
                        command.Parameters.AddWithValue("@AspetosEmConsideracao", txtAspetosEmConsideracao.Text);
                        command.Parameters.AddWithValue("@ID", txtCodAtualizacao.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Dados de atualização atualizados com sucesso!");
                       // LimparCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Digite um ID válido para atualizar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodAtualizacao.Text))
            {
                string deleteQuery = "DELETE FROM assistencia WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", txtCodAtualizacao.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Dados de atualização eliminados com sucesso!");
                        LimparCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Digite um ID válido para eliminar.");
            }
        }


        private void PreencherComboBoxTecnicoResponsavel()
        {
            cbxConsultorAssistencia.Items.Clear(); // Limpa os itens existentes na ComboBox

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Nome FROM Equipa"; // Sua consulta para obter os nomes da equipe

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbxConsultorAssistencia.Items.Add(reader.GetString("Nome")); // Use GetString para obter o valor da coluna Nome
                        }
                    }
                }
            }
        }

        private void cbxConsultorAssistencia_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxTecnicoResponsavel();
        }



        private void PreencherComboBoxServico()
        {
            cbxConsultorAssistencia.Items.Clear(); // Limpa os itens existentes na ComboBox

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Servico FROM servicos"; // Sua consulta para obter os nomes da equipe

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbxConsultorAssistencia.Items.Add(reader.GetString("Servico")); // Use GetString para obter o valor da coluna Nome
                        }
                    }
                }
            }
        }

        

            

        private void cbxTipoServico_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxServico();
        }
    }
}
