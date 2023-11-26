using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJETO.IHC.Domain.DTOs.Proposta;
using PROJETO.IHC.Domain.Interfaces.Services;
using System.Net;

namespace PROJETO.IHC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PropostaController : ControllerBase
    {
        private readonly IPropostaService _propostaService;

        public PropostaController(IPropostaService propostaService)
        {
            _propostaService = propostaService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPropostaById(int id)
        {
            try
            {
                var proposta = _propostaService.GetPropostaById(id);

                return Ok(proposta);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllPropostas()
        {
            try
            {
                var listPropostas = _propostaService.GetAllPropostas();

                return Ok(listPropostas);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SaveProposta([FromBody] PropostaInsertDTO propostaInsertDTO)
        {
            try
            {
                var propostaOutputDTO = _propostaService.InsertProposta(propostaInsertDTO);

                return Ok(propostaOutputDTO);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateProposta([FromBody] PropostaUpdateDTO propostaUpdateDTO)
        {
            try
            {
                var propostaOutputDTO = _propostaService.UpdateProposta(propostaUpdateDTO);

                return Ok(propostaOutputDTO);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProposta(int id)
        {
            try
            {
                var isDelete = _propostaService.DeleteProposta(id);

                return Ok(isDelete);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
