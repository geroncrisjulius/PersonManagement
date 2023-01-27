using System.ComponentModel.DataAnnotations;

namespace WebAPIPersonManagement.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonTypeID { get; set; }

        //public PersonType PersonType { get; set; }
    }
}
