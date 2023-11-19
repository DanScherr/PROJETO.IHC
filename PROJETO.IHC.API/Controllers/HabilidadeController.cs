using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HabilidadeController : ControllerBase
    {
        private readonly IHabilidadeService _habilidadeService;

        public HabilidadeController(IHabilidadeService habilidadeService)
        {
            _habilidadeService = habilidadeService;
        }
    }
}
