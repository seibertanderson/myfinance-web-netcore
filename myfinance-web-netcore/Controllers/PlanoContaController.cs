using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain.Implementacao;
using myfinance_web_netcore.Models;

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
            var planoContas = new PlanoConta();
            ViewBag.Lista = planoContas.ListaPlanoContas();

            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoConta(int? id)
        {
            if (id != null)
            {
                var planoContas = new PlanoConta().CarregarPlanoContaPorId(id);
                ViewBag.PlanoConta = planoContas;
            }

            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel form)
        {
            PlanoConta planoConta = new PlanoConta();
            if (form.Id == null)
            {
                planoConta.Inserir(form);
            }
            else
            {
                planoConta.Editar(form);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirPlanoConta(int id)
        {
            new PlanoConta().Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
