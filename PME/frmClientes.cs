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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //string insertQuery = "INSERT INTO Clientes (Nif, Nome, NomeComercial, Tlm, TlmSecundario, Email, EmailSecundario, EstadoEmpresa, TecnicoResponsavel, TecnicoDeApoio, GestorDeConta, ERP, Produto, EstadoLicenca, Npostos, Nempresas, VersaoInstalada, ModulosExtra, Desenvolvimentos, DescricaoModulos, DescricaoDesenvolvimentos, OutrasInformacoes) " +
            //           "VALUES (@Nif, @Nome, @NomeComercial, @Tlm, @TlmSecundario, @Email, @EmailSecundario, @EstadoEmpresa, @TecnicoResponsavel, @TecnicoDeApoio, @GestorDeConta, @ERP, @Produto, @EstadoLicenca, @Npostos, @Nempresas, @VersaoInstalada, @ModulosExtra, @Desenvolvimentos, @DescricaoModulos, @DescricaoDesenvolvimentos, @OutrasInformacoes)";

            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            //{
            //    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
            //    {
            //        command.Parameters.AddWithValue("@Nif", txtNif.Text);
            //        command.Parameters.AddWithValue("@Nome", txtNome.Text);
            //        command.Parameters.AddWithValue("@NomeComercial", txtNomeComercial.Text);
            //        command.Parameters.AddWithValue("@Tlm", txtTlm.Text);
            //        command.Parameters.AddWithValue("@TlmSecundario", txtTlmSecundario.Text);
            //        command.Parameters.AddWithValue("@Email", txtEmail.Text);
            //        command.Parameters.AddWithValue("@EmailSecundario", txtEmailSecundario.Text);
            //        command.Parameters.AddWithValue("@EstadoEmpresa", txtEstadoEmpresa.Text);
            //        command.Parameters.AddWithValue("@TecnicoResponsavel", cbxTecnicoResponsavel.Text);
            //        command.Parameters.AddWithValue("@TecnicoDeApoio", cbxTecnicoDeApoio.Text);
            //        command.Parameters.AddWithValue("@GestorDeConta", txtGestorDeConta.Text);
            //        command.Parameters.AddWithValue("@ERP", cbxERP.Text);
            //        command.Parameters.AddWithValue("@Produto", cbxProduto.Text);
            //        command.Parameters.AddWithValue("@EstadoLicenca", cbxEstadoLicenca.Text);
            //        command.Parameters.AddWithValue("@Npostos", txtNpostos.Text);
            //        command.Parameters.AddWithValue("@Nempresas", txtNempresas.Text);
            //        command.Parameters.AddWithValue("@VersaoInstalada", txtVersaoInstalada.Text);
            //        command.Parameters.AddWithValue("@ModulosExtra", cbxModulosExtra.Text);
            //        command.Parameters.AddWithValue("@Desenvolvimentos", cbxDesenvolvimentos.Text);
            //        command.Parameters.AddWithValue("@DescricaoModulos", txtDescricaoModulos.Text);
            //        command.Parameters.AddWithValue("@DescricaoDesenvolvimentos", txtDescricaoDesenvolvimentos.Text);
            //        command.Parameters.AddWithValue("@OutrasInformacoes", txtOutrasInformacoes.Text);

            //        connection.Open();
            //        command.ExecuteNonQuery();
            //        connection.Close();
            //    }
            //}

            //MessageBox.Show("Dados do cliente gravados com sucesso!");

            string insertQuery = "INSERT INTO Clientes (Nif, Nome, NomeComercial, Tlm, TlmSecundario, Email, EmailSecundario, EstadoEmpresa, TecnicoResponsavel, TecnicoDeApoio, GestorDeConta, ERP, Produto, EstadoLicenca, Npostos, Nempresas, VersaoInstalada, ModulosExtra, Desenvolvimentos, DescricaoModulos, DescricaoDesenvolvimentos, OutrasInformacoes) " +
                "VALUES (@Nif, @Nome, @NomeComercial, @Tlm, @TlmSecundario, @Email, @EmailSecundario, @EstadoEmpresa, @TecnicoResponsavel, @TecnicoDeApoio, @GestorDeConta, @ERP, @Produto, @EstadoLicenca, @Npostos, @Nempresas, @VersaoInstalada, @ModulosExtra, @Desenvolvimentos, @DescricaoModulos, @DescricaoDesenvolvimentos, @OutrasInformacoes);" +
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
                    command.Parameters.AddWithValue("@ERP", cbxERP.Text);
                    command.Parameters.AddWithValue("@Produto", cbxProduto.Text);
                    command.Parameters.AddWithValue("@EstadoLicenca", cbxEstadoLicenca.Text);
                    command.Parameters.AddWithValue("@Npostos", txtNpostos.Text);
                    command.Parameters.AddWithValue("@Nempresas", txtNempresas.Text);
                    command.Parameters.AddWithValue("@VersaoInstalada", txtVersaoInstalada.Text);
                    command.Parameters.AddWithValue("@ModulosExtra", cbxModulosExtra.Text);
                    command.Parameters.AddWithValue("@Desenvolvimentos", cbxDesenvolvimentos.Text);
                    command.Parameters.AddWithValue("@DescricaoModulos", txtDescricaoModulos.Text);
                    command.Parameters.AddWithValue("@DescricaoDesenvolvimentos", txtDescricaoDesenvolvimentos.Text);


                  //  command.Parameters.AddWithValue("@OutrasInformacoes", txtOutrasInformacoes.Text);

                    connection.Open();
                    int insertedId = Convert.ToInt32(command.ExecuteScalar()); // Recupera o ID gerado
                    connection.Close();

                    txtCodCliente.Text = insertedId.ToString(); // Exibe o ID gerado no campo txtCodCliente
                }
            }

            MessageBox.Show("Dados do cliente gravados com sucesso!");
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
                                    "ERP = @ERP, Produto = @Produto, EstadoLicenca = @EstadoLicenca, " +
                                    "Npostos = @Npostos, Nempresas = @Nempresas, " +
                                    "VersaoInstalada = @VersaoInstalada, ModulosExtra = @ModulosExtra, " +
                                    "Desenvolvimentos = @Desenvolvimentos, " +
                                    "DescricaoModulos = @DescricaoModulos, DescricaoDesenvolvimentos = @DescricaoDesenvolvimentos, " +
                                    "OutrasInformacoes = @OutrasInformacoes " +
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
                        command.Parameters.AddWithValue("@ERP", cbxERP.Text);
                        command.Parameters.AddWithValue("@Produto", cbxProduto.Text);
                        command.Parameters.AddWithValue("@EstadoLicenca", cbxEstadoLicenca.Text);
                        command.Parameters.AddWithValue("@Npostos", txtNpostos.Text);
                        command.Parameters.AddWithValue("@Nempresas", txtNempresas.Text);
                        command.Parameters.AddWithValue("@VersaoInstalada", txtVersaoInstalada.Text);
                        command.Parameters.AddWithValue("@ModulosExtra", cbxModulosExtra.Text);
                        command.Parameters.AddWithValue("@Desenvolvimentos", cbxDesenvolvimentos.Text);
                        command.Parameters.AddWithValue("@DescricaoModulos", txtDescricaoModulos.Text);
                        command.Parameters.AddWithValue("@DescricaoDesenvolvimentos", txtDescricaoDesenvolvimentos.Text);
                    //    command.Parameters.AddWithValue("@OutrasInformacoes", txtOutrasInformacoes.Text);
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
            cbxERP.SelectedIndex = -1;
            cbxProduto.SelectedIndex = -1;
            cbxEstadoLicenca.SelectedIndex = -1;
            txtNpostos.Text = "";
            txtNempresas.Text = "";
            txtVersaoInstalada.Text = "";
            cbxModulosExtra.SelectedIndex = -1;
            cbxDesenvolvimentos.SelectedIndex = -1;
            txtDescricaoModulos.Text = "";
            txtDescricaoDesenvolvimentos.Text = "";


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

            cbxERP.Items.Clear(); // Limpa os itens existentes na ComboBox

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
                                cbxERP.Items.Add(erpValue);
                            }
                        }
                    }
                }
            }          
        }




        private void PreencherComboBoxProduto()
        {
            cbxProduto.Items.Clear(); // Limpa os itens existentes na ComboBox

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT PRODUTO FROM Produto WHERE ERP = @ERP"; // Consulta modificada para incluir a cláusula WHERE

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ERP", cbxERP.Text); // Use o valor atual da cbxERP
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbxProduto.Items.Add(reader.GetString("PRODUTO")); // Use GetString para obter o valor da coluna PRODUTO
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
    }
}
