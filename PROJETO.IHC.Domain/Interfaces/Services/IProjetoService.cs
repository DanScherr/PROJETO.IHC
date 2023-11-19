using PROJETO.IHC.Domain.DTOs.Projeto;

namespace PROJETO.IHC.Domain.Interfaces.Services
{
    public interface IProjetoService
    {
        ProjetoOutputDTO GetProjetoById(int id);
        List<ProjetoOutputDTO> GetAllProjetos();
        ProjetoOutputDTO InsertProjeto(ProjetoInsertDTO projetoInsertDTO);
        ProjetoOutputDTO UpdateProjeto(ProjetoUpdateDTO projetoUpdateDTO);
        bool DeleteProjeto(int id);
    }
}
