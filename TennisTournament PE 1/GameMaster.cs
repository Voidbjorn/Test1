using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class GameMaster : Referee
    {
        public GameMaster(int ID, string firstName, string middleName, string lastName,
            DateTime DateOfBirth, Gender Gender, string Country, string countryCode,
            DateTime licenseAcquired, DateTime licenseRenewed)
            : base(ID, firstName, middleName, lastName, DateOfBirth, Gender, Country,
            countryCode, licenseAcquired, licenseRenewed)
        {}

        public override string ToString()
        {
            return "Game Master: " + FirstName + " " + MiddleName + " " + LastName + ", " + "born " + DateOfBirth + " " + ", " + Age + " " + "years old " + ", " + " " +
            Gender + ", " + " " + Country + ", " + " " + CountryCode + ", " + " " + "License acquired:  " 
            + LicenseAcquired + ", " + " License renewed:  " + LicenseRenewed;
        }



    }
}
