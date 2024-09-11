using Locations.Interfaces;
using Locations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {


        private readonly ILocation _location;

        public LocationController(ILocation location)
        {
            
            _location = location;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            var Deatils=await _location.GetAllLocation();
            if (Deatils!=null)
            {
                return Ok(Deatils);
            }
            return BadRequest("the Details are unavailable");    
        }
        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteLocation(string Name)
        {
            var deletedLocation=await _location.DeleteLocation(Name);
            if (deletedLocation != null)
            {

                return Ok("the Details are Deleted");
            }
            return BadRequest("the details not Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> updateLocation(LocationDTO location, int id)
        {
            var updateddetail=await _location.updateLocation(location, id);
            if (updateddetail != null)
            {

                return Ok("the Details are updated");
            }
            return BadRequest("the details not updated");
        }
        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationDTO location)
        {
            var addeddetail=await _location.AddLocation(location);
            if (addeddetail != null)
            {
                return Ok("the Detail Added Succesfully");
            }
            return BadRequest("The Detail Not Added ");
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetAllLocationbyid(string Name)
        {

            var datas = await _location.GetAllLocationbyid(Name);
            if (datas != null)
            {
                return Ok(datas);
            }

            return NotFound("No Such Data Found");
        }
    }
}
