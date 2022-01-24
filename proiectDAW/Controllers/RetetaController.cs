using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models.Many_To_Many;
using proiectDAW.Services;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetetaController : ControllerBase
    {
        private readonly IRetetaService _retetaService;

        public RetetaController(IRetetaService retetaService)
        {
            _retetaService = retetaService;
        }

        [HttpGet("allFromCollection/{id}")]
        public IActionResult getAllFromCollection([FromRoute] string id)
        {
            var guidId = new Guid(id);
            var retete = _retetaService.getReteteFromCollection(guidId);
            return Ok(retete);
        }

        [HttpPost("{colId}")]
        public IActionResult AddReteta(Reteta reteta, Guid colId)
        {
            var result = _retetaService.createReteta(reteta, colId);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteReteta([FromRoute] string id)
        {
            Guid guidId = new Guid(id);
            Reteta retetaToDelete = _retetaService.FindById(guidId);
            if (retetaToDelete == null)
            {
                return NotFound();
            }
            _retetaService.deleteReteta(retetaToDelete);
            _retetaService.Save();

            return Ok(retetaToDelete);
        }

        [HttpPatch("{retetaId}")]
        public IActionResult Patch([FromRoute] string retetaId, [FromBody] JsonPatchDocument<Reteta> reteta)
        {
            Guid parsedId = new Guid(retetaId);
            Reteta retetaToUpdate = _retetaService.FindById(parsedId);

            if (retetaToUpdate == null)
            {
                return NotFound();
            }

            reteta.ApplyTo(retetaToUpdate, ModelState); 
            _retetaService.Save();

            return Ok(retetaToUpdate);
        }
    }
}
