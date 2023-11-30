using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        bool LoginEmpresa(string email, string senha);
    }
}
