using ElectroTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTask.Services
{
    public interface IPersonService
    {
        Task<IReadOnlyCollection<Person>> GetPeople();
        Task<Person> GetPersonById(int id);
        Task<Person> GetPaternalGrandfather(int id);
        Task<Person> GetPaternalGreatGrandfather(int id);
        Task<IReadOnlyCollection<Person>> GetGreatGrandchildren(int id);
    }
}
