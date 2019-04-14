using DAO;
using System.Collections.Generic;

namespace Negocio
{
    public class PessoaBLL
    {
        private string _tabela = "Pessoa";
        private string _where = " WHERE CODIGOPESSOA = ";
        public List<Pessoa> GetPessoas()
        {
            var listaPessoas = Conexao.ExecutarComandoLeituraSQL(_tabela, "");

            List<Pessoa> pessoas = new List<Pessoa>();
            foreach (var item in listaPessoas)
            {
                Pessoa p = new Pessoa();
                p.CodigoPessoa = item["CodigoPessoa"];
                p.Endereco = item["Endereco"];
                p.Nome = item["Nome"];
                pessoas.Add(p);
            }

            return pessoas;
        }

        public Pessoa GetPessoa(string id)
        {
            var Pessoas = Conexao.ExecutarComandoLeituraSQL(_tabela, _where + id);
            
            foreach (var item in Pessoas)
            {
                Pessoa p = new Pessoa();
                p.CodigoPessoa = item["CodigoPessoa"];
                p.Endereco = item["Endereco"];
                p.Nome = item["Nome"];
                return p;
            }

            return null;
        }

        public void Inserir(Pessoa p)
        {
            string stcCommando = "INSERT INTO " + _tabela + "( [Nome], [Endereco]) " +
                                    "VALUES('"+p.Nome+"', '"+p.Endereco+"')";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

        public void Alterar(Pessoa p)
        {
            string stcCommando = "UPDATE " + _tabela + " SET NOME = '"+p.Nome+"', ENDERECO =  '"+p.Endereco+"' WHERE CODIGOPESSOA  = '"+p.CodigoPessoa+"' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

    }
}