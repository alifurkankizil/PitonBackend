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
    [Route("work")]
    [ApiController]
    public class WorkController : ControllerBase
    {

        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(WorkDTO model)
        {
            var result = await _workService.Add(model);

            if (result)
                return CreatedAtAction(nameof(Add), null);
            else
                return BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] WorkDTO model)
        {
            var result = await _workService.Update(id, model);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpPut("change")]
        public async Task<IActionResult> ChangeState([FromQuery] Guid id, [FromBody] CompleteState state)
        {
            var result = await _workService.ChangeState(id, state);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _workService.Delete(id);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _workService.Get(id);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromBody]DateTime date, [FromQuery] WorkPeriod period)
        {
            var result = await _workService.GetAll(date, period);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        
    }
}
