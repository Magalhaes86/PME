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
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using MySqlX.XDevAPI.Relational;
using System.Transactions;
using System.IO;

namespace PME
{
    public partial class frmIntegrador : Form
    {
        public frmIntegrador()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Port=3308;Database=PmeCrm;Uid=root;Pwd=xd;";

        private void kryptonHeader1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInportarClientes_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos Excel|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (var workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1); // Assume que os dados estão na primeira planilha

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("NomeCliente");
                    dataTable.Columns.Add("Email");
                    dataTable.Columns.Add("NIF");
                    dataTable.Columns.Add("ERP");
                    dataTable.Columns.Add("Código Aplicação");                    
                    dataTable.Columns.Add("Postos");
                    dataTable.Columns.Add("Empresas");
                    dataTable.Columns.Add("Módulos");
                    dataTable.Columns.Add("Activada");
                    dataTable.Columns.Add("DESENVOLVIMENTO ESPECIFICO");
                    dataTable.Columns.Add("Consultor Preferêncial");

                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1)) // Ignorar a primeira linha de cabeçalho
                    {
                        string nomeCliente = row.Cell("A").Value.ToString();
                        string Email = row.Cell("B").Value.ToString();
                        string NIF = row.Cell("D").Value.ToString();
                        string ERP = row.Cell("F").Value.ToString();
                        string codigoAplicacao = row.Cell("G").Value.ToString();
                        string Postos = row.Cell("J").Value.ToString();
                        string Empresas = row.Cell("K").Value.ToString();
                        string Modulos = row.Cell("L").Value.ToString();
                        string Activada = row.Cell("M").Value.ToString();
                        string DESENVOLVIMENTO = row.Cell("N").Value.ToString();
                        string Consultor = row.Cell("R").Value.ToString();

                        dataTable.Rows.Add(nomeCliente, Email, NIF,ERP,codigoAplicacao,Postos,Empresas,Modulos,Activada,DESENVOLVIMENTO,Consultor);
                    }

                    kryptonDataGridView2.DataSource = dataTable;
                }

                MessageBox.Show("Dados importados com sucesso e exibidos no DataGridView!");
            }
        }

        private int GetClientIdByNIF(MySqlConnection connection, MySqlTransaction transaction, string nif)
        {
            string selectQuery = "SELECT ID FROM Clientes WHERE NIF = @NIF";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
            {
                selectCommand.Parameters.AddWithValue("@NIF", nif);
                selectCommand.Transaction = transaction;

                object result = selectCommand.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                return -1; // NIF não existe na tabela
            }
        }

        private int InsertCliente(MySqlConnection connection, MySqlTransaction transaction, DataRow row)
        {
            string insertQuery = "INSERT INTO Clientes (Nome, Email, NIF, ERP) VALUES (@Nome, @Email, @NIF, @ERP); SELECT LAST_INSERT_ID();";
            using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@Nome", row["NomeCliente"]);
                insertCommand.Parameters.AddWithValue("@Email", row["Email"]);
                insertCommand.Parameters.AddWithValue("@NIF", row["NIF"]);
                insertCommand.Parameters.AddWithValue("@ERP", row["ERP"]);
                insertCommand.Transaction = transaction;

                int clientId = Convert.ToInt32(insertCommand.ExecuteScalar());
                return clientId;
            }
        }

        private void UpdateCliente(MySqlConnection connection, MySqlTransaction transaction, int clientId, DataRow row)
        {
            string updateQuery = "UPDATE Clientes SET Nome = @Nome, Email = @Email, ERP = @ERP WHERE ID = @ID";
            using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@ID", clientId);
                updateCommand.Parameters.AddWithValue("@Nome", row["NomeCliente"]);
                updateCommand.Parameters.AddWithValue("@Email", row["Email"]);
                updateCommand.Parameters.AddWithValue("@ERP", row["ERP"]);
                updateCommand.Transaction = transaction;

                updateCommand.ExecuteNonQuery();
            }
        }


        private void InsertOrUpdateERP(MySqlConnection connection, MySqlTransaction transaction, int clientId, DataRow row)
        {
            string selectQuery = "SELECT ID FROM erp1 WHERE CodCliente = @CodCliente";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
            {
                selectCommand.Parameters.AddWithValue("@CodCliente", clientId);
                selectCommand.Transaction = transaction;

                object result = selectCommand.ExecuteScalar();

                string[] produtoColumns = new string[] { "Produto", "Produto2", "Produto3", "Produto4", "Produto5" };

                for (int i = 0; i < produtoColumns.Length; i++)
                {
                    string produtoColumn = produtoColumns[i];
                    string estadoLicColumn = $"{produtoColumn}EstadoLic";
                    string tecResponsaColumn = $"{produtoColumn}TecResponsa";

                    string produto = row[produtoColumn]?.ToString();
                    string codigoAplicacao = row["Código Aplicação"].ToString();  // Getting the value directly from the DataTable

                    if (produto == null)
                    {
                        string insertQuery = $"INSERT INTO erp1 (CodCliente, {produtoColumn}, NPostos{i + 1}, NEmpresas{i + 1}, {produtoColumn}{i + 1}ModulosAddonsDescricao, " +
                                             $"{produtoColumn}{i + 1}Desenvolvimentodescricao, {estadoLicColumn}, {tecResponsaColumn}) " +
                                             $"VALUES (@CodCliente, @Produto, @NPostos, @NEmpresas, @Modulos, @Desenvolvimento, @EstadoLicenca, @TecResponsavel)";

                        using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CodCliente", clientId);
                            command.Parameters.AddWithValue("@Produto", codigoAplicacao);
                            command.Parameters.AddWithValue("@NPostos", row["Postos"]);
                            command.Parameters.AddWithValue("@NEmpresas", row["Empresas"]);
                            command.Parameters.AddWithValue("@Modulos", row["Módulos"]);
                            command.Parameters.AddWithValue("@Desenvolvimento", row["DESENVOLVIMENTO ESPECIFICO"]);
                            command.Parameters.AddWithValue("@EstadoLicenca", row["Activada"]);
                            command.Parameters.AddWithValue("@TecResponsavel", row["Consultor Preferêncial"]);
                            command.Transaction = transaction;

                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string updateQuery = $"UPDATE erp1 SET {produtoColumn} = @Produto, NPostos{i + 1} = @NPostos, " +
                                             $"NEmpresas{i + 1} = @NEmpresas, {produtoColumn}{i + 1}ModulosAddonsDescricao = @Modulos, " +
                                             $"{produtoColumn}{i + 1}Desenvolvimentodescricao = @Desenvolvimento, {estadoLicColumn} = @EstadoLicenca, " +
                                             $"{tecResponsaColumn} = @TecResponsavel WHERE CodCliente = @CodCliente";

                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CodCliente", clientId);
                            command.Parameters.AddWithValue("@Produto", codigoAplicacao);
                            command.Parameters.AddWithValue("@NPostos", row["Postos"]);
                            command.Parameters.AddWithValue("@NEmpresas", row["Empresas"]);
                            command.Parameters.AddWithValue("@Modulos", row["Módulos"]);
                            command.Parameters.AddWithValue("@Desenvolvimento", row["DESENVOLVIMENTO ESPECIFICO"]);
                            command.Parameters.AddWithValue("@EstadoLicenca", row["Activada"]);
                            command.Parameters.AddWithValue("@TecResponsavel", row["Consultor Preferêncial"]);
                            command.Transaction = transaction;

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }




        private void InsertData(MySqlConnection connection, MySqlTransaction transaction, DataRow row)
        {
            // Insert data into the Clientes table
            string insertClientesQuery = "INSERT INTO Clientes (Nome, Email, NIF, ERP) VALUES (@Nome, @Email, @NIF, @ERP); SELECT LAST_INSERT_ID();";
            using (MySqlCommand insertClientesCommand = new MySqlCommand(insertClientesQuery, connection))
            {
                insertClientesCommand.Parameters.AddWithValue("@Nome", row["NomeCliente"]);
                insertClientesCommand.Parameters.AddWithValue("@Email", row["Email"]);
                insertClientesCommand.Parameters.AddWithValue("@NIF", row["NIF"]);
                insertClientesCommand.Parameters.AddWithValue("@ERP", row["ERP"]);
                insertClientesCommand.Transaction = transaction;

                int clientId = Convert.ToInt32(insertClientesCommand.ExecuteScalar());

                // Insert data into the erp1 table
                string insertErp1Query = "INSERT INTO erp1 (CodCliente, Produto, NPostos, NEmpresas, Produto1ModulosAddonsDescricao, " +
                                         "Produto1Desenvolvimentodescricao, Produto1EstadoLic, Produto1TecResponsa) " +
                                         "VALUES (@CodCliente, @Produto, @NPostos, @NEmpresas, @Modulos, @Desenvolvimento, " +
                                         "@EstadoLicenca, @TecResponsavel)";

                using (MySqlCommand insertErp1Command = new MySqlCommand(insertErp1Query, connection))
                {
                    insertErp1Command.Parameters.AddWithValue("@CodCliente", clientId);
                    insertErp1Command.Parameters.AddWithValue("@Produto", row["Código Aplicação"]);
                    insertErp1Command.Parameters.AddWithValue("@NPostos", row["Postos"]);
                    insertErp1Command.Parameters.AddWithValue("@NEmpresas", row["Empresas"]);
                    insertErp1Command.Parameters.AddWithValue("@Modulos", row["Módulos"]);
                    insertErp1Command.Parameters.AddWithValue("@Desenvolvimento", row["DESENVOLVIMENTO ESPECIFICO"]);
                    insertErp1Command.Parameters.AddWithValue("@EstadoLicenca", row["Activada"]);
                    insertErp1Command.Parameters.AddWithValue("@TecResponsavel", row["Consultor Preferêncial"]);
                    insertErp1Command.Transaction = transaction;

                    insertErp1Command.ExecuteNonQuery();
                }
            }
        }

        private void btnGravarClientes_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    DataTable dataTable = (DataTable)kryptonDataGridView2.DataSource; // Assuming the DataGridView is bound to a DataTable

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Verificar se o NIF já existe na tabela Clientes
                        string nif = row["NIF"].ToString();
                        string nomeCliente = row["NomeCliente"].ToString(); // Retrieve the client name
                        int clientId = GetClientIdByNIF(connection, transaction, nif);

                        if (clientId == -1)
                        {
                            // Insert data into Clients and erp1 tables
                            InsertData(connection, transaction, row);
                        }
                        else
                        {
                            // Write to error log
                            string errorLogPath = @"C:\ErrorLogCrmPme\errorlogCRMPME.txt";
                            string errorLogEntry = $"{DateTime.Now} - Cliente com NIF {nif} ({nomeCliente}) já existe. Não foi feita a inserção.{Environment.NewLine}";
                            File.AppendAllText(errorLogPath, errorLogEntry);
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Dados gravados com sucesso!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erro ao gravar os dados: " + ex.Message);
                }
            }
        }
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        MySqlTransaction transaction = connection.BeginTransaction();

        //        try
        //        {
        //            DataTable dataTable = (DataTable)kryptonDataGridView2.DataSource; // Assuming the DataGridView is bound to a DataTable

        //            foreach (DataRow row in dataTable.Rows)
        //            {
        //                // Verificar se o NIF já existe na tabela Clientes
        //                string nif = row["NIF"].ToString();
        //                int clientId = GetClientIdByNIF(connection, transaction, nif);

        //                if (clientId == -1)
        //                {
        //                    // Insert data into Clients and erp1 tables
        //                    InsertData(connection, transaction, row);
        //                }
        //                else
        //                {
        //                    // Write to error log
        //                    string errorLogPath = @"C:\ErrorLogCrmPme\errorlogCRMPME.txt";
        //                    string errorLogEntry = $"{DateTime.Now} - Cliente com NIF {nif} já existe. Não foi feita a inserção.{Environment.NewLine}";
        //                    File.AppendAllText(errorLogPath, errorLogEntry);
        //                }
        //            }

        //            transaction.Commit();
        //            MessageBox.Show("Dados gravados com sucesso!");
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            MessageBox.Show("Erro ao gravar os dados: " + ex.Message);
        //        }

        //}
        //}



        //using (MySqlConnection connection = new MySqlConnection(connectionString))
        //{
        //    connection.Open();
        //    MySqlTransaction transaction = connection.BeginTransaction();

        //    try
        //    {
        //        DataTable dataTable = (DataTable)kryptonDataGridView2.DataSource; // Supondo que o DataGridView está ligado a um DataTable

        //        foreach (DataRow row in dataTable.Rows)
        //        {
        //            // Verificar se o NIF já existe na tabela Clientes
        //            string nif = row["NIF"].ToString();
        //            int clientId = GetClientIdByNIF(connection, transaction, nif);

        //            if (clientId == -1)
        //            {
        //                // Inserir na tabela Clientes e obter o ID
        //                clientId = InsertCliente(connection, transaction, row);
        //            }
        //            else
        //            {
        //                // Atualizar na tabela Clientes
        //                UpdateCliente(connection, transaction, clientId, row);
        //            }

        //            // Inserir na tabela erp1
        //            InsertOrUpdateERP(connection, transaction, clientId, row);
        //        }

        //        transaction.Commit();
        //        MessageBox.Show("Dados gravados com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        MessageBox.Show("Erro ao gravar os dados: " + ex.Message);
        //    }
        //}
    }
    }

