using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Tennis
{
        public class ReadFile 
        {
            public List<Player> players = new List<Player>();
            public List<Referee> referees = new List<Referee>();
            public List<GameMaster> gameMaster = new List<GameMaster>();
            public string Delimiter { get; set; }

            public ReadFile(string delim = "|")
            {
                Delimiter = delim;
            }

            public List<Player> GetPlayers(string filePath, string sex)
            {
                TextFieldParser par = new TextFieldParser(filePath);
                par.TextFieldType = FieldType.Delimited;
                par.SetDelimiters(Delimiter);
                while (!par.EndOfData)
                {
                    string[] fields = par.ReadFields();
                    int ID = Int32.Parse(fields[0]);
                    string FirstName = fields[1];
                    string MiddleName = fields[2];
                    string LastName = fields[3];
                    DateTime DateOfBirth = DateTime.Parse(fields[4]);
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), sex);
                    string Country = fields[5];
                    string CountryCode = fields[6];

                    var p = new Player(ID, FirstName, MiddleName, LastName, DateOfBirth, Gender, Country, CountryCode);
                    players.Add(p);
                }

                par.Close();

                return players;
            }


            public List<Referee> GetReferee(string filePath, string sex)
            {
                TextFieldParser par = new TextFieldParser(filePath);
                par.TextFieldType = FieldType.Delimited;
                par.SetDelimiters(Delimiter);
                while (!par.EndOfData)
                {
                    string[] fields = par.ReadFields();
                    int ID = Int32.Parse(fields[0]);
                    string FirstName = fields[1];
                    string MiddleName = fields[2];
                    string LastName = fields[3];
                    DateTime DateOfBirth = DateTime.Parse(fields[4]);
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), sex);
                    string Country = fields[5];
                    string CountryCode = fields[6];
                    DateTime LicenseAcquired = DateTime.Parse(fields[7]);
                    DateTime LicenseRenewed = DateTime.Parse(fields[8]);

                    var p = new Referee(ID, FirstName, MiddleName, LastName, DateOfBirth, Gender,
                                        Country, CountryCode, LicenseAcquired, LicenseRenewed);
                    referees.Add(p);
                }

                par.Close();

                return referees;
            }


            public List<GameMaster> GetGameMaster(string filePath, string sex)
            {
                TextFieldParser par = new TextFieldParser(filePath);
                par.TextFieldType = FieldType.Delimited;
                par.SetDelimiters(Delimiter);
                while (!par.EndOfData)
                {
                    string[] fields = par.ReadFields();
                    int ID = Int32.Parse(fields[0]);
                    string FirstName = fields[1];
                    string MiddleName = fields[2];
                    string LastName = fields[3];
                    DateTime DateOfBirth = DateTime.Parse(fields[4]);
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), sex);
                    string Country = fields[5];
                    string CountryCode = fields[6];
                    DateTime LicenseAcquired = DateTime.Parse(fields[7]);
                    DateTime LicenseRenewed = DateTime.Parse(fields[8]);

                    var p = new GameMaster(ID, FirstName, MiddleName, LastName, DateOfBirth, Gender,
                                           Country, CountryCode, LicenseAcquired, LicenseRenewed);
                    gameMaster.Add(p);
                }

                par.Close();

                return gameMaster;
            }
        }
}
