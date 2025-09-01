using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        public Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = _eventoPersist.GetEventoByIdAsync(eventoId, false).Result;
                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return Task.FromResult(_geralPersist.SaveChangesAsync().Result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes).Result;
                if (eventos == null) return null;

                return Task.FromResult(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = _eventoPersist.GetAllEventosAsync(includePalestrantes).Result;
                if (eventos == null) return null;

                return Task.FromResult(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes).Result;
                if (evento == null) return null;

                return Task.FromResult(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                var evento = _eventoPersist.GetEventoByIdAsync(eventoId, false).Result;
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update<Evento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}