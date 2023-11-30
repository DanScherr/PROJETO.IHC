using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJETO.IHC.Domain.DTOs.Colaborador;
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

        [HttpPost]
        public IActionResult SaveColaborador([FromBody] ColaboradorInsertDTO colaboradorInsertDTO)
        {
            try
            {
                var colaboradorOutputDTO = _colaboradorService.InsertColaborador(colaboradorInsertDTO);

                return Ok(colaboradorOutputDTO);
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
        public IActionResult UpdateColaborador([FromBody] ColaboradorUpdateDTO colaboradorUpdateDTO)
        {
            try
            {
                var colaboradorOutputDTO = _colaboradorService.UpdateColaborador(colaboradorUpdateDTO);

                return Ok(colaboradorOutputDTO);
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
        public IActionResult DeleteColaborador(int id)
        {
            try
            {
                var isDelete = _colaboradorService.DeleteColaborador(id);

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

        [HttpPost]
        public IActionResult LoginColaborador([FromBody] ColaboradorLoginDTO colaboradorLoginDTO)
        {
            try
            {
                var idColaborador = _colaboradorService.LoginColaborador(colaboradorLoginDTO);

                return Ok(new { id = idColaborador });
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
