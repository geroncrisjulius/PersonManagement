using WebAPIPersonManagement.Database;

namespace WebAPIPersonManagement.Models
{
    public class PersonType_GetModel
    {
        public int PersonTypeID { get; set; }
        public string Description { get; set; }

        internal PersonType_GetModel(PersonType personType)
        {
            PersonTypeID = personType.PersonTypeID;
            Description = personType.Description;
        }
    }
}
