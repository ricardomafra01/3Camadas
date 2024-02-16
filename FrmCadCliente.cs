using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto3Camadas.CODE.BLL;
using Projeto3Camadas.CODE.DTO;

namespace Projeto3Camadas
{
    public partial class FrmCadCliente : Form
    {
        BLL_cliente bllCliente = new BLL_cliente();
        DTO_cliente dtoCliente = new DTO_cliente();
        public FrmCadCliente()
        {
            InitializeComponent();
        }

        public void limparComponentes()
        {
            txtNome.Text = "";
            txtID.Text = "";
            txtEmail.Text = "";
        }

        public void carregarTabela()
        {
            gridView1.DataSource = bllCliente.selecionar();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            dtoCliente.Nome = txtNome.Text;
            dtoCliente.Email = txtEmail.Text;
            bllCliente.inserir(dtoCliente);
            carregarTabela();
            limparComponentes();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dtoCliente.Id_cliente = Convert.ToInt32(txtID.Text);
            dtoCliente.Nome = txtNome.Text;
            dtoCliente.Email = txtEmail.Text;
            bllCliente.alterar(dtoCliente);
            carregarTabela();
            limparComponentes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtoCliente.Id_cliente = Convert.ToInt32(txtID.Text);
            bllCliente.excluir(dtoCliente);
            carregarTabela();
            limparComponentes();
        }

        private void FrmCadCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
