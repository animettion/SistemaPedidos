using DAO;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ProdutoBLL
    {
        private string _tabela = "Produto";
        private string _where = " WHERE CodigoProduto = ";

        public List<Produto> GetProdutos()
        {
            var listaProdutos = Conexao.ExecutarComandoLeituraSQL(_tabela, "");

            List<Produto> Produtos = new List<Produto>();
            foreach (var item in listaProdutos)
            {
                Produto p = new Produto();
                p.CodigoFornecedor = item["CodigoFornecedor"];
                p.CodigoProduto = item["CodigoProduto"];
                p.Nome = item["Nome"];
                p.Preco = item["Preco"];
            }

            return Produtos;
        }

        public Produto GetProduto(string id)
        {
            var Produtos = Conexao.ExecutarComandoLeituraSQL(_tabela, _where + id);

            foreach (var item in Produtos)
            {
                Produto p = new Produto();
                p.CodigoFornecedor = item["CodigoFornecedor"];
                p.CodigoProduto = item["CodigoProduto"];
                p.Nome = item["Nome"];
                p.Preco = item["Preco"];
                return p;
            }

            return null;
        }

        public object GetProdutosByFornecedor(string idfornecedor)
        {
            var listaProdutos = Conexao.ExecutarComandoLeituraSQL(_tabela, " WHERE  Ativo='True' and CodigoFornecedor =" + idfornecedor);

            List<Produto> Produtos = new List<Produto>();
            foreach (var item in listaProdutos)
            {
                Produto p = new Produto();
                p.CodigoFornecedor = item["CodigoFornecedor"];
                p.CodigoProduto = item["CodigoProduto"];
                p.Nome = item["Nome"];
                p.Preco = item["Preco"];
                Produtos.Add(p);
            }

            return Produtos;
        }

        public void Inserir(Produto p)
        {

            string stcCommando = "INSERT INTO " + _tabela + " " +
                "([CodigoFornecedor], [Nome], [Preco],[Ativo]) " +
                "VALUES ('" + p.CodigoFornecedor + "', '" + p.Nome + "', '" + p.Preco + "', '" + "True" + "')";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

        public void Alterar(Produto p)
        {
            string stcCommando = "UPDATE " + _tabela + " SET " +
                "CodigoFornecedor = '" + p.CodigoFornecedor + "', Nome =  '" + p.Nome + ", Preco = '" + p.Preco + " WHERE CodigoProduto  = '" + p.CodigoProduto + "' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

        public void Desativar(string ID)
        {
            string stcCommando = "UPDATE " + _tabela + " SET " +
                "Ativo ='False' WHERE CodigoProduto  = '" + ID + "' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

    }
}