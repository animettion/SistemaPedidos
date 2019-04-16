using System;

namespace Negocio.obj
{
    public class PessoaFisica
    {
        public string CodigoPF { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }

        public Pessoa Pessoa { get; set; }
        public string CodigoPessoa { get; set; }
        public string NomePessoa { get { return Pessoa.Nome; } }
    }
}