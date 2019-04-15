using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Fornecedor
{
    public partial class Fornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["ID"];
                if (id != null)
                {
                    PessoaJuridicaBLL pjbll = new PessoaJuridicaBLL();
                    var pessoa = pjbll.GetPessoaJuridica(id);
                    txtCNPJ.Text = pessoa.CNPJ;
                    txtEndereço.Text = pessoa.Pessoa.Endereco;
                    txtNome.Text = pessoa.Pessoa.Nome;
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            PessoaJuridicaBLL pjbll = new PessoaJuridicaBLL();
            Negocio.Pessoa p = new Negocio.Pessoa();
            p.Endereco = txtEndereço.Text;
            p.Nome = txtNome.Text;
            PessoaJuridica pj = new PessoaJuridica();
            pj.Pessoa = p;
            pj.CNPJ = txtCNPJ.Text;
            string id = Request["ID"];
            if (id != null)
            {
                pj.CodigoPJ = id;
                pjbll.Alterar(pj);
            }
            else
            {
                pjbll.Inserir(pj);
            }
            Response.Redirect("ListaFornecedor.aspx");
        }
    }
}