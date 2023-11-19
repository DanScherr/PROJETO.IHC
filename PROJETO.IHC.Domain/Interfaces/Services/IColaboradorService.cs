using PROJETO.IHC.Domain.DTOs.Colaborador;

namespace PROJETO.IHC.Domain.Interfaces.Services
{
    public interface IColaboradorService
    {
        List<ColaboradorOutputDTO> GetAllColaboradores();
    }
}
