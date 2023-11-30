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
            IQueryable<T> query = _dbSet;
            if (asNoTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public void Inserir(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Alterar(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public bool Deletar(int id)
        {
            var entity = this.ObterPorId(id);

            if (entity == null && entity.Ativo)
            {
                entity.Desativar();
                _dbSet.Update(entity);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
