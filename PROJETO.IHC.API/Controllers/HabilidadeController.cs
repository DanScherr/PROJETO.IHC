using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJETO.IHC.Domain.DTOs.Habilidade;
using PROJETO.IHC.Domain.Interfaces.Services;
using System.Net;

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

        [HttpGet("{id:int}")]
        public IActionResult GetHabilidadesById(int id)
        {
            try
            {
                var habilidade = _habilidadeService.GetHabilidadeById(id);

                return Ok(habilidade);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllHabilidades()
        {
            try
            {
                var listHabilidades = _habilidadeService.GetAllHabilidades();

                return Ok(listHabilidades);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SaveHabilidade([FromBody] HabilidadeInsertDTO habilidadeInsertDTO)
        {
            try
            {
                var habilidadeOutputDTO = _habilidadeService.InsertHabilidade(habilidadeInsertDTO);

                return Ok(habilidadeOutputDTO);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateHabilidade([FromBody] HabilidadeUpdateDTO habilidadeUpdateDTO)
        {
            try
            {
                var habilidadeOutputDTO = _habilidadeService.UpdateHabilidade(habilidadeUpdateDTO);

                return Ok(habilidadeOutputDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteHabilidade(int id)
        {
            try
            {
                var isDelete = _habilidadeService.DeleteHabilidade(id);

                return Ok(isDelete);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
