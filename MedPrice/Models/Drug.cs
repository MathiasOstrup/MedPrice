using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPrice.Models
{
    public class Drug
    {
        public string Navn { get; set; }
        public int Varenummer { get; set; }
        public string Firma { get; set; }
        public string Styrke { get; set; }
        public string DetaljerUrl { get; set; }
        public string Pakning { get; set; }

        // Constructor that accepts parameters for all properties
        public Drug(string navn, int varenummer, string firma, string styrke, string detaljerUrl, string pakning)
        {
            Navn = navn;
            Varenummer = varenummer;
            Firma = firma;
            Styrke = styrke;
            DetaljerUrl = detaljerUrl;
            Pakning = pakning;
        }

        public override string? ToString()
        {
            return "Præperat: " + Navn + " vnr: " + Varenummer;
        }
    }
}
