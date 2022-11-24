using Microsoft.AspNetCore.Mvc;
using SistemaWebCooperativa.Migrations;
using SistemaWebCooperativa.Models;

namespace SistemaWebCooperativa.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto Contexto;

        public QueryController(Contexto context)
        {
            Contexto = context;
        }

        public IActionResult Cooperado(string filtro)
        {
            List<Cooperado> lista = new List<Cooperado>();

            if(filtro == null)
            {
                lista = Contexto.Cooperado
                .OrderBy(o => o.nome).ToList();
            }
            else
            {
                //lista = Contexto.Cooperado.Where(c => c.nome == nome)
                lista = Contexto.Cooperado.Where(c => c.nome.Contains(filtro))
                .OrderBy(o => o.nome).ToList();
            }
            return View(lista);
        }

    }
}
