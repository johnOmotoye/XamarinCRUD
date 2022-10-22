using System;

namespace StudentCRUDApp.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Comment { get; set; }
    }
}