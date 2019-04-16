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
                CarregarFornecedores();
            }
        }

        private void CarregarFornecedores()
        {
            PessoaJuridicaBLL pbll = new PessoaJuridicaBLL();
            var pessoas = pbll.GetPessoaJuridicas();

            drpFornecedor.DataTextField = "NomePessoa";
            drpFornecedor.DataValueField = "CodigoPJ";
            drpFornecedor.DataSource = pessoas;
            drpFornecedor.DataBind();
        }

        private void CarregarProdutos()
        {
            ProdutoBLL pbll = new ProdutoBLL();
            grvProdutos.DataSource = pbll.GetProdutosByFornecedor(drpFornecedor.SelectedValue);
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
            if (e.CommandName == "Add")
            {
                ProdutoBLL pbll = new ProdutoBLL();
                var ped = pbll.GetProduto(e.CommandArgument.ToString());
                ProdutosAdd.Add(ped);

                CarregarPedidosAdicionados();
                CalcularTotal();
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

                for (var i = 0; i < ProdutosAdd.Count; i++)
                {
                    if (ProdutosAdd[i].CodigoProduto == e.CommandArgument.ToString())
                    {
                        ProdutosAdd.RemoveAt(i);
                        CalcularTotal();
                    }
                }

                CarregarPedidosAdicionados();
            }
        }

        private void CalcularTotal()
        {
            double total = 0;
            for (var i = 0; i < ProdutosAdd.Count; i++)
            {
                total +=  double.Parse(ProdutosAdd[i].Preco);
            }
            lblTotal.Text = total.ToString();
        }

        protected void Finalizar_Click(object sender, EventArgs e)
        {
            PedidoBLL pbll = new PedidoBLL();
            Negocio.Pedido ped = new Negocio.Pedido();
            ped.CodigoComprador = drpPessoas.SelectedValue;
            ped.CodigoVendedor = drpFornecedor.SelectedValue;
            ped.DataPedido = DateTime.Now;
            pbll.Inserir(ped);
            string idpedido = pbll.GetPedidos().Max(p => int.Parse(p.CodigoPedido)).ToString();

            foreach (var produto in ProdutosAdd)
            {
                Item item = new Item();
                item.CodigoPedido = idpedido;
                item.CodigoProduto = produto.CodigoProduto;
                item.Qtd = "1";
                item.ValorUnitario = produto.Preco;
                ItemBLL ibll = new ItemBLL();
                ibll.Inserir(item);
             }

            Response.Redirect("DetalhesPedido.aspx?IDPedido="+ idpedido);
        }

        protected void btnAvancar_Click(object sender, EventArgs e)
        {
            drpFornecedor.Enabled = false;
            drpPessoas.Enabled = false;
            btnAvancar.Visible = false;
            DivGrid.Visible = true;
            CarregarProdutos();
        }
    }
}