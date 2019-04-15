using Negocio;
using Negocio.obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pedido
{
    public partial class Pedido : System.Web.UI.Page
    {
        private static List<Negocio.Produto> ProdutosAdd = new List<Negocio.Produto>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProdutosAdd = new List<Negocio.Produto>();
                string idpessoa = Request["IDPessoa"];
                CarregarPessoas();
                if (idpessoa != null)
                {
                    drpPessoas.SelectedValue = idpessoa;
                    drpPessoas.Enabled = false;
                }
                CarregarProdutos();
            }
        }
        private void CarregarProdutos()
        {
            ProdutoBLL pbll = new ProdutoBLL();
            grvProdutos.DataSource = pbll.GetProdutos();
            grvProdutos.DataBind();
        }
        private void CarregarPessoas()
        {
            PessoaFisicaBLL pbll = new PessoaFisicaBLL();
            var pessoas = pbll.GetPessoaFisicas();

            drpPessoas.DataTextField = "NomePessoa";
            drpPessoas.DataValueField = "CodigoPF";
            drpPessoas.DataSource = pessoas;
            drpPessoas.DataBind();
        }

        protected void grvProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "Add")
            {
                ProdutoBLL pbll = new ProdutoBLL();
                var ped=pbll.GetProduto(e.CommandArgument.ToString());
                ProdutosAdd.Add(ped);

                CarregarPedidosAdicionados();
            }
        }

        private void CarregarPedidosAdicionados()
        {
            grvProdutosSelecionados.DataSource = ProdutosAdd;
            grvProdutosSelecionados.DataBind();
        }

        protected void grvProdutosSelecionados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                ProdutoBLL pbll = new ProdutoBLL();
                //var ped = pbll.GetProduto(e.CommandArgument.ToString());
                
                for(var i=0;i< ProdutosAdd.Count; i++)
                {
                    if (ProdutosAdd[i].CodigoProduto == e.CommandArgument.ToString())
                    {
                        ProdutosAdd.RemoveAt(i);
                    }   
                }
               
                CarregarPedidosAdicionados();
            }
        }

        protected void Finalizar_Click(object sender, EventArgs e)
        {
            PedidoBLL pbll = new PedidoBLL();
            Negocio.Pedido ped = new Negocio.Pedido();
            ped.CodigoComprador = drpPessoas.SelectedValue;
            ped.CodigoVendedor
        }
    }
}