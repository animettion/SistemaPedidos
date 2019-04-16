namespace Negocio {
    public class Item {
        public string CodigoItem { get; set; }
        public string CodigoPedido { get; set; }
        public string CodigoProduto { get; set; }
        public string Qtd { get; set; }
        public string ValorUnitario { get; set; }
        public Produto produto { set; get; }
        public string ValorTotal { get; set; }
    }
}