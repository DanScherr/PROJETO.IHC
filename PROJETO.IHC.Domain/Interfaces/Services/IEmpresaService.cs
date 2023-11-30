using PROJETO.IHC.Domain.DTOs;
using PROJETO.IHC.Domain.DTOs.Empresa;

namespace PROJETO.IHC.Domain.Interfaces.Services
{
    public interface IEmpresaService
    {
        EmpresaOutputDTO GetEmpresaById(int id);
        List<EmpresaOutputDTO> GetAllEmpresas();
        EmpresaOutputDTO InsertEmpresa(EmpresaInsertDTO empresaInsertDTO);
        EmpresaOutputDTO UpdateEmpresa(EmpresaUpdateDTO empresaUpdateDTO);
        bool DeleteEmpresa(int id);
        int LoginEmpresa(LoginDTO loginDTO);
        bool ValidaEmpresaEmailExistente(string email);
    }
}
