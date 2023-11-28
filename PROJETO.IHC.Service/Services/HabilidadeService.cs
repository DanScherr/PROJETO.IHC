using PROJETO.IHC.Domain.DTOs.Colaborador;
using PROJETO.IHC.Domain.DTOs.Habilidade;
using PROJETO.IHC.Domain.Entities;
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
            var listColaboradores = _habilidadeRepository.ObterTodos();

            return listColaboradores.Select(x =>
            {
                return new HabilidadeOutputDTO()
                {
                    Id = x.Id,
                    NomeHabilidade = x.NomeHabilidade,
                    DescricaoHabilidade = x.DescricaoHabilidade,
                    ExeperienciaHabilidade = x.ExeperienciaHabilidade,
                    Ativo = x.Ativo 
                };
            }).ToList();
        }

        public HabilidadeOutputDTO InsertHabilidade(HabilidadeInsertDTO habilidadeInsertDTO)
        {
            var habilidade = new Habilidade()
            {
                NomeHabilidade = habilidadeInsertDTO.NomeHabilidade,
                DescricaoHabilidade = habilidadeInsertDTO.DescricaoHabilidade,
                ExeperienciaHabilidade = habilidadeInsertDTO.ExeperienciaHabilidade
            };

            habilidade.Ativar();

            _habilidadeRepository.Inserir(habilidade);

            return new HabilidadeOutputDTO()
            {
                Id = habilidade.Id,
                NomeHabilidade = habilidade.NomeHabilidade,
                DescricaoHabilidade = habilidade.DescricaoHabilidade,
                ExeperienciaHabilidade = habilidade.ExeperienciaHabilidade,
                Ativo = habilidade.Ativo
            };
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
