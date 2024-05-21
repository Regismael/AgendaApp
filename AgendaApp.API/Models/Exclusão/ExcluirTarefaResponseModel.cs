namespace AgendaApp.API.Models.Exclusão
{
    public class ExcluirTarefaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Prioridade { get; set; }
    }
}
