using DAO;
using System.Collections.Generic;

namespace Negocio {
    public class ItemBLL {
        private string _tabela = "Item";
        private string _where = " WHERE CodigoItem = ";
        public List<Item> GetItems()
        {
            var listaItems = Conexao.ExecutarComandoLeituraSQL(_tabela, "");

            List<Item> Items = new List<Item>();
            foreach (var item in listaItems)
            {
                Item p = new Item();
                p.CodigoItem = item["CodigoItem"];
                p.CodigoPedido = item["CodigoPedido"];
                p.CodigoProduto = item["CodigoProduto"];
                p.Qtd = item["Qtd"];
                p.ValorUnitario = item["ValorUnitario"];
                ProdutoBLL prbll = new ProdutoBLL();
                p.produto = prbll.GetProduto(p.CodigoProduto);
                Items.Add(p);
            }

            return Items;
        }

        public Item GetItem(string id)
        {
            var Items = Conexao.ExecutarComandoLeituraSQL(_tabela, _where + id);

            foreach (var item in Items)
            {
                Item p = new Item();
                p.CodigoItem = item["CodigoItem"];
                p.CodigoPedido = item["CodigoPedido"];
                p.CodigoProduto = item["CodigoProduto"];
                p.Qtd = item["Qtd"];
                p.ValorUnitario = item["ValorUnitario"];
                return p;
            }

            return null;
        }

        public void Inserir(Item p)
        {
            string stcCommando = "INSERT INTO " + _tabela + " " +
                "([CodigoPedido], [CodigoProduto], [Qtd],[ValorUnitario]) " +
                "VALUES ('" + p.CodigoPedido + "', '" + p.CodigoProduto + "', '" + p.Qtd + "', '" + p.ValorUnitario + "')";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

        public void Alterar(Item p)
        {
            string stcCommando = "UPDATE " + _tabela + " SET " +
                "CodigoPedido = '" + p.CodigoPedido + "', CodigoProduto =  '" + p.CodigoProduto + ", Qtd = '" + p.Qtd + ", ValorUnitario = '" + p.ValorUnitario + " WHERE CodigoItem  = '" + p.CodigoItem + "' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }
    }
}