using DAO;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class PedidoBLL
    {
        private string _tabela = "Pedido";
        private string _where = " WHERE CodigoPedido = ";
        public List<Pedido> GetPedidos()
        {
            var listaPedidos = Conexao.ExecutarComandoLeituraSQL(_tabela, "");

            List<Pedido> Pedidos = new List<Pedido>();
            foreach (var item in listaPedidos)
            {
                Pedido p = new Pedido();
                p.CodigoComprador = item["CodigoComprador"];
                p.CodigoPedido = item["CodigoPedido"];
                p.CodigoVendedor = item["CodigoVendedor"];
                p.DataPedido = DateTime.Parse(item["DataPedido"]);
                Pedidos.Add(p);
            }

            return Pedidos;
        }

        public Pedido GetPedido(string id)
        {
            var Pedidos = Conexao.ExecutarComandoLeituraSQL(_tabela, _where + id);

            foreach (var item in Pedidos)
            {
                Pedido p = new Pedido();
                p.CodigoComprador = item["CodigoComprador"];
                p.CodigoPedido = item["CodigoPedido"];
                p.CodigoVendedor = item["CodigoVendedor"];
                p.DataPedido = DateTime.Parse(item["DataPedido"]);
                return p;
            }

            return null;
        }

        public void Inserir(Pedido p)
        {
            string stcCommando = "INSERT INTO " + _tabela + " " +
                "([CodigoComprador], [CodigoVendedor], [DataPedido]) " +
                "VALUES ('" + p.CodigoComprador + "', '" + p.CodigoVendedor + "', " + p.DataPedido.ToShortDateString() + ")";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

        public void Alterar(Pedido p)
        {
            string stcCommando = "UPDATE " + _tabela + " SET " +
                "CodigoComprador = '" + p.CodigoComprador + "', CodigoVendedor =  '" + p.CodigoVendedor + ", DataPedido = " + p.DataPedido.ToShortDateString() + " WHERE CodigoPedido  = '" + p.CodigoPedido + "' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }
    }
}
