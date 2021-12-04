using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models;
using proiectDAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorController : ControllerBase
    {
        private readonly IUtilizatorService _utilizatorService;

        public UtilizatorController(IUtilizatorService utilizatorService)
        {
            _utilizatorService = utilizatorService;
        }

        [HttpGet]
        public IActionResult getByFullName(string nume, string prenume)
        {
            var result = _utilizatorService.getUtilizatorByName(nume, prenume);
            return Ok(result);
        }

        [HttpGet("detaliiUtilizator")]
        public IActionResult getByFullNameWithData(string nume, string prenume)
        {
            var result = _utilizatorService.getUtilizatorByNameWithDate(nume, prenume);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddWithFromBody(Utilizator utiliz)
        {
            var result = _utilizatorService.createUtilizator(utiliz);
            return Ok(result);
        }
    }
}
