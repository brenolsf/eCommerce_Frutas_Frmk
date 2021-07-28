using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerce_Frutas.Models
{
    public partial class Carrinho
    {
        public Carrinho()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int CarrinhoId { get; set; }
        public int CodCarrinho { get; set; }
        public int FrutasId { get; set; }
        public int QtdeSolicitada { get; set; }

        public virtual Frutas Frutas { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
