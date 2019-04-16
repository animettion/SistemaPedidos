using Negocio.obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pessoa
{
    public partial class ListaPessoa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarPessoas();
            }
        }

        private void CarregarPessoas()
        {
            PessoaFisicaBLL pjbll = new PessoaFisicaBLL();
            var lista = pjbll.GetPessoaFisicas();
            grvPessoa.DataSource = lista;
            grvPessoa.DataBind();
        }

        protected void grvPessoa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            if (e.CommandName == "Editar")
            {
                Response.Redirect("Pessoa.aspx?ID=" + id);

            }
            else if (e.CommandName == "Pedido")
            {
                Response.Redirect("../Pedido/Pedido.aspx?IDPessoa=" + id);
            }
        }
    }
}