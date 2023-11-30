using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;

namespace PROJETO.IHC.Repository.Repositories
{
    public class ColaboradorRepository : RepositoryBase<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(DatabaseContext context) : base(context) { }

        public Colaborador ColaboradorLogin(string email, string senha)
        {
            return _dbSet.Where(x => x.Email.ToUpper() == email.ToUpper() && x.Senha == senha && x.Ativo).FirstOrDefault();
        }

        public Colaborador GetColaboradorByEmail(string email)
        {
            return _dbSet.Where(x => x.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
        }
    }
}
