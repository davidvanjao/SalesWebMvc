using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pdf()
        {
            var model = new { Nome = "Relatório de Teste", Data = DateTime.Now };

            return new ViewAsPdf("Pdf", model)
            {
                //FileName = "relatorio.pdf"
                // NÃO definir FileName faz o navegador tentar abrir em nova aba
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                ContentDisposition = Rotativa.AspNetCore.Options.ContentDisposition.Inline //permite exibir no navegador.
            };
        }
    }
}
