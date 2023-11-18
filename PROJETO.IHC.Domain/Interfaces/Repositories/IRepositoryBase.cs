using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T ObterPorId(int id, bool asNoTracking = true);
        IList<T> ObterTodos();
        void Inserir(T entity);
        void Alterar(T entity);
        bool Deletar(int id);
    }
}
