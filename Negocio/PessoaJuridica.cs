using DAO;
using System.Collections.Generic;

namespace Negocio
{
    public class PessoaJuridicaBLL
    {

        private string _tabela = "PessoaJuridica";
        private string _where = " WHERE CODIGOPJ = ";
        public List<PessoaJuridica> GetPessoaJuridicas()
        {
            var listaPessoaJuridicas = Conexao.ExecutarComandoLeituraSQL(_tabela, "");

            List<PessoaJuridica> PessoaJuridicas = new List<PessoaJuridica>();
            foreach (var item in listaPessoaJuridicas)
            {
                PessoaJuridica p = new PessoaJuridica();
                p.Ativa = item["Ativa"] == "True" ? "Sim" : "Não";
                p.CNPJ = item["CNPJ"];
                p.CodigoPessoa = item["CodigoPessoa"];
                p.CodigoPJ = item["CodigoPJ"];

                PessoaBLL pbll = new PessoaBLL();
                p.Pessoa = pbll.GetPessoa(p.CodigoPessoa);
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
                p.CodigoPessoa = item["CodigoPessoa"];
                p.CodigoPJ = item["CodigoPJ"];

                PessoaBLL pbll = new PessoaBLL();
                p.Pessoa = pbll.GetPessoa(p.CodigoPessoa);
                return p;
            }

            return null;
        }

        public void Inserir(PessoaJuridica p)
        {
            string stcCommando = "INSERT INTO " + _tabela + " " +
                "([Ativa], [CNPJ], [CodigoPessoa]) " +
                "VALUES ('" + p.Ativa + "', '" + p.CNPJ + "', '" + p.CodigoPessoa + "')";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

        public void Alterar(PessoaJuridica p)
        {
            string stcCommando = "UPDATE " + _tabela + " SET " +
                "Ativa = '" + p.Ativa + "', CNPJ =  '" + p.CNPJ + "' WHERE CODIGOPJ  = '" + p.CodigoPJ + "' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

    }
}