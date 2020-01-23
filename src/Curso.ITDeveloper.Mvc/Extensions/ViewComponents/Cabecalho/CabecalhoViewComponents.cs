using System.Threading.Tasks;
using Curso.ITDeveloper.Mvc.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ITDeveloper.Mvc.ViewComponents.CabecalhoModulos
{
    [ViewComponent(Name = "Cabecalho")]
    public class CabecalhoViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string titulo, string subtitulo)
        {
            var model = new Modulo()
            {
                Titulo = titulo,
                Subtitulo = subtitulo
            };
            return View(model);
        }
    }
}
