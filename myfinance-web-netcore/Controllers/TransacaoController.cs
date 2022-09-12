using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;

        public TransacaoController(ILogger<TransacaoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var transacao = new Transacao();
            ViewBag.Lista = transacao.ListaTransacoes();
            return View();
        }

        public IActionResult TransacaoPorPeriodo()
        {
            var transacao = new Transacao();
            ViewBag.Lista = transacao.ListaTransacoes();
            return View();
        }

        [HttpGet]
        public IActionResult CriarTransacao(int? id)
        {
            var model = new TransacaoModel();
            if (id != null)
            {
                var transacao = new Transacao().CarregarTransacaoPorId(id);
                model = transacao;
                ViewBag.Transacao = transacao;
            }

            ViewBag.ListaPlanoContas = new PlanoContaModel().ListaPlanoContas();
            model.PlanoContas = new PlanoContaModel().ListaSelectItemPlanoContas();

            return View(model);
        }

        [HttpPost]
        public IActionResult CriarTransacao(TransacaoModel form)
        {
            var model = new TransacaoModel();
            ViewBag.ListaPlanoContas = new PlanoContaModel().ListaPlanoContas();
            model.PlanoContas = new PlanoContaModel().ListaSelectItemPlanoContas();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Transacao transacao = new Transacao();

            if (form.Id == null)
            {
                transacao.Inserir(form);
            }
            else
            {
                transacao.Editar(form);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirTransacao(int id)
        {
            new Transacao().Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
