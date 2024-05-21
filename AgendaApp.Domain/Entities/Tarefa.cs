using AgendaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public Prioridade? Prioridade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }
    }
}
