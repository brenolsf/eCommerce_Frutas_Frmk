using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerce_Frutas.Models
{
    public partial class Estoque
    {
        public int EstoqueId { get; set; }
        public int FrutasId { get; set; }
        public string QtdeAtual { get; set; }

        public virtual Frutas Frutas { get; set; }
    }
}
