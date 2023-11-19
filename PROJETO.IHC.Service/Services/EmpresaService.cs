using PROJETO.IHC.Domain.DTOs.Empresa;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public EmpresaOutputDTO GetEmpresaById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmpresaOutputDTO> GetAllEmpresas()
        {
            throw new NotImplementedException();
        }

        public EmpresaOutputDTO InsertEmpresa(EmpresaInsertDTO empresaInsertDTO)
        {
            throw new NotImplementedException();
        }

        public EmpresaOutputDTO UpdateEmpresa(EmpresaUpdateDTO empresaUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmpresa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
