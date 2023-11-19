using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;

namespace PROJETO.IHC.Repository.Repositories
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(DatabaseContext context) : base(context) { }
    }
}
