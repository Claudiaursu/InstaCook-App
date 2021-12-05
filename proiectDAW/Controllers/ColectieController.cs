using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColectieController : ControllerBase
    {
        private readonly IColectieService _colectieService;

        public ColectieController(IColectieService colectieService)
        {
            _colectieService = colectieService;
        }

        [HttpGet("getAllForUser/{userId}")]
        public IActionResult getAllWithInclude(Guid userID)
        {
            var usersList = _colectieService.getAllForUser(userID);
            return Ok(usersList);
        }

        [HttpPost("{userId}")]
        public IActionResult AddColectie(Colectie colectie, Guid userId)
        {
            var result = _colectieService.createColectie(colectie, userId);
            return Ok(result);
        }
    }
}
