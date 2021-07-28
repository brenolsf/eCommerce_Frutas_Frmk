using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerce_Frutas.Models
{
    public partial class Status
    {
        public Status()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int StatusId { get; set; }
        public int CodStatus { get; set; }
        public string DescStatus { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
