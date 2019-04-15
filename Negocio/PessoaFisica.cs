using DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.obj
{
    public class PessoaFisicaBLL
    {
        private string _tabela = "PessoaFisica";
        private string _where = " WHERE CODIGOPF = ";
        public List<PessoaFisica> GetPessoaFisicas()
        {
            var listaPessoaFisicas = Conexao.ExecutarComandoLeituraSQL(_tabela, "");

            List<PessoaFisica> PessoaFisicas = new List<PessoaFisica>();
            foreach (var item in listaPessoaFisicas)
            {
                PessoaFisica p = new PessoaFisica();
                p.CodigoPessoa = item["CodigoPessoa"];
                p.CodigoPF = item["CodigoPF"];
                p.CPF = item["CPF"];
                p.DataNascimento = item["DataNascimento"];
                p.Sexo = item["Sexo"] == "F" ? "Feminino" : "Masculino";

                PessoaBLL pbll = new PessoaBLL();
                p.Pessoa = pbll.GetPessoa(p.CodigoPessoa);
                PessoaFisicas.Add(p);
            }

            return PessoaFisicas;
        }

        public PessoaFisica GetPessoaFisica(string id)
        {
            var PessoaFisicas = Conexao.ExecutarComandoLeituraSQL(_tabela, _where + id);

            foreach (var item in PessoaFisicas)
            {
                PessoaFisica p = new PessoaFisica();
                p.CodigoPessoa = item["CodigoPessoa"];
                p.CodigoPF = item["CodigoPF"];
                p.CPF = item["CPF"];
                p.DataNascimento = item["DataNascimento"];
                p.Sexo = item["Sexo"];

                PessoaBLL pbll = new PessoaBLL();
                p.Pessoa = pbll.GetPessoa(p.CodigoPessoa);
                return p;
            }

            return null;
        }



        public void Inserir(PessoaFisica p)
        {

            PessoaBLL pbll = new PessoaBLL();
            pbll.Inserir(p.Pessoa);
            p.CodigoPessoa = pbll.GetPessoas().Max(pp => int.Parse(pp.CodigoPessoa)).ToString();

            string stcCommando = "INSERT INTO " + _tabela + " " +
                "([CPF], [DataNascimento], [CodigoPessoa], [Sexo]) " +
                "VALUES ('" + p.CPF + "', '" + p.DataNascimento + "', '" + p.CodigoPessoa + "', '" + p.Sexo + "')";
            Conexao.ExecutarComandoSQL(stcCommando);
        }

        public void Alterar(PessoaFisica p)
        {
            PessoaBLL pbll = new PessoaBLL();
            p.Pessoa.CodigoPessoa = GetPessoaFisica(p.CodigoPF).CodigoPessoa;
            pbll.Alterar(p.Pessoa);

            string stcCommando = "UPDATE " + _tabela + " SET " +
                "CPF = '" + p.CPF + "', DataNascimento =  '" + p.DataNascimento + "', Sexo = '" + p.Sexo + "' WHERE CODIGOPF  = '" + p.CodigoPF + "' ";
            Conexao.ExecutarComandoSQL(stcCommando);
        }
    }
}