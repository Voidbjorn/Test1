using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public enum Gender { Male, Female, };

    public class Person

    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get { return GetAge(DateOfBirth); } }
        public Gender Gender;
        public string Country { get; set; }
        public string CountryCode { get; set; }
       
        public Person(int ID, string firstName, string middleName, string lastName, 
            DateTime DateOfBirth, Gender gender, string country, string countryCode)
        {
            this.ID = ID;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = gender;
            this.Country = country;
            this.CountryCode = countryCode;
        }

        public int GetAge(DateTime DateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }

    }

}