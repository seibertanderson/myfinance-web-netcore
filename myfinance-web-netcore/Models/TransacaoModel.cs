using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace myfinance_web_netcore.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? Data { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal? Valor { get; set; }
        [MaxLength(100)]
        public string? Historico { get; set; }
        [MaxLength(1)]
        [Required(ErrorMessage = "Campo Obrigatório (R ou D)")]
        public string? Tipo { get; set; }

        [Display(Name = "Plano de Contas")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int? IdPlanoConta { get; set; }
        public IEnumerable<SelectListItem> PlanoContas { get; set; }
    }
}
