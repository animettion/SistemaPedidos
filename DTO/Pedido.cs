using Negocio.obj;
using System;

namespace Negocio
{
    public class Pedido
    {
        public string CodigoPedido { get; set; }
        public string CodigoComprador { get; set; }
        public string CodigoVendedor { get; set; }
        public DateTime DataPedido { get; set; }
        public PessoaFisica Comprador { set; get; }
        public PessoaJuridica Vendedor { set; get; }
    }
}
