using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Services
{
    public interface ITarefaDomainService
    {
        void AdicionarTarefa(Tarefa tarefa);
        void EditarTarefa(Tarefa tarefa);
        void ExcluirTarefa(Guid id);
        List<Tarefa> ConsultarTarefas();
        Tarefa ConsultarTarefasPorId(Guid id);

    }
}
