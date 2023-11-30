using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;

namespace PROJETO.IHC.Repository.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(DatabaseContext context) : base(context) { }

        public Empresa LoginEmpresa(string email, string senha)
        {
            return _dbSet.Where(x => x.Email.ToUpper() == email.ToUpper() && x.Senha == senha && x.Ativo).FirstOrDefault();
        }
    }
}
