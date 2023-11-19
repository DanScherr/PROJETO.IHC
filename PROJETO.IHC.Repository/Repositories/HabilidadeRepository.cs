using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;

namespace PROJETO.IHC.Repository.Repositories
{
    public class HabilidadeRepository : RepositoryBase<Habilidade>, IHabilidadeRepository
    {
        public HabilidadeRepository(DatabaseContext context) : base(context) { }
    }
}
