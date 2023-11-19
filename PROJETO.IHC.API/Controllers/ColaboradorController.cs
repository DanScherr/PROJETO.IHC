using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJETO.IHC.Domain.Interfaces.Services;
using System.Net;

namespace PROJETO.IHC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetColaboradoresById(int id)
        {
            try
            {
                var colaborador = _colaboradorService.GetColaboradorById(id);

                return Ok(colaborador);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllColaboradores()
        {
            try
            {
                var listColaboradores = _colaboradorService.GetAllColaboradores();

                return Ok(listColaboradores);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
