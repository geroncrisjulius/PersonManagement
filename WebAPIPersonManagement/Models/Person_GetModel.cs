﻿using System.Reflection;

namespace WebAPIPersonManagement.Models
{
    public class Person_GetModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonTypeID { get; set; }
        public string  PersonTypeDescription { get; set; }
    }
}