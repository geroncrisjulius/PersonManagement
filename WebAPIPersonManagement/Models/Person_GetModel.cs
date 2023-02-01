using System.Reflection;
using WebAPIPersonManagement.Database;

namespace WebAPIPersonManagement.Models
{
    public class Person_GetModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonTypeID { get; set; }
        public string PersonTypeDescription { get; set; }


        internal Person_GetModel(Person person)
        {
            ID = person.ID;
            Name = person.Name;
            Age = person.Age;
            PersonTypeID = person.PersonTypeID;
            PersonTypeDescription = person.PersonType == null ? "" : person.PersonType.Description;
        }
    }
}
