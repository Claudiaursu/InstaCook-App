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
    public class BucatarieController : ControllerBase
    {

        private readonly IBucatarieService _bucatarieService;

        public BucatarieController(IBucatarieService bucatarieService)
        {
            _bucatarieService = bucatarieService;
        }

        [HttpGet("getAll")]
        public IActionResult getAllBucatarii()
        {
            var result = _bucatarieService.getAll();
            return Ok(result);
        }

        // autorizare rol admin 
        // bucatariile nu vor putea fi adaugate de user, acestea exista deja in baza de date
        [Authorization(Rol.Admin)]
        [HttpPost]
        public IActionResult AddWithFromBody(Bucatarie bucatarie)
        {
            var result = _bucatarieService.createBucatarie(bucatarie);
            return Ok(result);
        }

        // autorizare rol admin 
        [Authorization(Rol.Admin)]
        [HttpPatch("{bucId}")]
        public IActionResult Patch([FromRoute] string bucId, [FromBody] JsonPatchDocument<Bucatarie> bucatarie)
        {
            Guid parsedId = new Guid(bucId);
            Bucatarie bucatarieToUpdate = _bucatarieService.FindById(parsedId);

            if (bucatarieToUpdate == null)
            {
                return NotFound();
            }

            bucatarie.ApplyTo(bucatarieToUpdate, ModelState);
            _bucatarieService.Save();

            return Ok(bucatarieToUpdate);
        }

        // autorizare rol admin 
        [Authorization(Rol.Admin)]
        [HttpDelete("{id}")]
        public IActionResult DeleteBucatarie([FromRoute] string id)
        {
            Guid guidId = new Guid(id);
            Bucatarie bucatarieToDelete = _bucatarieService.FindById(guidId);
            if (bucatarieToDelete == null)
            {
                return NotFound();
            }
            _bucatarieService.deleteBucatarie(bucatarieToDelete);
            _bucatarieService.Save();



            return Ok(bucatarieToDelete);
        }
    }
}
