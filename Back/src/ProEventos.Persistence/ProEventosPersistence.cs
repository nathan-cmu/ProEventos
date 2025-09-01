using System;
using System.Threading.Tasks;
using ProEventos.Persistence.Contexto;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
       
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
       
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
       
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
       
        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }
    }
}
