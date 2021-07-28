using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerce_Frutas.Models
{
    public partial class Pedido
    {
        public int PedidoId { get; set; }
        public int CodPedido { get; set; }
        public int CodCarrinho { get; set; }
        public int CodStatus { get; set; }
        public DateTime? DataPedido { get; set; }

        public virtual Carrinho CodCarrinhoNavigation { get; set; }
        public virtual Status CodStatusNavigation { get; set; }
    }
}
