using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tennis
{

    public class Referee : Person

    {
        public DateTime LicenseAcquired { get; set; }
        public DateTime LicenseRenewed { get; set; }

        public Referee(int ID, string firstName, string middleName, string lastName, DateTime DateOfBirth, 
            Gender gender, string country, string countryCode, DateTime licenseAcquired, DateTime licenseRenewed) 
           : base(ID, firstName, middleName, lastName, DateOfBirth, gender, country, countryCode)
        {
            
            this.LicenseAcquired = licenseAcquired;
            this.LicenseRenewed = licenseRenewed;
        }

        public override string ToString()
        {
            return "Referee: " + FirstName + " " + MiddleName + " " + LastName + ", " + "born " + DateOfBirth + " " + ", " + Age + " " + "years old " + ", " + " " + 
            Gender + ", " + " " +  Country + ", " + " " + CountryCode + ", " + " " + "License acquired:  " 
            + LicenseAcquired + ", " + " License renewed:  " + LicenseRenewed;

        }
    }

}
