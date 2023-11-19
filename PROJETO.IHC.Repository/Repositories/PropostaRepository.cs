using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;

namespace PROJETO.IHC.Repository.Repositories
{
    public class PropostaRepository : RepositoryBase<Proposta>, IPropostaRepository
    {
        public PropostaRepository(DatabaseContext context) : base(context) { }
    }
}
