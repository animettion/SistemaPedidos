using Negocio;
using Negocio.obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PessoaBLL np = new PessoaBLL();
            Pessoa p1 = new Pessoa();
            p1.Nome = "LEO xxx";
            p1.Endereco = "END xxx";
            np.Inserir(p1);
            
            var lista =  np.GetPessoas();
            var pp = np.GetPessoa("1");

            pp.Nome = "LEO 123";
            pp.Endereco = "END 123";
            np.Alterar(pp);
            

            PessoaFisicaBLL pfbll = new PessoaFisicaBLL();
            PessoaFisica pf = new PessoaFisica();
            pf.CPF = "12345678765";
            pf.DataNascimento = "01/01/2000";
            pf.Sexo = "M";
            pf.CodigoPessoa = "1";
            pfbll.Inserir(pf);

            var lista1 = pfbll.GetPessoaFisicas();
            var pp1 = pfbll.GetPessoaFisica("5");

            pp1.CPF = "12345654333";
            pp1.DataNascimento = "01/01/2002";
            pp1.Sexo = "F";
            pfbll.Alterar(pp1);

            PessoaJuridicaBLL pjbll = new PessoaJuridicaBLL();
            PessoaJuridica pj = new PessoaJuridica();
            pj.Ativa = "1";
            pj.CNPJ = "124565322";
            pj.CodigoPessoa = "2";

            pjbll.Inserir(pj);

            var lista2 = pjbll.GetPessoaJuridicas();
            var pp2 = pjbll.GetPessoaJuridica("1");



            pp2.Ativa = "0";
            pp2.CNPJ = "23455667";
            pjbll.Alterar(pp2);

        }
    }
}