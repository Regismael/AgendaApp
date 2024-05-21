using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        void add(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void delete(Tarefa tarefa);
        List<Tarefa> GetAll();
        Tarefa GetById(Guid id);
    }
}
