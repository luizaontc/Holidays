namespace Calendario.Models
{
    public class RetornoJson
    {
        public List<Dias_Ano> anoFiltrado { get; set; }
        public string feriadoDiasUteis { get; set; }
        public string ano { get; set; }
    }
}
