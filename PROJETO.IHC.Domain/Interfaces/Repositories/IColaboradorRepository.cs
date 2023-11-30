using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Domain.Interfaces.Repositories
{
    public interface IColaboradorRepository : IRepositoryBase<Colaborador>
    {
        Colaborador ColaboradorLogin(string email, string senha);
    }
}
