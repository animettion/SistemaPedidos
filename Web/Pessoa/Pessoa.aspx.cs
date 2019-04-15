using Negocio.obj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pessoa
{
    public partial class Pessoa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["ID"];
                if (id != null)
                {
                    PessoaFisicaBLL pjbll = new PessoaFisicaBLL();
                    var pessoa = pjbll.GetPessoaFisica(id);
                    txtCpf.Text = pessoa.CPF;
                    txtDataNasc.Text = pessoa.DataNascimento;
                    txtEndereco.Text = pessoa.Pessoa.Endereco;
                    txtNome.Text = pessoa.Pessoa.Nome;
                    rdbSexo.SelectedValue = pessoa.Sexo;
                    
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            PessoaFisicaBLL pbll = new PessoaFisicaBLL();
            PessoaFisica p = new PessoaFisica();
            p.CPF = txtCpf.Text;
            p.DataNascimento = txtDataNasc.Text;
            p.Sexo = rdbSexo.SelectedValue;
            Negocio.Pessoa pe = new Negocio.Pessoa();
            pe.Endereco = txtEndereco.Text;
            pe.Nome = txtNome.Text;
            p.Pessoa = pe;

            string id = Request["ID"];
            if (id != null)
            {
               
                p.CodigoPF = id;
                pbll.Alterar(p);
            }
            else
            {
                pbll.Inserir(p);
            }
            Response.Redirect("ListaPessoa.aspx");
        }
    }
}