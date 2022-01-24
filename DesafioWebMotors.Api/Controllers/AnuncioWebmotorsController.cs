using DesafioWebMotors.Domain.Dto;
using DesafioWebMotors.Domain.Entities;
using DesafioWebMotors.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DesafioWebMotors.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioWebmotorsController : ControllerBase
    {
        private readonly IServiceBase<AnuncioWebmotorsEntity, AnuncioWebmotorsDtoCreate, AnuncioWebmotorsDto, AnuncioWebmotorsDtoUpdate> _service;
        
        public AnuncioWebmotorsController(IServiceBase<AnuncioWebmotorsEntity, AnuncioWebmotorsDtoCreate, AnuncioWebmotorsDto, AnuncioWebmotorsDtoUpdate> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(200, Type = typeof(AnuncioWebmotorsDto[]))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                if (result == null || result.Count() == 0)
                    return NotFound(new { code = 404, message = "Não existem anúncios cadastrados" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, message="Falha interna do servidor" });
            }

        }

        [HttpGet("{page}/{count}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(200, Type = typeof(AnuncioWebmotorsDto[]))]
        public async Task<IActionResult> GetAll([FromRoute] int page, [FromRoute] int count)
        {
            try
            {
                var result = await _service.GetAllAsync(page, count);
                if (result == null || result.Count() == 0)
                    return NotFound(new { code = 404, message = "Não existem anúncios cadastrados" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, ex.Message });
            }

        }

        [HttpGet("{id}", Name = "GetAnnouncementById")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(AnuncioWebmotorsDto))]
        public async Task<IActionResult> GetAnnouncementById([FromRoute] long id)
        {
            try
            {
                var result = await _service.GetAsync(id);
                if (result == null)
                    return NotFound(new { code = 404, message = "Anúncio não encontrado" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(AnuncioWebmotorsDto))]
        public async Task<IActionResult> Post([FromBody] AnuncioWebmotorsDtoCreate inputDto)
        {
            try
            {
                var result = await _service.PostAsync(inputDto);
                return Created(new Uri(Url.Link("GetAnnouncementById", new { result.ID })), result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(200, Type = typeof(AnuncioWebmotorsDto))]
        public async Task<IActionResult> Put([FromBody] AnuncioWebmotorsDtoUpdate inputDto)
        {
            try
            {
                return Ok(await _service.PutAsync(inputDto));
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            try
            {
                _ = await _service.DeleteAsync(id);
                return Ok(new { code = 200, message = "ok" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 500, message = ex.Message });
            }
        }
    }
}
