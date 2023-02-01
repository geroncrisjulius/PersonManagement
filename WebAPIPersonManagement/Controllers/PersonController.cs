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
        public ActionResult<IEnumerable<Person_GetModel>> GetAllPersons()
        {
            IEnumerable<Person> persons = _context.Persons
                .Include(p => p.PersonType)
                .OrderBy(p => p.ID);

            var pList = new List<Person_GetModel>();
            foreach (Person p in persons)
            {
                pList.Add(new Person_GetModel(p));
            }


            return Ok(pList);
        }

        [HttpGet("{id}")]
        public ActionResult<Person_GetModel> GetPerson(int id)
        {
            var person = _context.Persons
                .Include(p => p.PersonType)
                .FirstOrDefault(p => p.ID == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(new Person_GetModel(person));
        }

        //private Person_GetModel CreatePersonGetModel(Person person)
        //{
        //    Person_GetModel pModel = new Person_GetModel
        //    {
        //        ID = person.ID,
        //        Name = person.Name,
        //        Age = person.Age,
        //        PersonTypeID = person.PersonTypeID,
        //        PersonTypeDescription = person.PersonType == null ? "" : person.PersonType.Description
        //    };
        //    return pModel;
        //}

        //private Person CreatePersonFromModel(Person_WriteModel personModel)
        //{
        //    Person p = new Person
        //    {
        //        ID = personModel.ID,
        //        Name = personModel.Name,
        //        Age = personModel.Age,
        //        PersonTypeID = personModel.PersonTypeID
        //    };
        //    return p;
        //}

        [HttpPost]
        public IActionResult CreatePerson(Person_WriteModel person)
        {

            if (!_context.PersonTypes.Any(pt => pt.PersonTypeID == person.PersonTypeID))
            {
                return BadRequest();
            }

            //Person p = CreatePersonFromModel(person);
            Person p = person.CreatePersonFromModel();
            _context.Persons.Add(p);
            _context.SaveChanges();
            return CreatedAtAction(nameof(CreatePerson), new { id = p.ID }, p);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person_WriteModel person)
        {
            if (id != person.ID)
            {
                return BadRequest();
            }

            var tmpPerson = _context.Persons.FirstOrDefault(p => p.ID == person.ID);
            if (tmpPerson == null)
            {
                return NotFound();
            }

            if (!_context.PersonTypes.Any(pt => pt.PersonTypeID == person.PersonTypeID))
            {
                return BadRequest();
            }

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
