using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppPersonManagement
{
    public class Person_GetModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonTypeID { get; set; }
        public string PersonTypeDescription { get; set; }

    }

    public class Person_WriteModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonTypeID { get; set; }

    }

    public class PersonType_GetModel
    {
        public int PersonTypeID { get; set; }
        public string Description { get; set; }


    }
}