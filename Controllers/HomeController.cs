using Calendario.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Calendario.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //LerJson();
            return View();
        }

        public RetornoJson LerJson([FromQuery] string mes, string ano)
        {
            RetornoJson retorno = new RetornoJson();

            List<Dias_Ano> dbJsonList;
            using (StreamReader r = new StreamReader("database.json"))
            {
                string json = r.ReadToEnd();
                dbJsonList = JsonConvert.DeserializeObject<List<Dias_Ano>>(json);
                r.Dispose();
            }

            List<Dias_Ano> anoFiltrado = dbJsonList.Where(x => x.ano == ano && x.feriado == 1).ToList();

            retorno.anoFiltrado = anoFiltrado;
            retorno.feriadoDiasUteis = anoFiltrado.Where(x=> x.dia_util == 1).Count().ToString();
            retorno.ano = ano;

            return retorno;
        }
    }
}
