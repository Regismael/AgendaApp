using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Services
{
    public class TarefaDomainService : ITarefaDomainService
    {
        private string mensagemId = "O ID informado não existe. Por favor, verifique.";

        private readonly ITarefaRepository _tarefaRepository;

        public TarefaDomainService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            _tarefaRepository.add(tarefa);
        }

        public List<Tarefa> ConsultarTarefas()
        {
            return _tarefaRepository.GetAll();
        }

        public Tarefa ConsultarTarefasPorId(Guid id)
        {
            var tarefa = _tarefaRepository.GetById(id);

            if (tarefa == null)
                throw new ArgumentException(mensagemId);

            return _tarefaRepository.GetById(id);


        }

        public void EditarTarefa(Tarefa tarefa)
        {
            if (_tarefaRepository.GetById(tarefa.Id) == null)
                throw new ArgumentException(mensagemId);

            _tarefaRepository.Update(tarefa);
        }

        public void ExcluirTarefa(Guid id)
        {
            var tarefa = _tarefaRepository.GetById(id);

            if (tarefa == null)
                throw new ArgumentException(mensagemId);

            _tarefaRepository.delete(tarefa);

        }
    }
}
