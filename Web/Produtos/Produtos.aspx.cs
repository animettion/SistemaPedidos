using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Produtos
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string idfornecedor = Request["ID"];
                PessoaJuridicaBLL pjbll = new PessoaJuridicaBLL();
                var pessoajuridica=pjbll.GetPessoaJuridica(idfornecedor);

                lblNome.Text = pessoajuridica.Pessoa.Nome;
                CarregarProdutos();
            }
        }

        private void CarregarProdutos()
        {
            ProdutoBLL pbll = new ProdutoBLL();
            string idfornecedor = Request["ID"];
            grvProdutos.DataSource = pbll.GetProdutosByFornecedor(idfornecedor);
            grvProdutos.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoBLL pbll = new ProdutoBLL();
            Produto p = new Produto();
            string idfornecedor = Request["ID"];
            p.CodigoFornecedor = idfornecedor;
            p.Nome = txtNome.Text;
            p.Preco = txtPreco.Text;
            pbll.Inserir(p);

            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            CarregarProdutos();
        }

        protected void grvProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                string id = e.CommandArgument.ToString();
                ProdutoBLL pbll = new ProdutoBLL();
                pbll.Desativar(id);
                CarregarProdutos();
            }
        }
    }
}