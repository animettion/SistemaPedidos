using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Fornecedor
{
    public partial class ListaFornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarFornecedores();
            }
        }

        private void CarregarFornecedores()
        {
            PessoaJuridicaBLL pjbll = new PessoaJuridicaBLL();
            var lista = pjbll.GetPessoaJuridicas();
            grvFornecedor.DataSource = lista;
            grvFornecedor.DataBind();
        }

        protected void grvFornecedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            if (e.CommandName == "Produtos")
            {
                Response.Redirect("../Produtos/Produtos.aspx?ID=" + id);
            }
            else if (e.CommandName == "Editar")
            {
                Response.Redirect("Fornecedor.aspx?ID=" + id);
            }
            else if (e.CommandName == "Excluir")
            {
                PessoaJuridicaBLL pjbll = new PessoaJuridicaBLL();
                pjbll.Excluir(id);
                CarregarFornecedores();
            }
        }
    }
}