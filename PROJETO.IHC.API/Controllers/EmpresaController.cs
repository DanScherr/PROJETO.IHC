using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJETO.IHC.Domain.DTOs.Empresa;
using PROJETO.IHC.Domain.Interfaces.Services;
using System.Net;

namespace PROJETO.IHC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmpresasById(int id)
        {
            try
            {
                var empresa = _empresaService.GetEmpresaById(id);

                return Ok(empresa);
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
        public IActionResult GetAllEmpresas()
        {
            try
            {
                var listEmpresas = _empresaService.GetAllEmpresas();

                return Ok(listEmpresas);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SaveEmpresa([FromBody] EmpresaInsertDTO empresaInsertDTO)
        {
            try
            {
                var empresaOutputDTO = _empresaService.InsertEmpresa(empresaInsertDTO);

                return Ok(empresaInsertDTO);
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
        public IActionResult UpdateEmpresa([FromBody] EmpresaUpdateDTO empresaUpdateDTO)
        {
            try
            {
                var empresaOutputDTO = _empresaService.UpdateEmpresa(empresaUpdateDTO);

                return Ok(empresaOutputDTO);
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
        public IActionResult DeleteEmpresa(int id)
        {
            try
            {
                var isDelete = _empresaService.DeleteEmpresa(id);

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
        public IActionResult LoginEmpresa([FromBody] EmpresaLoginDTO empresaLoginDTO)
        {
            try
            {
                var idEmpresa = _empresaService.LoginEmpresa(empresaLoginDTO);

                return Ok(new { id = idEmpresa });
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
