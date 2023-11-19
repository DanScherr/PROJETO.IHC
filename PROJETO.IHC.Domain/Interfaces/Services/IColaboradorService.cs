using PROJETO.IHC.Domain.DTOs.Colaborador;

namespace PROJETO.IHC.Domain.Interfaces.Services
{
    public interface IColaboradorService
    {
        ColaboradorOutputDTO GetColaboradorById(int id);
        List<ColaboradorOutputDTO> GetAllColaboradores();
        ColaboradorOutputDTO InsertColaborador(ColaboradorInsertDTO colaboradorInsertDTO);
        ColaboradorOutputDTO UpdateColaborador(ColaboradorUpdateDTO colaboradorUpdateDTO);
        bool DeleteColaborador(int id);
    }
}
