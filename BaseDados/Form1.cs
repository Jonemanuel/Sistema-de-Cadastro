using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//sql server
using System.Data.SqlServerCe;
using System.IO;

namespace BaseDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            //string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            //string strConection = @"DataSource =" + baseDados + "; Password = '1234'";

            //SqlCeEngine db = new SqlCeEngine (strConection);

            //if (!File.Exists(baseDados)) 
            //{
            //    db.CreateDatabase();
            //}
            //db.Dispose();

            //SqlCeConnection conexao = new SqlCeConnection(strConection);
            ////conexao.ConnectionString = strConection;

            //conexao.Open();

            //labelResultado.Text = "Conectado SQL Server ce";

            //conexao.Close();

            //try { 
            //    conexao.Open();

            //    labelResultado.Text = "Conectado SQL Server ce";
            //}
            //catch (Exception ex) 
            //{
            //    labelResultado.Text = "Erro ao executar a conexao\n" +ex;
            //} finally
            //{
            //    conexao.Close();
            //}
        }

        private void btnCriarTabela_Click(object sender, EventArgs e)
        {
            #region SQLServerCE
            //string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            //string strConection = @"DataSource =" + baseDados + "; Password = '1234'";

            //SqlCeConnection conexao = new SqlCeConnection(strConection);

            //try
            //{
            //    conexao.Open();

            //    SqlCeCommand comando = new SqlCeCommand();
            //    comando.Connection= conexao;

            //    comando.CommandText = "CREATE TABLE pessoas (id INT NOT NULL PRIMARY KEY, nome NVARCHAR(50), email NVARCHAR(50))";

            //    comando.ExecuteNonQuery();

            //    labelResultado.Text = "Tabela criada sql Server CE";

            //    comando.Dispose();

            //}   

            //catch (Exception ex)
            //{
            //    labelResultado.Text = ex.Message;
            //}
            //finally 
            //{
            //    conexao.Close();
            //}
            #endregion
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            #region SQLServerCE
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource =" + baseDados + "; Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConection);

            try
            {
                conexao.Open();

                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                int id = new Random(DateTime.Now.Millisecond).Next(0, 1000);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                comando.CommandText = "INSERT INTO pessoas VALUES (" + id + ",'" + nome + "','" + email + "')";

                comando.ExecuteNonQuery();

                labelResultado.Text = "Registro inserir sql Server CE";

                comando.Dispose();

            }

            catch (Exception ex)
            {
                labelResultado.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            #endregion
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            labelResultado.Text = "";
            lista.Rows.Clear();
            #region SQLServerCE
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource =" + baseDados + "; Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConection);

            try
            {

                string query = "SELECT * FROM pessoas";

                if (txtNome.Text != "")

                {
                    query = "SELECT * FROM pessoas WHERE nome LIKE '" + txtNome.Text + "'";
                }

                DataTable dados = new DataTable();
                SqlCeDataAdapter adaptador = new SqlCeDataAdapter(query, strConection);
                conexao.Open();
                adaptador.Fill(dados);

                foreach (DataRow linha in dados.Rows)
                {
                    lista.Rows.Add(linha.ItemArray);
                }
            }

            catch (Exception ex)
            {
                lista.Rows.Clear();
                labelResultado.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            #endregion
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource =" + baseDados + "; Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConection);

            try
            {
                conexao.Open();

                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                int id = (int)lista.SelectedRows[0].Cells[0].Value;

                comando.CommandText = "DELETE FROM pessoas WHERE id = '"+ id +"' ";

                comando.ExecuteNonQuery();

                labelResultado.Text = "Registro excluido sql Server CE";

                comando.Dispose();

            }
            catch (Exception ex)
            {
                labelResultado.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource =" + baseDados + "; Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConection);

            try
            {
                conexao.Open();

                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                int id = (int)lista.SelectedRows[0].Cells[0].Value;

                string nome = txtNome.Text;
                string email = txtEmail.Text;

                string query = "UPDATE pessoas SET nome = '" + nome + "', email = '" + email + "' WHERE id LIKE '" + id + "'";
                comando.CommandText =query;

                comando.ExecuteNonQuery();

                labelResultado.Text = "Registro alterado sql Server CE";

                comando.Dispose();

            }
            catch (Exception ex)
            {
                labelResultado.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
