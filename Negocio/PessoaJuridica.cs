using DAO;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class PessoaJuridicaBLL
    {

        private string _tabela = "PessoaJuridica";
        private string _where = " WHERE CODIGOPJ = ";
        public List<PessoaJuridica> GetPessoaJuridicas()
        {
            var listaPessoaJuridicas = Conexao.ExecutarComandoLeituraSQL(_tabela, " where Ativa = 'True'");

            List<PessoaJuridica> PessoaJuridicas = new List<PessoaJuridica>();
            foreach (var item in listaPessoaJuridicas)
            {
                PessoaJuridica p = new PessoaJuridica();
                p.Ativa = item["Ativa"] == "True" ? "Sim" : "Não";
                p.CNPJ = item["CNPJ"];
                //p.CodigoPessoa = item["CodigoPessoa"];
                p.CodigoPJ = item["CodigoPJ"];

                PessoaBLL pbll = new PessoaBLL();
                p.Pessoa = pbll.GetPessoa(p.CodigoPJ);
                PessoaJuridicas.Add(p);
            }

            return PessoaJuridicas;
        }

        public PessoaJuridica GetPessoaJuridica(string id)
        {
            var PessoaJuridicas = Conexao.ExecutarComandoLeituraSQL(_tabela, _where + id);

            foreach (var item in PessoaJuridicas)
            {
                PessoaJuridica p = new PessoaJuridica();
                p.Ativa = item["Ativa"];
                p.CNPJ = item["CNPJ"];
                //p.CodigoPessoa = item["CodigoPessoa"];
                p.CodigoPJ = item["CodigoPJ"];

                PessoaBLL pbll = new PessoaBLL();
                p.Pessoa = pbll.GetPessoa(p.CodigoPJ);
                return p;
            }

            return null;
        }

        public void Inserir(PessoaJuridica p)
        {
            PessoaBLL pbll = new PessoaBLL();
            pbll.Inserir(p.Pessoa);
            p.CodigoPJ=pbll.GetPessoas().Max(pp => int.Parse(pp.CodigoPessoa)).ToString();
            
            string stcCommando = "INSERT INTO " + _tabela + " " +
                "([Ativa], [CNPJ], [CodigoPJ]) " +
                "VALUES ('" +"True" + "', '" + p.CNPJ + "', '" + p.CodigoPJ + "')";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

        public void Alterar(PessoaJuridica p)
        {
            PessoaBLL pbll = new PessoaBLL();
            pbll.Alterar(p.Pessoa);

            string stcCommando = "UPDATE " + _tabela + " SET " +
                "CNPJ =  '" + p.CNPJ + "' WHERE CODIGOPJ  = '" + p.CodigoPJ + "' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }
        public void Excluir(string id)
        {
            string stcCommando = "UPDATE " + _tabela + " SET " +
                "Ativa = '" + "False" + "' WHERE CODIGOPJ  = '" + id + "' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }
    }
}