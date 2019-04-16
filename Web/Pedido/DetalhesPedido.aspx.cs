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
    public partial class DetalhesPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {

                string idpedido = Request["IDPedido"];

                if (idpedido != null)
                {
                    PedidoBLL pbll = new PedidoBLL();
                    PessoaFisicaBLL pfbll = new PessoaFisicaBLL();
                    PessoaJuridicaBLL pjbll = new PessoaJuridicaBLL();
                    ItemBLL ibll = new ItemBLL();
                    ProdutoBLL prbll = new ProdutoBLL();

                    var pedido = pbll.GetPedido(idpedido);
                    lblCodigoPedido.Text = pedido.CodigoPedido;
                    lblNomePessoa.Text = pfbll.GetPessoaFisica(pedido.CodigoComprador).NomePessoa;
                    lblNomeFornecedor.Text = pjbll.GetPessoaJuridica(pedido.CodigoVendedor).NomePessoa;

                    var items = ibll.GetItems().Where(p => p.CodigoPedido == pedido.CodigoPedido).ToList();
                    double total = 0;
                    List<Produto> produtos = new List<Produto>();
                    foreach (var item in items)
                    {
                        //var produto = prbll.GetProduto(item.CodigoProduto);
                        //produtos.Add(produto);
                        total += double.Parse(item.ValorTotal);
                        //labelitens += "<br/>Produto: "+produto.Nome+"| Qtd: "+item.Qtd+"| Preço: "+produto.Preco;
                    }
                    grvProdutos.DataSource = items;
                    grvProdutos.DataBind();
                    lblTotal.Text = total.ToString();
                }

            }
        }
    }
}