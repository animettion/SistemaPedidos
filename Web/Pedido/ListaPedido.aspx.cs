using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pedido
{
    public partial class ListaPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarPedidos();
            }
        }

        private void CarregarPedidos()
        {
            PedidoBLL pbll = new PedidoBLL();
            grvPedido.DataSource=pbll.GetPedidos();
            grvPedido.DataBind();
        }

        protected void grvPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalhes")
            {
                Response.Redirect("DetalhesPedido.aspx?idpedido=" + e.CommandArgument);
            }
        }
    }
}