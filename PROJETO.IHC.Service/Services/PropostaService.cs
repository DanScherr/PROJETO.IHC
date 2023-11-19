using PROJETO.IHC.Domain.DTOs.Proposta;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;

        public PropostaService(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public PropostaOutputDTO GetPropostaById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PropostaOutputDTO> GetAllPropostas()
        {
            throw new NotImplementedException();
        }

        public PropostaOutputDTO InsertProposta(PropostaInsertDTO propostaInsertDTO)
        {
            throw new NotImplementedException();
        }

        public PropostaOutputDTO UpdateProposta(PropostaUpdateDTO propostaUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProposta(int id)
        {
            throw new NotImplementedException();
        }
    }
}
