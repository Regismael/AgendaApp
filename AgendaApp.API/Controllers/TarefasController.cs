using AgendaApp.API.Models.Cadastro;
using AgendaApp.API.Models.Consulta;
using AgendaApp.API.Models.Edicao;
using AgendaApp.API.Models.Exclusão;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Enums;
using AgendaApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaDomainService _tarefaDomainService;

        public TarefasController(ITarefaDomainService tarefaDomainService)
        {
            _tarefaDomainService = tarefaDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CadastroTarefaResponseModel), 201)]
        public IActionResult Post(CadastroTarefaRequestModel model)
        {

            try
            {
                var tarefa = new Tarefa
                {
                    Id = Guid.NewGuid(),
                    DataHoraCadastro = DateTime.Now,
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    DataHora = model.DataHora,
                    Prioridade = (Prioridade)model.Prioridade,
                    DataHoraUltimaAtualizacao = DateTime.Now
                };

                _tarefaDomainService.AdicionarTarefa(tarefa);

                var response = new CadastroTarefaResponseModel
                {
                    Id = tarefa.Id,
                    Nome = tarefa.Nome,
                    Descricao = tarefa.Descricao,
                    DataHora = tarefa.DataHora,
                    Prioridade = (int)tarefa.Prioridade,
                    DataHoraCadastro = tarefa.DataHoraCadastro,

                };

                return StatusCode(201, new
                {
                    Message = "Tarefa cadastrada com sucesso!", response
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ProblemDetails { Title = "Erro interno", Detail = e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(EditarTarefaResponseModel), 200)]
        public IActionResult Put(EditarTarefaRequestModel model)
        {

            try
            {
                var tarefaExistente = _tarefaDomainService.ConsultarTarefasPorId(model.Id.Value);

                if (tarefaExistente != null)
                {

                    var tarefa = new EditarTarefaRequestModel
                    {
                        Id = model.Id,
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                        DataHora = model.DataHora,
                        Prioridade = (int)model.Prioridade,
                    };
                }
                else
                {
                    throw new ArgumentException
                        ("Tarefa não encontrada. Por favor verifique o ID!");
                }

                var response = new EditarTarefaResponseModel
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    DataHora = model.DataHora,
                    Prioridade = (int)model.Prioridade,
                    DataHoraCadastro = tarefaExistente.DataHoraCadastro,
                    DataHoraUltimaAtualizacao = DateTime.Now
                };

                return StatusCode(200, new
                {
                    Message = "Tarefa atualizada com sucesso!", response
                });
         
            }
            catch (Exception e)
            {
                return StatusCode(500, new ProblemDetails { Title = "Erro interno", Detail = e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirTarefaResponseModel),200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var tarefaExistente = _tarefaDomainService.ConsultarTarefasPorId(id);

                if (tarefaExistente != null)
                {

                    _tarefaDomainService.ExcluirTarefa(id);

                }
                else
                {
                    throw new ArgumentException
                        ("Tarefa não encontrada. Por favor verifique o ID!");
                }

                return StatusCode(200, new
                {
                    Message = "Tarefa excluída com sucesso!",tarefaExistente
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new ProblemDetails { Title = "Erro interno", Detail = e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultarTarefaResponseModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var listaTarefas = _tarefaDomainService.ConsultarTarefas();
                var response = listaTarefas.Select(t => new ConsultarTarefaResponseModel
                {
                    Id = t.Id,
                    Nome = t.Nome,
                    Descricao = t.Descricao,
                    DataHora = t.DataHora,
                    Prioridade = (int)t.Prioridade,
                    DataHoraCadastro = t.DataHoraCadastro,
                    DataHoraUltimaAtualizacao = t.DataHoraUltimaAtualizacao
                }).ToList();

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ProblemDetails { Title = "Erro interno", Detail = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsultarTarefaResponseModel), 200)]
        public IActionResult Get(Guid id)
        {
            try
            {
                var tarefa = _tarefaDomainService.ConsultarTarefasPorId(id);

                if (tarefa == null)
                {
                    return NotFound(new ProblemDetails { Title = "ID não encontrado", Detail = "ID não encontrado. Por favor verique-o." });
                }

                var response = new ConsultarTarefaResponseModel
                {
                    Id = tarefa.Id,
                    Nome = tarefa.Nome,
                    Descricao = tarefa.Descricao,
                    DataHora = tarefa.DataHora,
                    Prioridade = (int)tarefa.Prioridade,
                    DataHoraCadastro = tarefa.DataHoraCadastro,
                    DataHoraUltimaAtualizacao = tarefa.DataHoraUltimaAtualizacao
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new ProblemDetails { Title = "Erro interno", Detail = e.Message });
            }
        }
    }
}
