﻿using Microsoft.AspNetCore.Mvc;
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
            var result = _pfmLogic.GetPfmData().
                Where(x => x.DateFrom.Hour == dateTime.Hour && x.DateFrom.Date == dateTime.Date)
                .Sum(x => x.Count);

            return Ok(result);
        }

        [HttpGet("daily")]
        public IActionResult GetDailyData([FromQuery] DateTime dateTime)
        {
            var result = _pfmLogic.GetPfmData().
                Where(x => x.DateFrom.Date == dateTime.Date)
                .Sum(x => x.Count);

            return Ok(result);
        }

        [HttpGet("weekly")]
        public IActionResult GetWeeklyData([FromQuery] DateTime dateTime)
        {
            var result = _pfmLogic.GetPfmData().
                Where(x => x.DateFrom.Date >= dateTime.Date.AddDays(-7) && x.DateFrom.Date <= dateTime.Date)
                .Sum(x => x.Count);

            return Ok(result);
        }
    }
}
