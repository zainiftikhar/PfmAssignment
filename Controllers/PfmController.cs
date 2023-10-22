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

        /// <summary>
        /// Retrieves the total Pfm count for a specific hour and date.
        /// </summary>
        /// <param name="dateTime">The dateTime indicating the specific hour and date.</param>
        /// <returns>The total Pfm count for the specified hour and date.</returns>
        [HttpGet("hourly")]
        public IActionResult GetHourlyData([FromQuery] DateTime dateTime)
        {
            var result = _pfmLogic.GetHourlyPfm(dateTime);

            return Ok(result);
        }

        /// <summary>
        /// Retrieves the total Pfm count for a specific date.
        /// </summary>
        /// <param name="date">The date indicating the specific date.</param>
        /// <returns>The total Pfm count for the specified date.</returns>
        [HttpGet("daily")]
        public IActionResult GetDailyData([FromQuery] DateTime date)
        {
            var result = _pfmLogic.GetDailyPfm(date);

            return Ok(result);
        }

        /// <summary>
        /// Retrieves the total Pfm count for a specific week of a year.
        /// </summary>
        /// <param name="weekNumber">The weekNumber indicating the week number if the year</param>
        /// <param name="year">The year indicating the year</param>
        /// <returns>The total Pfm count for the specified week of the year.</returns>
        [HttpGet("weekly")]
        public IActionResult GetWeeklyData([FromQuery] int weekNumber, [FromQuery] int year)
        {
            var result = _pfmLogic.GetWeeklyPfm(weekNumber, year);

            return Ok(result);
        }
    }
}
