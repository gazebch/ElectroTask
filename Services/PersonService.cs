using ElectroTask.Data;
using ElectroTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectroTask.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonsContext _context;

        public PersonService(PersonsContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Person>> GetPeople()
        {
            return _context.People.ToArray();
        }
        public async Task<Person> GetPersonById(int id)
        {
            var person = await _context.People.Include(p => p.Parent).FirstOrDefaultAsync(p => p.Id == id);

            return person;
        }

        public async Task<Person> GetPaternalGrandfather(int id)
        {
            var person = await _context.People.Include(p => p.Parent).ThenInclude(f => f.Parent).FirstOrDefaultAsync(p => p.Id == id);

            //return person.Parent.Parent;
            return person?.Parent?.Parent;
        }

        public async Task<Person> GetPaternalGreatGrandfather(int id)
        {
            var person = await _context.People.Include(p => p.Parent).ThenInclude(f => f.Parent).ThenInclude(gf => gf.Parent).FirstOrDefaultAsync(p => p.Id == id);

            return person?.Parent?.Parent?.Parent;
        }

        public async Task<IReadOnlyCollection<Person>> GetGreatGrandchildren(int id)
        {
            var children = await _context.People
                .Where(p => p.Parent.Parent.ParentId == id)
                .ToListAsync();

            return children?.ToArray() ?? ArraySegment<Person>.Empty;
        }
    }
}
