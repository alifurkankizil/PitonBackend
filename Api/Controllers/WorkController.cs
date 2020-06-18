using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.DTO;
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
        public IActionResult Update([FromQuery] int id, [FromBody] WorkDTO model)
        {
             return BadRequest();
        }

    }
}
