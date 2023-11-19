using Microsoft.EntityFrameworkCore;
using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;

namespace PROJETO.IHC.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T ObterPorId(int id, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public IList<T> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Inserir(T entity)
        {
            throw new NotImplementedException();
        }

        public void Alterar(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
