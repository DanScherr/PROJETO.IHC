using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        Empresa LoginEmpresa(string email, string senha);
    }
}
