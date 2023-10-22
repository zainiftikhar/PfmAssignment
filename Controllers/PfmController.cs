using Microsoft.AspNetCore.Mvc;
using PfmAssignment.ApiLogic;

namespace PfmAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PfmController : ControllerBase
    {
        private readonly PfmLogic _pfmLogic;

        public PfmController()
        {
            _pfmLogic = new PfmLogic();
        }

        [HttpGet("hourly")]
        public IActionResult GetHourlyData([FromQuery] DateTime dateTime)
        {
            var result = _pfmLogic.GetHourlyPfm(dateTime);

            return Ok(result);
        }

        [HttpGet("daily")]
        public IActionResult GetDailyData([FromQuery] DateTime dateTime)
        {
            var result = _pfmLogic.GetDailyPfm(dateTime);

            return Ok(result);
        }

        [HttpGet("weekly")]
        public IActionResult GetWeeklyData([FromQuery] int weekNumber, [FromQuery] int year)
        {
            var result = _pfmLogic.GetWeeklyPfm(weekNumber, year);

            return Ok(result);
        }
    }
}
