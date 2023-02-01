using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebAPIPersonManagement.Database;
using WebAPIPersonManagement.Models;

namespace WebAPIPersonManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonTypeController : Controller
    {

        private readonly PersonManagerContext _context;
        public PersonTypeController(PersonManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonType_GetModel>> GetAllPersonTypes()
        {
            IEnumerable<PersonType> personTypes = _context.PersonTypes.OrderBy(pt => pt.PersonTypeID);
            personTypes = personTypes == null ? new List<PersonType>() : personTypes ;
            return Ok(personTypes);
        }

        [HttpGet("{type}")]
        public ActionResult<PersonType_GetModel> GetPersonType(int type)
        {
            var personType = _context.PersonTypes.FirstOrDefault(pt => pt.PersonTypeID == type);
            return personType == null ? NotFound() : Ok(personType);
            
        }
    }
}
