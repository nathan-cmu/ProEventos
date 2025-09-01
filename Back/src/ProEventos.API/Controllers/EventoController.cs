using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexto;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = _eventoService.GetAllEventosAsync(true).Result;
                if (eventos == null) return NotFound("Nenhum evento encontrado.");
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = _eventoService.GetEventoByIdAsync(id, true).Result;
                if (evento == null) return NotFound("Nenhum evento encontrado.");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = _eventoService.AddEventos(model).Result;
                if (evento == null) return BadRequest("Erro ao adicionar evento.");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = _eventoService.UpdateEventos(id, model).Result;
                if (evento == null) return BadRequest("Erro ao atualizar evento.");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = _eventoService.GetEventoByIdAsync(id, false).Result;
                if (evento == null) return NotFound("Nenhum evento encontrado.");

                if (await _eventoService.DeleteEventos(id))
                {
                    return Ok("Deletado");
                }
                else
                {
                    return BadRequest("Erro ao deletar evento.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = _eventoService.GetAllEventosByTemaAsync(tema, true).Result;
                if (eventos == null) return NotFound("Nenhum evento encontrado.");
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        
    }
}
