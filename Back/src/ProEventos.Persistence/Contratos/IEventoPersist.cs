using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist : IGeralPersist
    {
        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        public Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);      

    }
}