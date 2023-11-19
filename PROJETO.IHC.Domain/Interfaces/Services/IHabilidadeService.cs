using PROJETO.IHC.Domain.DTOs.Habilidade;

namespace PROJETO.IHC.Domain.Interfaces.Services
{
    public interface IHabilidadeService
    {
        HabilidadeOutputDTO GetHabilidadeById(int id);
        List<HabilidadeOutputDTO> GetAllHabilidades();
        HabilidadeOutputDTO InsertHabilidade(HabilidadeInsertDTO habilidadeInsertDTO);
        HabilidadeOutputDTO UpdateHabilidade(HabilidadeUpdateDTO habilidadeUpdateDTO);
        bool DeleteHabilidade(int id);
    }
}
