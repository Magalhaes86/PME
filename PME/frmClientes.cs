using ComponentFactory.Krypton.Toolkit;
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
using MySqlX.XDevAPI.Relational;
using ComponentFactory.Krypton.Navigator;

namespace PME
{
    public partial class frmClientes : KryptonForm
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Port=3308;Database=PmeCrm;Uid=root;Pwd=xd;";


        private void frmClientes_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLabel14_Paint(object sender, PaintEventArgs e)
        {

        }


        private void GravarERP1()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO ERP1 (CodCliente, ERP, NPostos, NEmpresas, " +
                                     "Produto, Produto2, Produto3, Produto4, Produto5, " +
                                     "Produto1VersaoInstalada, Produto2VersaoInstalada, Produto3VersaoInstalada, Produto4VersaoInstalada, Produto5VersaoInstalada, " +
                                     "Produto1EstadoLic, Produto2EstadoLic, Produto3EstadoLic, Produto4EstadoLic, Produto5EstadoLic, " +
                                     "Produto1TecResponsa, Produto2TecResponsa, Produto3TecResponsa, Produto4TecResponsa, Produto5TecResponsa, " +
                                     "Produto1ModulosAddons, Produto1ModulosAddonsDescricao, Produto1Desenvolvimento, Produto1Desenvolvimentodescricao) " +
                                     "VALUES (@CodCliente, @ERP, @NPostos, @NEmpresas, " +
                                     "@Produto, @Produto2, @Produto3, @Produto4, @Produto5, " +
                                     "@Produto1VersaoInstalada, @Produto2VersaoInstalada, @Produto3VersaoInstalada, @Produto4VersaoInstalada, @Produto5VersaoInstalada, " +
                                     "@Produto1EstadoLic, @Produto2EstadoLic, @Produto3EstadoLic, @Produto4EstadoLic, @Produto5EstadoLic, " +
                                     "@Produto1TecResponsa, @Produto2TecResponsa, @Produto3TecResponsa, @Produto4TecResponsa, @Produto5TecResponsa, " +
                                     "@Produto1ModulosAddons, @Produto1ModulosAddonsDescricao, @Produto1Desenvolvimento, @Produto1Desenvolvimentodescricao);";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    // Adicione os parâmetros com os valores dos controles do formulário
                    command.Parameters.AddWithValue("@CodCliente", txtCodCliente.Text);
                    command.Parameters.AddWithValue("@ERP", cbx1ERP1.Text);
                    command.Parameters.AddWithValue("@NPostos", txt1Npostos1.Text);
                    command.Parameters.AddWithValue("@NEmpresas", txt1Nempresas1.Text);
                    command.Parameters.AddWithValue("@Produto", cbx1Produto1.Text);
                    command.Parameters.AddWithValue("@Produto2", cbx1Produto2.Text);
                    command.Parameters.AddWithValue("@Produto3", cbx1Produto3.Text);
                    command.Parameters.AddWithValue("@Produto4", cbx1Produto4.Text);
                    command.Parameters.AddWithValue("@Produto5", cbx1Produto5.Text);
                    command.Parameters.AddWithValue("@Produto1VersaoInstalada", txtVersao1Instalada1.Text);
                    command.Parameters.AddWithValue("@Produto2VersaoInstalada", txtVersao1Instalada2.Text);
                    command.Parameters.AddWithValue("@Produto3VersaoInstalada", txtVersao1Instalada3.Text);
                    command.Parameters.AddWithValue("@Produto4VersaoInstalada", txtVersao1Instalada4.Text);
                    command.Parameters.AddWithValue("@Produto5VersaoInstalada", txtVersao1Instalada5.Text);
                    command.Parameters.AddWithValue("@Produto1EstadoLic", cbEstado1Lic1.Text);
                    command.Parameters.AddWithValue("@Produto2EstadoLic", cbEstado1Lic2.Text);
                    command.Parameters.AddWithValue("@Produto3EstadoLic", cbEstado1Lic3.Text);
                    command.Parameters.AddWithValue("@Produto4EstadoLic", cbEstado1Lic4.Text);
                    command.Parameters.AddWithValue("@Produto5EstadoLic", cbEstado1Lic5.Text);
                    command.Parameters.AddWithValue("@Produto1TecResponsa", cbTecnico1Responsa1.Text);
                    command.Parameters.AddWithValue("@Produto2TecResponsa", cbTecnico1Responsa2.Text);
                    command.Parameters.AddWithValue("@Produto3TecResponsa", cbTecnico1Responsa3.Text);
                    command.Parameters.AddWithValue("@Produto4TecResponsa", cbTecnico1Responsa4.Text);
                    command.Parameters.AddWithValue("@Produto5TecResponsa", cbTecnico1Responsa5.Text);
                    command.Parameters.AddWithValue("@Produto1ModulosAddons", cbx1ModulosExtra1.Text);
                    command.Parameters.AddWithValue("@Produto1ModulosAddonsDescricao", cbx1Desenvolvimentos1.Text);
                    command.Parameters.AddWithValue("@Produto1Desenvolvimento", txt1DescricaoModulos1.Text);
                    command.Parameters.AddWithValue("@Produto1Desenvolvimentodescricao", txt1DescricaoDesenvolvimentos1.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Dados gravados com sucesso!");

                    // Agora, para obter o ID recém-inserido, você pode usar a função LAST_INSERT_ID()
                    string queryGetID = "SELECT LAST_INSERT_ID();";

                    using (MySqlCommand getIdCommand = new MySqlCommand(queryGetID, connection))
                    {
                        connection.Open();
                        int lastInsertedID = Convert.ToInt32(getIdCommand.ExecuteScalar());
                        connection.Close();

                        txtCodErp1.Text = lastInsertedID.ToString();
                    }
                }
            }
        }

        private void   GravarCliente()
            {
            string insertQuery = "INSERT INTO Clientes (Nif, Nome, NomeComercial, Tlm, TlmSecundario, Email, EmailSecundario, EstadoEmpresa, TecnicoResponsavel, TecnicoDeApoio, GestorDeConta, ERP, Produto, EstadoLicenca, Npostos, Nempresas, VersaoInstalada, ModulosExtra, Desenvolvimentos, DescricaoModulos, DescricaoDesenvolvimentos, OutrasInformacoes) " +
               "VALUES (@Nif, @Nome, @NomeComercial, @Tlm, @TlmSecundario, @Email, @EmailSecundario, @EstadoEmpresa, @TecnicoResponsavel, @TecnicoDeApoio, @GestorDeConta, @ERP, @ERP2, @ERP3;" +
               "SELECT LAST_INSERT_ID();"; // Recupera o ID gerado

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Nif", txtNif.Text);
                    command.Parameters.AddWithValue("@Nome", txtNome.Text);
                    command.Parameters.AddWithValue("@NomeComercial", txtNomeComercial.Text);
                    command.Parameters.AddWithValue("@Tlm", txtTlm.Text);
                    command.Parameters.AddWithValue("@TlmSecundario", txtTlmSecundario.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@EmailSecundario", txtEmailSecundario.Text);
                    command.Parameters.AddWithValue("@EstadoEmpresa", txtEstadoEmpresa.Text);
                    command.Parameters.AddWithValue("@TecnicoResponsavel", cbxTecnicoResponsavel.Text);
                    command.Parameters.AddWithValue("@TecnicoDeApoio", cbxTecnicoDeApoio.Text);
                    command.Parameters.AddWithValue("@GestorDeConta", txtGestorDeConta.Text);
                    command.Parameters.AddWithValue("@ERP", cbx1ERP1.Text);
                    command.Parameters.AddWithValue("@ERP2", cbxERP2.Text);
                    command.Parameters.AddWithValue("@ERP3", cbxERP3.Text);


                    //  command.Parameters.AddWithValue("@OutrasInformacoes", txtOutrasInformacoes.Text);

                    connection.Open();
                    int insertedId = Convert.ToInt32(command.ExecuteScalar()); // Recupera o ID gerado
                    connection.Close();

                    txtCodCliente.Text = insertedId.ToString(); // Exibe o ID gerado no campo txtCodCliente
                }
            }

            MessageBox.Show("Dados do cliente gravados com sucesso!");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
         
           
        }



        private void GravarERP2()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO ERP2 (CodCliente, ERP, NPostos, NEmpresas, " +
                                     "Produto, Produto2, Produto3, Produto4, Produto5, " +
                                     "Produto1VersaoInstalada, Produto2VersaoInstalada, Produto3VersaoInstalada, Produto4VersaoInstalada, Produto5VersaoInstalada, " +
                                     "Produto1EstadoLic, Produto2EstadoLic, Produto3EstadoLic, Produto4EstadoLic, Produto5EstadoLic, " +
                                     "Produto1TecResponsa, Produto2TecResponsa, Produto3TecResponsa, Produto4TecResponsa, Produto5TecResponsa, " +
                                     "Produto1ModulosAddons, Produto1ModulosAddonsDescricao, Produto1Desenvolvimento, Produto1Desenvolvimentodescricao) " +
                                     "VALUES (@CodCliente, @ERP, @NPostos, @NEmpresas, " +
                                     "@Produto, @Produto2, @Produto3, @Produto4, @Produto5, " +
                                     "@Produto1VersaoInstalada, @Produto2VersaoInstalada, @Produto3VersaoInstalada, @Produto4VersaoInstalada, @Produto5VersaoInstalada, " +
                                     "@Produto1EstadoLic, @Produto2EstadoLic, @Produto3EstadoLic, @Produto4EstadoLic, @Produto5EstadoLic, " +
                                     "@Produto1TecResponsa, @Produto2TecResponsa, @Produto3TecResponsa, @Produto4TecResponsa, @Produto5TecResponsa, " +
                                     "@Produto1ModulosAddons, @Produto1ModulosAddonsDescricao, @Produto1Desenvolvimento, @Produto1Desenvolvimentodescricao);";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    // Adicione os parâmetros com os valores dos controles do formulário
                    command.Parameters.AddWithValue("@CodCliente", txtCodCliente.Text);
                    command.Parameters.AddWithValue("@ERP", cbx2ERP2.Text);
                    command.Parameters.AddWithValue("@NPostos", txt2Npostos2.Text);
                    command.Parameters.AddWithValue("@NEmpresas", txt2Nempresas2.Text);
                    command.Parameters.AddWithValue("@Produto", cbx2Produto1.Text);
                    command.Parameters.AddWithValue("@Produto2", cbx2Produto2.Text);
                    command.Parameters.AddWithValue("@Produto3", cbx2Produto3.Text);
                    command.Parameters.AddWithValue("@Produto4", cbx2Produto4.Text);
                    command.Parameters.AddWithValue("@Produto5", cbx2Produto5.Text);
                    command.Parameters.AddWithValue("@Produto1VersaoInstalada", txtVersao2Instalada1.Text);
                    command.Parameters.AddWithValue("@Produto2VersaoInstalada", txtVersao2Instalada2.Text);
                    command.Parameters.AddWithValue("@Produto3VersaoInstalada", txtVersao2Instalada3.Text);
                    command.Parameters.AddWithValue("@Produto4VersaoInstalada", txtVersao2Instalada4.Text);
                    command.Parameters.AddWithValue("@Produto5VersaoInstalada", txtVersao2Instalada5.Text);
                    command.Parameters.AddWithValue("@Produto1EstadoLic", cbEstado2Lic1.Text);
                    command.Parameters.AddWithValue("@Produto2EstadoLic", cbEstado2Lic2.Text);
                    command.Parameters.AddWithValue("@Produto3EstadoLic", cbEstado2Lic3.Text);
                    command.Parameters.AddWithValue("@Produto4EstadoLic", cbEstado2Lic4.Text);
                    command.Parameters.AddWithValue("@Produto5EstadoLic", cbEstado2Lic5.Text);
                    command.Parameters.AddWithValue("@Produto1TecResponsa", cbTecnico2Responsa1.Text);
                    command.Parameters.AddWithValue("@Produto2TecResponsa", cbTecnico2Responsa2.Text);
                    command.Parameters.AddWithValue("@Produto3TecResponsa", cbTecnico2Responsa3.Text);
                    command.Parameters.AddWithValue("@Produto4TecResponsa", cbTecnico2Responsa4.Text);
                    command.Parameters.AddWithValue("@Produto5TecResponsa", cbTecnico2Responsa5.Text);
                    command.Parameters.AddWithValue("@Produto1ModulosAddons", cbx2ModulosExtra2.Text);
                    command.Parameters.AddWithValue("@Produto1ModulosAddonsDescricao", cbx2Desenvolvimentos2.Text);
                    command.Parameters.AddWithValue("@Produto1Desenvolvimento", txt2DescricaoModulos2.Text);
                    command.Parameters.AddWithValue("@Produto1Desenvolvimentodescricao", txt2DescricaoDesenvolvimentos2.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Dados gravados com sucesso!");

                    // Agora, para obter o ID recém-inserido, você pode usar a função LAST_INSERT_ID()
                    string queryGetID = "SELECT LAST_INSERT_ID();";

                    using (MySqlCommand getIdCommand = new MySqlCommand(queryGetID, connection))
                    {
                        connection.Open();
                        int lastInsertedID = Convert.ToInt32(getIdCommand.ExecuteScalar());
                        connection.Close();

                        txtCodErp2.Text = lastInsertedID.ToString();
                    }
                }
            }
        }


        private void GravarERP3()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO ERP3 (CodCliente, ERP, NPostos, NEmpresas, " +
                                     "Produto, Produto2, Produto3, Produto4, Produto5, " +
                                     "Produto1VersaoInstalada, Produto2VersaoInstalada, Produto3VersaoInstalada, Produto4VersaoInstalada, Produto5VersaoInstalada, " +
                                     "Produto1EstadoLic, Produto2EstadoLic, Produto3EstadoLic, Produto4EstadoLic, Produto5EstadoLic, " +
                                     "Produto1TecResponsa, Produto2TecResponsa, Produto3TecResponsa, Produto4TecResponsa, Produto5TecResponsa, " +
                                     "Produto1ModulosAddons, Produto1ModulosAddonsDescricao, Produto1Desenvolvimento, Produto1Desenvolvimentodescricao) " +
                                     "VALUES (@CodCliente, @ERP, @NPostos, @NEmpresas, " +
                                     "@Produto, @Produto2, @Produto3, @Produto4, @Produto5, " +
                                     "@Produto1VersaoInstalada, @Produto2VersaoInstalada, @Produto3VersaoInstalada, @Produto4VersaoInstalada, @Produto5VersaoInstalada, " +
                                     "@Produto1EstadoLic, @Produto2EstadoLic, @Produto3EstadoLic, @Produto4EstadoLic, @Produto5EstadoLic, " +
                                     "@Produto1TecResponsa, @Produto2TecResponsa, @Produto3TecResponsa, @Produto4TecResponsa, @Produto5TecResponsa, " +
                                     "@Produto1ModulosAddons, @Produto1ModulosAddonsDescricao, @Produto1Desenvolvimento, @Produto1Desenvolvimentodescricao);";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    // Adicione os parâmetros com os valores dos controles do formulário
                    command.Parameters.AddWithValue("@CodCliente", txtCodCliente.Text);
                    command.Parameters.AddWithValue("@ERP", cbx3ERP3.Text);
                    command.Parameters.AddWithValue("@NPostos", txt3Npostos3.Text);
                    command.Parameters.AddWithValue("@NEmpresas", txt3Nempresas3.Text);
                    command.Parameters.AddWithValue("@Produto", cbx3Produto1.Text);
                    command.Parameters.AddWithValue("@Produto2", cbx3Produto2.Text);
                    command.Parameters.AddWithValue("@Produto3", cbx3Produto3.Text);
                    command.Parameters.AddWithValue("@Produto4", cbx3Produto4.Text);
                    command.Parameters.AddWithValue("@Produto5", cbx3Produto5.Text);
                    command.Parameters.AddWithValue("@Produto1VersaoInstalada", txtVersao3Instalada1.Text);
                    command.Parameters.AddWithValue("@Produto2VersaoInstalada", txtVersao3Instalada2.Text);
                    command.Parameters.AddWithValue("@Produto3VersaoInstalada", txtVersao3Instalada3.Text);
                    command.Parameters.AddWithValue("@Produto4VersaoInstalada", txtVersao3Instalada4.Text);
                    command.Parameters.AddWithValue("@Produto5VersaoInstalada", txtVersao3Instalada5.Text);
                    command.Parameters.AddWithValue("@Produto1EstadoLic", cbEstado3Lic1.Text);
                    command.Parameters.AddWithValue("@Produto2EstadoLic", cbEstado3Lic2.Text);
                    command.Parameters.AddWithValue("@Produto3EstadoLic", cbEstado3Lic3.Text);
                    command.Parameters.AddWithValue("@Produto4EstadoLic", cbEstado3Lic4.Text);
                    command.Parameters.AddWithValue("@Produto5EstadoLic", cbEstado3Lic5.Text);
                    command.Parameters.AddWithValue("@Produto1TecResponsa", cbTecnico3Responsa1.Text);
                    command.Parameters.AddWithValue("@Produto2TecResponsa", cbTecnico3Responsa2.Text);
                    command.Parameters.AddWithValue("@Produto3TecResponsa", cbTecnico3Responsa3.Text);
                    command.Parameters.AddWithValue("@Produto4TecResponsa", cbTecnico3Responsa4.Text);
                    command.Parameters.AddWithValue("@Produto5TecResponsa", cbTecnico3Responsa5.Text);
                    command.Parameters.AddWithValue("@Produto1ModulosAddons", cbx3ModulosExtra3.Text);
                    command.Parameters.AddWithValue("@Produto1ModulosAddonsDescricao", cbx3Desenvolvimentos3.Text);
                    command.Parameters.AddWithValue("@Produto1Desenvolvimento", txt3DescricaoModulos3.Text);
                    command.Parameters.AddWithValue("@Produto1Desenvolvimentodescricao", txt3DescricaoDesenvolvimentos3.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Dados gravados com sucesso!");

                    // Agora, para obter o ID recém-inserido, você pode usar a função LAST_INSERT_ID()
                    string queryGetID = "SELECT LAST_INSERT_ID();";

                    using (MySqlCommand getIdCommand = new MySqlCommand(queryGetID, connection))
                    {
                        connection.Open();
                        int lastInsertedID = Convert.ToInt32(getIdCommand.ExecuteScalar());
                        connection.Close();

                        txtCodErp3.Text = lastInsertedID.ToString();
                    }
                }
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodCliente.Text))
            {
                string updateQuery = "UPDATE Clientes " +
                                    "SET Nif = @Nif, Nome = @Nome, NomeComercial = @NomeComercial, " +
                                    "Tlm = @Tlm, TlmSecundario = @TlmSecundario, " +
                                    "Email = @Email, EmailSecundario = @EmailSecundario, " +
                                    "EstadoEmpresa = @EstadoEmpresa, TecnicoResponsavel = @TecnicoResponsavel, " +
                                    "TecnicoDeApoio = @TecnicoDeApoio, GestorDeConta = @GestorDeConta, " +
                                    "ERP = @ERP, ERP2 = @ERP2, ERP3 = @ERP3" +                                   
                                    "WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Nif", txtNif.Text);
                        command.Parameters.AddWithValue("@Nome", txtNome.Text);
                        command.Parameters.AddWithValue("@NomeComercial", txtNomeComercial.Text);
                        command.Parameters.AddWithValue("@Tlm", txtTlm.Text);
                        command.Parameters.AddWithValue("@TlmSecundario", txtTlmSecundario.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@EmailSecundario", txtEmailSecundario.Text);
                        command.Parameters.AddWithValue("@EstadoEmpresa", txtEstadoEmpresa.Text);
                        command.Parameters.AddWithValue("@TecnicoResponsavel", cbxTecnicoResponsavel.Text);
                        command.Parameters.AddWithValue("@TecnicoDeApoio", cbxTecnicoDeApoio.Text);
                        command.Parameters.AddWithValue("@GestorDeConta", txtGestorDeConta.Text);
                        command.Parameters.AddWithValue("@ERP", cbx1ERP1.Text);
                        command.Parameters.AddWithValue("@ERP2", cbxERP2.Text);
                        command.Parameters.AddWithValue("@ERP3", cbxERP3.Text);
                       
                        command.Parameters.AddWithValue("@ID", txtCodCliente.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Dados do cliente atualizados com sucesso!");
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
            txtCodCliente.Text = "";
            txtNif.Text = "";
            txtNome.Text = "";
            txtNomeComercial.Text = "";
            txtTlm.Text = "";
            txtTlmSecundario.Text = "";
            txtEmail.Text = "";
            txtEmailSecundario.Text = "";
            txtEstadoEmpresa.Text = "";
            cbxTecnicoResponsavel.SelectedIndex = -1;
            cbxTecnicoDeApoio.SelectedIndex = -1;
            txtGestorDeConta.Text = "";
            cbx1ERP1.SelectedIndex = -1;
            cbx1Produto1.SelectedIndex = -1;
            cbEstado1Lic3.SelectedIndex = -1;
            txt1Npostos1.Text = "";
            txt1Nempresas1.Text = "";
            txtVersao1Instalada1.Text = "";
            cbx1ModulosExtra1.SelectedIndex = -1;
            cbx1Desenvolvimentos1.SelectedIndex = -1;
            txt1DescricaoModulos1.Text = "";
            txt1DescricaoDesenvolvimentos1.Text = "";


           // txtOutrasInformacoes.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodCliente.Text))
            {
                string deleteQuery = "DELETE FROM Clientes WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", txtCodCliente.Text);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro de cliente excluído com sucesso!");
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

     





        private void cbxERP_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxErp();
        }

        private void PreencherComboBoxErp()
        {

            cbx1ERP1.Items.Clear(); // Limpa os itens existentes na ComboBox

            HashSet<string> erpValues = new HashSet<string>(); // Usar um HashSet para armazenar valores únicos

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ERP FROM Produto"; // Sua consulta para obter os dados ERP

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string erpValue = reader.GetString("ERP");
                            if (!erpValues.Contains(erpValue)) // Verificar se o valor já existe no HashSet
                            {
                                erpValues.Add(erpValue); // Adicionar ao HashSet se não existir
                                cbx1ERP1.Items.Add(erpValue);
                            }
                        }
                    }
                }
            }          
        }




        private void PreencherComboBoxProduto()
        {
            cbx1Produto1.Items.Clear(); // Limpa os itens existentes na ComboBox

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT PRODUTO FROM Produto WHERE ERP = @ERP"; // Consulta modificada para incluir a cláusula WHERE

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ERP", cbx1ERP1.Text); // Use o valor atual da cbxERP
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbx1Produto1.Items.Add(reader.GetString("PRODUTO")); // Use GetString para obter o valor da coluna PRODUTO
                        }
                    }
                }
            }
        }


        private void cbxProduto_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxProduto();
        }


        private void PreencherComboBoxTecnicoResponsavel()
        {
            cbxTecnicoResponsavel.Items.Clear(); // Limpa os itens existentes na ComboBox

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
                            cbxTecnicoResponsavel.Items.Add(reader.GetString("Nome")); // Use GetString para obter o valor da coluna Nome
                        }
                    }
                }
            }
        }


        private void cbxTecnicoResponsavel_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxTecnicoResponsavel();
        }


        private void PreencherComboBoxTecnicoApoio()
        {
            cbxTecnicoDeApoio.Items.Clear(); // Limpa os itens existentes na ComboBox

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
                            cbxTecnicoDeApoio.Items.Add(reader.GetString("Nome")); // Use GetString para obter o valor da coluna Nome
                        }
                    }
                }
            }
        }

        private void cbxTecnicoDeApoio_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxTecnicoApoio();
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            // Primeiro, executa a função para gravar os dados do cliente
            GravarCliente();

            // Verifica se o campo ERP1 não está vazio
            if (!string.IsNullOrEmpty(cbx1ERP1.Text))
            {
                GravarERP1();
            }

            // Verifica se o campo ERP2 não está vazio
            if (!string.IsNullOrEmpty(cbxERP2.Text))
            {
                GravarERP2();
            }

            // Verifica se o campo ERP3 não está vazio
            if (!string.IsNullOrEmpty(cbxERP3.Text))
            {
                GravarERP3();
            }
        }

        private void cbxERP1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            tbErp1.Enabled = true;

            KryptonPage pageToSelect = kryptonDockableNavigator1.Pages["tbErp1"];

            if (pageToSelect != null)
            {
                kryptonDockableNavigator1.SelectedPage = pageToSelect;
            }

            cbx1ERP1.Text = cbxERP1.Text;
           
            txt1Npostos1.Focus();

     



        }

        private void cbx1ERP1_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxErp();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            cbxERP2.Enabled = true; 
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            cbxERP3.Enabled = true; 
        }

        private void cbxERP1_DropDown(object sender, EventArgs e)
        {

        }

        private void cbxERP2_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxErp();
        }

        private void cbxERP3_DropDown(object sender, EventArgs e)
        {
            PreencherComboBoxErp();
        }

        private void cbxERP2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbERP2.Enabled = true;

            KryptonPage pageToSelect = kryptonDockableNavigator1.Pages["tbERP2"];

            if (pageToSelect != null)
            {
                kryptonDockableNavigator1.SelectedPage = pageToSelect;
            }

            cbx2ERP2.Text = cbxERP2.Text;
            txt2Npostos2.Focus();
        }

        private void cbxERP3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbErp3.Enabled = true;
            KryptonPage pageToSelect = kryptonDockableNavigator1.Pages["tbErp3"];

            if (pageToSelect != null)
            {
                kryptonDockableNavigator1.SelectedPage = pageToSelect;
            }

            cbx3ERP3.Text = cbxERP3.Text;
            txt3Npostos3.Focus();
        }
    }
    }

