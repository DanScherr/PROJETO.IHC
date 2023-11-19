using PROJETO.IHC.Domain.DTOs.Habilidade;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class HabilidadeService : IHabilidadeService
    {
        private readonly IHabilidadeRepository _habilidadeRepository;

        public HabilidadeService(IHabilidadeRepository habilidadeRepository)
        {
            _habilidadeRepository = habilidadeRepository;
        }

        public HabilidadeOutputDTO GetHabilidadeById(int id)
        {
            throw new NotImplementedException();
        }

        public List<HabilidadeOutputDTO> GetAllHabilidades()
        {
            throw new NotImplementedException();
        }

        public HabilidadeOutputDTO InsertHabilidade(HabilidadeInsertDTO habilidadeInsertDTO)
        {
            throw new NotImplementedException();
        }

        public HabilidadeOutputDTO UpdateHabilidade(HabilidadeUpdateDTO habilidadeUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHabilidade(int id)
        {
            throw new NotImplementedException();
        }
    }
}
