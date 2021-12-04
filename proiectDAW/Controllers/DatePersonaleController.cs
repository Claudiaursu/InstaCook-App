using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models.One_To_One;
using proiectDAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatePersonaleController : ControllerBase
    {
        private readonly IDatePersonaleService _datePersonaleService;

        public DatePersonaleController(IDatePersonaleService datePersonaleService)
        {
            _datePersonaleService = datePersonaleService;
        }

        [HttpPost("fromBody")]
        public IActionResult AddWithFromBody(Date_Personale date)
        {
            var result = _datePersonaleService.create(date);
            return Ok(result);
        }
    }
}
