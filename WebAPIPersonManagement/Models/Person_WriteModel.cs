using WebAPIPersonManagement.Database;

namespace WebAPIPersonManagement.Models
{
    public class Person_WriteModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonTypeID { get; set; }

        internal Person CreatePersonFromModel()
        {
            Person p = new Person
            {
                ID = ID,
                Name = Name,
                Age = Age,
                PersonTypeID = PersonTypeID
            };
            return p;
        }
    }
}
