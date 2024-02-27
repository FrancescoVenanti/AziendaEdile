using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AziendaEdile.Models
{
    public class Pagamenti
    {
        public int IDPagamento { get; set; }
        public int IDDipendente { get; set; }
        public string PeriodoPagamento { get; set; }
        public decimal AmmontarePagamento { get; set; }
        public bool isAcconto { get; set; }

        public Pagamenti() { }
    }
}