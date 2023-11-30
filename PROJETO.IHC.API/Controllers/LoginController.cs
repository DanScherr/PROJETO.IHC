using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJETO.IHC.Domain.DTOs;
using PROJETO.IHC.Domain.Interfaces.Services;
using System.Net;

namespace PROJETO.IHC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IColaboradorService _colaboradorService;
        private readonly IEmpresaService _empresaService;

        public LoginController(IColaboradorService colaboradorService, IEmpresaService empresaService)
        {
            _colaboradorService = colaboradorService;
            _empresaService = empresaService;
        }

        [HttpPost]
        public IActionResult LoginColaborador([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var id = 0;
                var flTipoLogin = "";
                id = _colaboradorService.LoginColaborador(loginDTO);

                if (id > 0) 
                    flTipoLogin = "colaborador";

                if (id == 0)
                {
                    id = _empresaService.LoginEmpresa(loginDTO);
                    if (id > 0)
                        flTipoLogin = "empresa";
                }
                
                if (id == 0)
                    return BadRequest(new { message = "Login não encontrado!" });

                return Ok(new { id = id, flTipoLogin = flTipoLogin });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
