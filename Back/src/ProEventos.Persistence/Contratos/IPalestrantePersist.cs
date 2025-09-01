using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist : IGeralPersist
    {
        public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        public Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
         
    }
}