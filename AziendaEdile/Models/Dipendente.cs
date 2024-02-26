using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AziendaEdile.Models
{
    public class Dipendente
    {
        public int IDDipendente { get; set; }
        public string NomeDipendente { get; set; }
        public string CognomeDipendente { get; set; }
        public string Indirizzo { get; set; }
        public string CodFiscale { get; set; }
        [Display(Name = "E' Sposato?")]
        public bool Sposato { get; set; }
        public int FigliCarico { get; set; }
        public string Mansione { get; set; }

        public Dipendente() { }

    }
}