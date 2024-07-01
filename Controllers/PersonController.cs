using ElectroTask.Data;
using ElectroTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using ElectroTask.Services;

namespace ElectroTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonsContext _context;
        private readonly IPersonService _personService;

        public PersonController(PersonsContext context, IPersonService personService)
        {
            _context = context;
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<Person>> GetPeople()
            => await _personService.GetPeople();

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await _personService.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpGet("{id}/paternal-grandfather")]
        public async Task<ActionResult<Person>> GetPaternalGrandfather(int id)
        {
            var person = await _personService.GetPaternalGrandfather(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpGet("{id}/paternal-great-grandfather")]
        public async Task<ActionResult<Person>> GetPaternalGreatGrandfather(int id)
        {
            var person = await _personService.GetPaternalGreatGrandfather(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpGet("{id}/great-grandchildren")]
        public async Task<IReadOnlyCollection<Person>> GetGreatGrandchildren(int id)
            => await _personService.GetGreatGrandchildren(id);  
    }
}
