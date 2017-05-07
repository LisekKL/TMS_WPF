using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament_Management_Software.Helpers.Enums;

namespace Tournament_Management_Software.Model
{
    public class Person
    {      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public GenderEnum Gender { get; set; }
        public int GetAge() { return DateTime.Now.Year - DateOfBirth.Year; }
    }
}
