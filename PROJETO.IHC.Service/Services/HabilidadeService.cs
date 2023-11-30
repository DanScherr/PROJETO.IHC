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
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var habilidade = _habilidadeRepository.ObterPorId(id);

            if (habilidade == null || !habilidade.Ativo)
                throw new KeyNotFoundException($"Habilidade com Id: {id} não encontrada");

            return new HabilidadeOutputDTO()
            {
                Id = id,
                NomeHabilidade = habilidade.NomeHabilidade,
                DescricaoHabilidade = habilidade.DescricaoHabilidade,
                ExeperienciaHabilidade = habilidade.ExeperienciaHabilidade,
                Ativo = habilidade.Ativo
            };
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

            if (habilidade.Id == 0)
                throw new NullReferenceException("Falha ao inserir Habilidade");

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
            this.GetHabilidadeById(habilidadeUpdateDTO.Id);

            var habilidade = new Habilidade()
            {
                Id = habilidadeUpdateDTO.Id,
                NomeHabilidade = habilidadeUpdateDTO.NomeHabilidade,
                DescricaoHabilidade = habilidadeUpdateDTO.DescricaoHabilidade,
                ExeperienciaHabilidade = habilidadeUpdateDTO.ExeperienciaHabilidade
            };

            _habilidadeRepository.Alterar(habilidade);

            return new HabilidadeOutputDTO()
            {
                Id = habilidade.Id,
                NomeHabilidade = habilidade.NomeHabilidade,
                DescricaoHabilidade = habilidade.DescricaoHabilidade,
                ExeperienciaHabilidade = habilidade.ExeperienciaHabilidade,
                Ativo = habilidade.Ativo
            };
        }

        public bool DeleteHabilidade(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var isDelete = _habilidadeRepository.Deletar(id);

            if (!isDelete)
                throw new KeyNotFoundException($"Habilidade com Id: {id} não encontrada");

            return isDelete;
        }
    }
}
