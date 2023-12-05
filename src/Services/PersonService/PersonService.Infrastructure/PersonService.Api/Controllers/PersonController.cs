using System;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using PersonService.Application.Services.Dto.PersonDto;
using PersonService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PersonService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        
        [HttpGet("full/{personId:guid}")]
        public async Task<ActionResult> GetFull([FromRoute] Guid personId)
        {
            Guard.Against.Default(personId, nameof(personId));

            var fullPerson = await _personService.GetFullPersonByIdAsync(personId);
            return Ok(fullPerson);
        }

        [HttpGet("{personId:guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid personId)
        {
            Guard.Against.Default(personId, nameof(personId));

            var personResponse = await _personService.GetPersonByIdAsync(personId);
            return Ok(personResponse);
        }

        [HttpPost("register")]
        public async Task<ActionResult> PersonRegistration([FromBody] PersonRegisterRequest request)
        {
            Guard.Against.Null(request, nameof(request));

            var personId = await _personService.RegistrationAsync(request);
            return Ok(personId);
        }

        [HttpPost("auth")]
        public async Task<ActionResult> Authorization([FromBody] PersonAuthorizationRequest request)
        {
            Guard.Against.Null(request, nameof(request));

            var personId = await _personService.AuthorizationAsync(request);
            return Ok(personId);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] UpdatePersonRequest request)
        {
            Guard.Against.Null(request, nameof(request));

            await _personService.UpdateAsync(request);
            return Ok();
        }

        [HttpDelete("{personId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid personId)
        {
            Guard.Against.Default(personId, nameof(personId));

            await _personService.DeleteAsync(personId);
            return Ok();
        }
    }
}