using System.ComponentModel.DataAnnotations;

namespace WebAPIPersonManagement.Database
{
    public class PersonType
    {
        [Key]
        public int Type { get; set; }
        public string Description { get; set; }

        public ICollection<Person> Persons { get; set; }

    }
}
