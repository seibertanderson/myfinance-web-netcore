using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using System.Diagnostics;

namespace myfinance_web_netcore.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        public PlanoContaController(ILogger<PlanoContaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var planoContasModel = new PlanoContaModel();
            ViewBag.Lista = planoContasModel.ListaPlanoContas();

            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoConta(int? id)
        {
            if (id != null)
            {
                var planoContas = new PlanoContaModel().CarregarPlanoContaPorId(id);
                ViewBag.PlanoConta = planoContas;
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel form)
        {
            if (form.Id == null)
            {
                form.Inserir();
            }
            else
            {
                form.Editar(form.Id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirPlanoConta(int id)
        {
            new PlanoContaModel().Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
