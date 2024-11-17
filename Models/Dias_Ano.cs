namespace Calendario.Models
{
    public class Dias_Ano
    {
        public int id { get; set; }
        public string dia { get; set; }
        public string mes { get; set; }
        public string ano { get; set; }
        public string dia_semana { get; set; }
        public string data_extensa { get; set; }
        public int dia_util { get; set; }
        public int feriado { get; set; }
    }
}
