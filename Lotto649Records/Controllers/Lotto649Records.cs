using BusinessLogic.DataTransferObjects;
using BusinessLogic.Models.DataTransferObjects;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Lotto649Records.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lotto649Records : ControllerBase
    {
        private readonly IResultProcessor<ResultDto> _resultProcesser;

        public Lotto649Records(IResultProcessor<ResultDto> resultProcesser)
        {
            _resultProcesser = resultProcesser
                          ?? throw new System.ArgumentNullException(nameof(resultProcesser));
        }

        /// <summary>
        /// Calculates matched records 
        /// </summary>
        /// <param name="selection"></param>
        /// <returns>Task<IEnumerable<IActionResult>></returns>
        [HttpPost("ProcessNumbers", Name = "ProcessSelection")]
        public async Task<IActionResult> ProcessSelectionAsync([FromBody] SelectionDto selection)
        {
            try
            {
                var result = await _resultProcesser.ProcessResult(selection);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
