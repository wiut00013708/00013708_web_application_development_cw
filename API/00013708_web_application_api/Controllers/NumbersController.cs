using _00013708_web_application_api.Models.Domain;
using _00013708_web_application_api.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _00013708_web_application_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private readonly IContactRepository<PhoneNumber> _repository;
        public NumbersController(IContactRepository<PhoneNumber> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<PhoneNumber>> GetAll() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PhoneNumber), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var numberItem = await _repository.GetByIDAsync(id);
            return numberItem == null ? NotFound() : Ok(numberItem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(PhoneNumber number)
        {
            await _repository.CreateAsync(number);
            //return Ok(feat);
            return CreatedAtAction(nameof(GetByID), new { id = number.Id }, number);

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(PhoneNumber number)
        {
            await _repository.UpdateAsync(number);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }


    }
}
