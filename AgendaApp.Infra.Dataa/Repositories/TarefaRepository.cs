using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public void add(Tarefa tarefa)
        {

            using (var context = new DataContext())
            {
                context.Add(tarefa);
                context.SaveChanges();
            }

        }

        public void delete(Tarefa tarefa)
        {
            using(var context = new DataContext())
            {
                context.Remove(tarefa);
                context.SaveChanges();
            }
        }

        public List<Tarefa> GetAll()
        {
           using(var context = new DataContext())
            {
                return context.Set<Tarefa>()
                    .OrderBy(t => t.Nome)
                    .ToList();
            }
        }

        public Tarefa GetById(Guid id)
        {
            using(var context = new DataContext())
            {
                return context.Set<Tarefa>()
                    .Where(t => t.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Update(Tarefa tarefa)
        {
            using( var context = new DataContext())
            {
                context.Update(tarefa);
                context.SaveChanges();
            }
        }
    }
}
