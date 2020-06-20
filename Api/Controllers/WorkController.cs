using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.DTO;
using Api.Models.Enum;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Work")]
    [ApiController]
    public class WorkController : ControllerBase
    {

        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        /// <summary>
        /// Yeni bir görev ekler
        /// </summary>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] WorkDTO model)
        {
            var result = await _workService.Add(model);

            if (result)
                return CreatedAtAction(nameof(Add), null);
            else
                return BadRequest();
        }

        /// <summary>
        /// Görevi günceller
        /// </summary>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] WorkDTO model)
        {
            var result = await _workService.Update(id, model);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Görevin durumunu değiştirir
        /// </summary>
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeState([FromQuery] Guid id, [FromBody] CompleteState state)
        {
            var result = await _workService.ChangeState(id, state);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

        /// <summary>
        /// GGrevi siler
        /// </summary>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _workService.Delete(id);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Görevi döndürür
        /// </summary>
        [HttpGet("GetById")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _workService.Get(id);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        /// <summary>
        /// Periyota uygun görev listesini döndürür
        /// </summary>
        [HttpGet("GetByPeriod")]
        public async Task<IActionResult> GetAll([FromBody]DateTime date, [FromQuery] WorkPeriod period)
        {
            var result = await _workService.GetAll(date, period);

            if (result != null && result.Count > 0)
                return Ok(result);
            else
                return NotFound();
        }

        
    }
}
