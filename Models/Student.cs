﻿namespace StudentWebApi.Models
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegistrationNo { get; set; }
    }
}
