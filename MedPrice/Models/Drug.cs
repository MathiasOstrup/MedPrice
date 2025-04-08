namespace MedPrice.Models
{
    public class Drug
    {
        public string Navn { get; set; }
        public string Varenummer { get; set; }
        public string Firma { get; set; }
        public string Styrke { get; set; }
        public string DetaljerUrl { get; set; }
        public string Pakning { get; set; }
        public string NavnStyrkeDisplayText { get; set; }
        public string FirmaVarenummerDisplayText { get; set; }
        public decimal? PrisPrPakning { get; set; }
        public decimal? PrisPrEnhed { get; set; }

        public Drug(string navn, string varenummer, string firma, string styrke, string detaljerUrl, string pakning)
        {
            Navn = navn;
            Varenummer = varenummer;
            Firma = firma;
            Styrke = styrke;
            DetaljerUrl = detaljerUrl;
            Pakning = pakning;

            NavnStyrkeDisplayText = navn + "  " + styrke;
            FirmaVarenummerDisplayText = firma + "  vnr: " + varenummer;
        }

        public override string? ToString()
        {
            return Navn + " " + Styrke + " vnr: " + Varenummer;
        }
    }
}
