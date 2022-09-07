using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CadastroClientes
{
    public partial class FrmCadCliente : Form
    {
        public FrmCadCliente()
        {
            InitializeComponent();
        }

        public String Codigo;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();

                String SQL;
                SQL = "Insert Into clientes(Nome,DataNasc,Telefone,Email,Endereco) Values";
                SQL += "('"+txtNome.Text+ "','" +txtData.Text+"','"+txtTelefone.Text+"','"+txtEmail.Text+"','"+txtEndereco.Text+"')";

                OleDbCommand cmd = new OleDbCommand(SQL,conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados Cadastrados com Sucesso.");

                txtNome.Clear();
                txtData.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtEndereco.Clear();

                conn.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();

                String SQL;
                SQL = "update clientes set Nome = '" + txtNome.Text + "',";
                SQL += "DataNasc = '" + txtData.Text + "',";
                SQL += "Telefone = '" + txtTelefone.Text + "',";
                SQL += "Email = '" + txtEmail.Text + "',";
                SQL += "Endereco = '" + txtEndereco.Text + "' ";
                SQL += "Where Codigo = " + Codigo;



                OleDbCommand cmd = new OleDbCommand(SQL, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados Alterados com Sucesso.");

                txtNome.Clear();
                txtData.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtEndereco.Clear();

                conn.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
