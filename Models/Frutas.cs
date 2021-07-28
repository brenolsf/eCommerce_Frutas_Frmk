using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerce_Frutas.Models
{
    public partial class Frutas
    {
        public Frutas()
        {
            Carrinho = new HashSet<Carrinho>();
        }

        public int FrutasId { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<Carrinho> Carrinho { get; set; }
    }
}
