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
    public partial class FrmConsulta : Form
    {
        public FrmConsulta()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();

                String SQL = "Select * from clientes";
                OleDbDataAdapter adapter = new OleDbDataAdapter(SQL,conn);
                DataSet DS = new DataSet();
                adapter.Fill(DS, "clientes");

                DgResultado.DataSource = DS.Tables["clientes"];


            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadCliente frm = new FrmCadCliente();
            frm.Codigo = DgResultado.SelectedCells[0].Value.ToString();
            frm.txtNome.Text = DgResultado.SelectedCells[1].Value.ToString();
            frm.txtTelefone.Text = DgResultado.SelectedCells[3].Value.ToString();
            frm.txtEmail.Text = DgResultado.SelectedCells[2].Value.ToString();
            frm.txtEndereco.Text = DgResultado.SelectedCells[4].Value.ToString();
            frm.txtData.Text = DgResultado.SelectedCells[5].Value.ToString();
            frm.btnCad.Visible = false;
            frm.btnAlterar.Visible = true;

            frm.ShowDialog();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String StringCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\base.mdb";
                OleDbConnection conn = new OleDbConnection(StringCon);
                conn.Open();
                String cod = DgResultado.SelectedCells[0].Value.ToString();
                String SQL = "delete from clientes Where codigo =" + cod;

                OleDbCommand cmd = new OleDbCommand(SQL, conn);
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados Excluidos Com Secesso.");

                

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
