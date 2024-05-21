using AgendaApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendaApp.API.Models.Edicao
{
    public class EditarTarefaRequestModel
    {
        [Required(ErrorMessage = "O preenchimento do ID é obrigatório.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome comporta, no máximo, 100 caracteres.")]
        [MinLength(6, ErrorMessage = "O nome deve ter, no mínimo, 6 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O preenchimento da descrição é obrigatório.")]
        [MaxLength(100, ErrorMessage = "A descrição comporta, no máximo, 100 caracteres.")]
        [MinLength(6, ErrorMessage = "A descrição deve ter, no mínimo, 6 caaracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O preenchimento da data e hora é obrigatório.")]
        public DateTime? DataHora { get; set; }

        [Required(ErrorMessage = "O preenchimento da prioridade é obrigatório.")]
        public int? Prioridade { get; set; }
    }
}
