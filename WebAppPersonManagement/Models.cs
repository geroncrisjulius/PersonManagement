using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppPersonManagement
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonTypeID { get; set; }

    }
    public class PersonType
    {
        public int Type { get; set; }
        public string Description { get; set; }


    }
}