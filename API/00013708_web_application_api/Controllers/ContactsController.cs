﻿using _00013708_web_application_api.Data;
using _00013708_web_application_api.Models.Domain;
using _00013708_web_application_api.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _00013708_web_application_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository<Contact> _repository;

        public ContactsController(IContactRepository<Contact> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAll() => await _repository.GetAllAsync();



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var cont = await _repository.GetByIDAsync(id);
            return cont == null ? NotFound() : Ok(cont);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Contact cont)
        {
            await _repository.CreateAsync(cont);
            return Ok(cont);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Contact cont)
        {
            await _repository.UpdateAsync(cont);
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
