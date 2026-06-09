using Contracts;
using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await peopleService.GetAsync();
            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            var response = await peopleService.GetByIDAsync(id);
            if (response is null)
            {
                return NotFound();
            }
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewPersonDTO newPersonDTO)
        {
            bool response = await peopleService.PostAsync(newPersonDTO);
            return Ok(response);
        }

        [HttpPost("{id}/Address")]
        public async Task<IActionResult> PostAddress(int id, [FromBody] NewAddressDTO dto)
        {
            await peopleService.PostAddress(id, dto.City, dto.PostalCode, dto.Street);
            return Ok();
        }

        [HttpGet("{id}/Addresses")]
        public async Task<IActionResult> GetAddresses(int id)
        {
            return Ok(await this.peopleService.GetAddresses(id));
        }
    } 
}
