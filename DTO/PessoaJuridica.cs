namespace Negocio {
    public class PessoaJuridica {
        public string CodigoPJ { get; set; }
        public string CNPJ { get; set; }
        public string Ativa { get; set; }

        public Pessoa Pessoa { get; set; }
        //public string CodigoPessoa { get; set; }
        public string NomePessoa { get { return Pessoa.Nome; } }
    }
}