using AgendaApp.Domain.Enums;

namespace AgendaApp.API.Models.Cadastro
{
    public class CadastroTarefaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Prioridade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
    }
}
