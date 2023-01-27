using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPersonManagement.Database;
using WebAPIPersonManagement.Models;

namespace WebAPIPersonManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly PersonManagerContext _context;
        public PersonController(PersonManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            IEnumerable<Person> persons = _context.Persons;
            persons = persons == null ? new List<Person>() : persons;
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = _context.Persons
                .FirstOrDefault(p => p.ID == id);
            return person == null ? NotFound() : Ok(person);
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {

            //TODO add error on missing persontype
            _context.Persons.Add(person);
            _context.SaveChanges();
            return CreatedAtAction(nameof(CreatePerson), new { id = person.ID }, person);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            if(id != person.ID)
            {
                return BadRequest();
            }

            var tmpPerson = _context.Persons.FirstOrDefault(p => p.ID == person.ID);
            if (tmpPerson == null)
            {
                return NotFound();
            }

            //TODO add error on missing person type

            tmpPerson.Name = person.Name;
            tmpPerson.Age = person.Age;
            tmpPerson.PersonTypeID = person.PersonTypeID;
            _context.SaveChanges();
            return NoContent();

        }



        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.ID == id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();
            return NoContent();
        }

        



    }
}
