using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Interfaces
{
    public interface IPlanoConta
    {
        List<PlanoContaModel> ListaPlanoContas();
        IEnumerable<SelectListItem> ListaSelectItemPlanoContas();
        PlanoContaModel CarregarPlanoContaPorId(int? id);
        void Editar(PlanoContaModel model);
        void Inserir(PlanoContaModel model);
        void Excluir(int id);
    }
}
