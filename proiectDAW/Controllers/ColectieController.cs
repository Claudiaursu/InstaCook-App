using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models.Authentication;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Services;
using proiectDAW.Utilities;
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
        public IActionResult getAllWithInclude(string userID)
        {
            Guid parsedId = new Guid(userID);
            var usersList = _colectieService.getAllForUser(parsedId);
            return Ok(usersList);
        }

        //[Authorization(Rol.Admin)]
        [HttpPost("{userId}")]
        public IActionResult AddColectie(Colectie colectie, Guid userId)
        {
            var result = _colectieService.createColectie(colectie, userId);
            return Ok(result);
        }

        // partial update
        [HttpPatch("{id}")]
        public IActionResult UpdateColectie([FromRoute] string id, [FromBody] JsonPatchDocument<Colectie> colectie)
        {
            Guid parsedId = new Guid(id);
            if (colectie != null)
            {
                Colectie colectieToUpdate = _colectieService.FindById(parsedId);

                //var colectieToUpdate = (_student => _student.id.equals(id));
                colectie.ApplyTo(colectieToUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Colectie colectieUpdated = _colectieService.FindById(parsedId);
                return Ok(colectieUpdated);
            }
            else
            {
                return BadRequest();
            }


        }

        //full update
        [HttpPut("{id}")]
        public ActionResult FullUpdateColectie(string id, Colectie colectie)
        {
            try
            {
                Guid parsedId = new Guid(id);
                if (parsedId != colectie.Id)
                    return BadRequest("Employee ID mismatch");

                var colectieToUpdate = _colectieService.FindById(parsedId);

                if (colectieToUpdate == null)
                    return NotFound($"Colectie with Id = {id} not found");

                var updated = _colectieService.updateColectie(parsedId, colectie);
                return Ok(updated);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpPatch("{colId}")]
        public IActionResult Patch([FromRoute] string colId, [FromBody] JsonPatchDocument<Colectie> colectie)
        {
            Guid parsedId = new Guid(colId);
            Colectie colectieToUpdate = _colectieService.FindById(parsedId);

            if (colectieToUpdate == null)
            {
                return NotFound();
            }

            colectie.ApplyTo(colectieToUpdate, ModelState); 
            _colectieService.Save();

            return Ok(colectieToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteColectie([FromRoute] string id)
        {
            Guid guidId = new Guid(id);
            Colectie colectieToDelete = _colectieService.FindById(guidId); 
            if (colectieToDelete == null)
            {
                return NotFound();
            }
            _colectieService.deleteColectie(colectieToDelete);
            _colectieService.Save();



            return Ok(colectieToDelete);
        }
    }
}

