using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace PDespesas0030482311016
{
    
    public partial class frmPrincipal : Form
    {
        public static SqlConnection conexao;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrinciapl_Load(object sender, EventArgs e)
        {
            try
            {
                // aqui a conexão vai depende da sua máquina da escola ou particular
                conexao = new SqlConnection("Data Source=Apolo;User ID=BD2311033;Password=Denilce@gmail;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conexao.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro de banco de dados =/" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Outros Erros =/" + ex.Message);
            }
        }

        private void CadastrarDespesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmDespesa>().Count() > 0)
                Application.OpenForms["frmDespesa"].BringToFront();
            else
            {
                frmDespesa FrmDesp = new frmDespesa();
                FrmDesp.MdiParent = this;
                FrmDesp.WindowState = FormWindowState.Maximized;
                FrmDesp.Show();
            }
              
        }

        private void SobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmSobre>().Count() > 0)
                Application.OpenForms["frmSobre"].BringToFront();
            else
            {
                frmSobre FrmSobre = new frmSobre();
                FrmSobre.MdiParent = this;
                FrmSobre.WindowState = FormWindowState.Maximized;
                FrmSobre.Show();
            }

        }
    }
}
