using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tennis
{

    public class Player : Person

    {
        public Player(int ID, string firstName, string middleName, string lastName, DateTime DateOfBirth, Gender gender, string country, string countryCode) 
           : base(ID, firstName, middleName, lastName, DateOfBirth, gender, country, countryCode)
        { }

        public override string ToString()
        {
            return "Player: " +  FirstName + " " + LastName + " " + MiddleName + " " + ", " + "born " + 
            DateOfBirth + " " + ", " + Age + " " + "years old " + ", " + " " + Gender + ", " + " " + Country + ", " + " " + CountryCode;
        }

    }

}
