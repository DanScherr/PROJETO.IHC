using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;

namespace PROJETO.IHC.Repository.Repositories
{
    public class ColaboradorRepository : RepositoryBase<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(DatabaseContext context) : base(context) { }

        public bool ColaboradorLogin(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
