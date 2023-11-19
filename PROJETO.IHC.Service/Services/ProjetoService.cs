using PROJETO.IHC.Domain.DTOs.Projeto;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public ProjetoOutputDTO GetProjetoById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProjetoOutputDTO> GetAllProjetos()
        {
            throw new NotImplementedException();
        }

        public ProjetoOutputDTO InsertProjeto(ProjetoInsertDTO projetoInsertDTO)
        {
            throw new NotImplementedException();
        }

        public ProjetoOutputDTO UpdateProjeto(ProjetoUpdateDTO projetoUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProjeto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
