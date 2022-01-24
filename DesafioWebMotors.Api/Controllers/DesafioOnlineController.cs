using DesafioWebmotors.DesafioOnline;
using DesafioWebMotors.Domain.Dto.DesafioOnline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DesafioWebMotors.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesafioOnlineController : ControllerBase
    {
        private readonly IDesafioOnlineClient _desafioOnlineClient;

        public DesafioOnlineController(IDesafioOnlineClient desafioOnlineClient)
        {
            _desafioOnlineClient = desafioOnlineClient;
        }

        [HttpGet("make")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(200, Type = typeof(MakeDto[]))]
        public async Task<IActionResult> GetMakes()
        {
            try
            {
                var result = await _desafioOnlineClient.GetMakeAsync();
                if (result == null || result.Count() == 0)
                    return NotFound(new { code = 404, message = "Fabricantes não encontrados" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, message = "Falha interna do servidor" });
            }

        }

        [HttpGet("model")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(200, Type = typeof(ModelDto[]))]
        public async Task<IActionResult> GetModels([FromQuery]int makeId)
        {
            try
            {
                var result = await _desafioOnlineClient.GetModelAsync(makeId);
                if (result == null || result.Count() == 0)
                    return NotFound(new { code = 404, message = "Modelos não encontrados" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, message = "Falha interna do servidor" });
            }

        }

        [HttpGet("version")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(200, Type = typeof(ModelDto[]))]
        public async Task<IActionResult> GetVersions([FromQuery] int modelId)
        {
            try
            {
                var result = await _desafioOnlineClient.GetVersionAsync(modelId);
                if (result == null || result.Count() == 0)
                    return NotFound(new { code = 404, message = "Versões não encontradas" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, message = "Falha interna do servidor" });
            }

        }

        [HttpGet("vehicle")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(200, Type = typeof(ModelDto[]))]
        public async Task<IActionResult> GetVehicles([FromQuery] int page)
        {
            try
            {
                var result = await _desafioOnlineClient.GetVehicleAsync(page);
                if (result == null || result.Count() == 0)
                    return NotFound(new { code = 404, message = "Veículos não encontrados" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, message = "Falha interna do servidor" });
            }

        }
    }
}
