using PROJETO.IHC.Domain.DTOs.Proposta;

namespace PROJETO.IHC.Domain.Interfaces.Services
{
    public interface IPropostaService
    {
        PropostaOutputDTO GetPropostaById(int id);
        List<PropostaOutputDTO> GetAllPropostas();
        PropostaOutputDTO InsertProposta(PropostaInsertDTO propostaInsertDTO);
        PropostaOutputDTO UpdateProposta(PropostaUpdateDTO propostaUpdateDTO);
        bool DeleteProposta(int id);
    }
}
