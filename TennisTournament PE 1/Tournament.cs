using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

/*
Vi har arbejdet med miniprojektet i gruppen. Programmet er udviklet af:
Pawel Mateusz Zelazny, Stefan B. Pedersen, Caner Kilic, Farhad A. Nabizada, Niclas Broen Nielsen og Bjørn-Lukas K. Mortensen.
Programmet indeholder superklassen Person.cs, som klasserne Player.cs og Referee.cs nedarver fra. Klassen GameMaster.cs nedarver fra Referee.cs. 
Klassen Game.cs  definere en tenniskamp, som kan være “male” eller “female”. og metoder til hvordan en vinder vælges. Game.cs bruger klasserne ‘Player.cs’ og ‘Referee.cs’.
I programmet har vi brugt Microsoft.Nets Random klassen,  for at simulere kampe tilfældigt mellem forskellige spillere.
“ReadFile.cs” klassen indlæser tekst filerne (fra Moodle), hvori der opbevares alle informationer omkring objekter fra Person klassen .
Vi har brugt klassen TextFieldParser, som er nedarvet fra Microsoft.VisualBasic.IO, som giver metoder og properties til parsing af tekstfiler.
I klassen “Simulation.cs” findes der metoder til at simulere single male og female kampe, afhængig af inputtet fra brugeren af programmet.
Yderligere slutter kampene af med kvart-, semi- og finalen for både single male og single female.
“Program.cs” er klassen, som indeholder programmets main metode og dermed starter spillet.
Klassen “Tournament.cs” indeholder alle metoder, som simulerer programmets interface. Vi har tilføjet mange Console.WriteLines for at lave en simpel grænseflade og lave programmet mere brugbart.
Ud over det, indeholder klassen Tournament.cs properties og er programmets grundlag, som gør det muligt for alle metoder at fungere korrekt. 
Antagelser:
Vi har antaget at en male single består af 5 sets og en female single består af 3 sets, og derfor har vi implementeret det.  
Vi har lavet metoder til at sortere hele lister af deltagere, alfabetisk i forhold til deres fornavn og efternavn. 
En anden antagelse var at lave turneringer, som består udelukkende af female eller male single kampe, så det vil naturligt medføre at female ikke kan spille mod male og omvendt.

    


*/


namespace Tennis
{
    public class Tournament

    {
        private string Name { get; set; }
        private int Year { get; set; }
        private int Size { get; set; }
        List<Player> Players { get; set; }
        List<Referee> Referees { get; set; }
        public GameMaster gameMaster { get; set; }


        public Tournament(string name, int year, int size)
        {
            this.Name = name;
            this.Year = year;
            this.Size = size;
        }

        public void StartGame(string playersFilePath, string refereesFilePath,
            int numberOfPlayers, int numberOfReferees, string sex)
        {
            List<Player> players = new List<Player>();
            List<Referee> referees = new List<Referee>();
            Simulation runGame = new Simulation();
            ReadFile read = new ReadFile();
           
            players = read.GetPlayers(playersFilePath, sex);
            referees = read.GetReferee(refereesFilePath, sex);

            runGame.Games(GetLimitOfPlayers(players, numberOfPlayers), (GetLimitOfReferees(referees, numberOfReferees)));
        }

        public List<Player> GetLimitOfPlayers(List<Player> allPlayers, int amount)
        {
            List<Player> limitedPlayers = new List<Player>();
            List<int> tempInts = new List<int>();
            Random rand = new Random();

            for(int i = 0; i < amount; i++)
            {
                if(tempInts.Count < amount + 1)
                {
                    int temp = rand.Next(0, allPlayers.Count - 1);

                    if(!tempInts.Contains(temp))
                    {
                        limitedPlayers.Add(allPlayers[temp]);
                        tempInts.Add(temp);
                    }
                    else
                    {
                        i--;
                    }
                }
                
            }

            return limitedPlayers;
        }

        public List<Referee> GetLimitOfReferees(List<Referee> allReferees, int amount)
        {
            List<Referee> limitedReferees = new List<Referee>();
            List<int> refTempInts = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < amount; i++)
            {
                if (refTempInts.Count < amount + 1)
                {
                    int temp = rand.Next(0, allReferees.Count - 1);

                    if (!refTempInts.Contains(temp))
                    {
                        limitedReferees.Add(allReferees[temp]);
                        refTempInts.Add(temp);
                    }
                    else
                    {
                        i--;
                    }
                }

            }

            return limitedReferees;
        }

        private void WomenGames()
        {
            Console.WriteLine("Choose number of players in tournament. You can choose 8, 16 or 32...");
            var input = Console.ReadLine();

            if (input == "8" || input == "16" || input == "32") 
            {
                var numberOfPlayers = input;
                var numberOfReferees = "2";
                
                StartGame(@"../../tennis_data\FemalePlayer.txt", @"../../tennis_data\FemaleRefs.txt",
                    Int32.Parse(numberOfPlayers), Int32.Parse(numberOfReferees), "Female");
            }
            else
            {
                Console.WriteLine("Choose 8, 16 or 32 players");
                WomenGames();
            }
            
        }

        private void MenGames()
        {
            Console.WriteLine("Choose number of players in tournament. You can choose 8, 16 or 32...");
            var input = Console.ReadLine();
            if (input == "8" || input == "16" || input == "32")
            {
                var numberOfPlayers = input;
                var numberOfReferees = "2";

                StartGame(@"../../tennis_data\MalePlayer.txt", @"../../tennis_data\MaleRefs.txt",
                    Int32.Parse(numberOfPlayers), Int32.Parse(numberOfReferees), "Male");
            }
            else
            {
                Console.WriteLine("Choose 8, 16 or 32 players");
                MenGames();
            }
        }

        

        public void SortByFirstName()
        {
            Console.WriteLine("Do you want to sort list of male or female players by their first names?");
            Console.Write("Please type 'Male' or 'Female'... ");
            string gender = Console.ReadLine();

            if (gender.Equals("Male")) 
            {
                ReadFile read = new ReadFile();
                List<Player> males = read.GetPlayers(@"../../tennis_data\MalePlayer.txt", gender); 

                List<Player> sortedMales = males.OrderBy(x => x.FirstName).ToList(); 
                foreach (var m in sortedMales)
                {
                    Console.WriteLine(m);
                }
            }
            else if (gender.Equals("Female")) 
            {
                ReadFile read = new ReadFile();
                List<Player> females = read.GetPlayers(@"../../tennis_data\FemalePlayer.txt", gender); 

                List<Player> sortedFemales = females.OrderBy(x => x.FirstName).ToList(); 
                foreach (var m in sortedFemales)
                {
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine("Please type 'Male' or 'Female' ");
                SortByFirstName();
            }
        }


        public void AddGameMaster()
        {
            var gm = Console.ReadLine();
            ReadFile read = new ReadFile();
            List<GameMaster> gameMasters = read.GetGameMaster(@"../../tennis_data\FemaleRefs.txt", "Female");

            foreach (var g in gameMasters)
            {
                if (g.FirstName == gm)
                {
                    Console.WriteLine(g);
                }
            }
        }


        public void SortByLastName()
        {
            Console.WriteLine("Do you want to sort list of male or female players by their last names?");
            Console.Write("Write 'Male' or 'Female'... ");
            var gender = Console.ReadLine();

            if (gender.Equals("Male")) 
            {
                ReadFile read = new ReadFile();
                List<Player> males = read.GetPlayers(@"../../tennis_data\MalePlayer.txt", gender); 

                List<Player> sortedMales = males.OrderBy(x => x.LastName).ToList(); 
                foreach (var m in sortedMales)
                {
                    Console.WriteLine(m);
                }
            }
            else if (gender.Equals("Female")) 
            {
                ReadFile read = new ReadFile();
                List<Player> females = read.GetPlayers(@"../../tennis_data\FemalePlayer.txt", gender); 

                List<Player> sortedFemales = females.OrderBy(x => x.LastName).ToList(); 
                foreach (var m in sortedFemales)
                {
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine("Write 'Male' or 'Female' ");
                SortByLastName();
            }
        }


        public void StartTournament()
        {
            try
            {
                Console.WriteLine("Write tournament's name: ");
                string Name = Console.ReadLine();
                Console.WriteLine("Now, write tournament's year:  ");
                int Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" ");
                Console.WriteLine(Name + " " + Year);
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("This is a {0} Tennis Tournament", Name, Year);
                Console.WriteLine("Type game master's first name to choose game master. You can choose from following first names: Fabiola, Oktavia or Nala");
                AddGameMaster();
                Console.WriteLine();
                Console.WriteLine("First, please type your command.");
                Console.WriteLine("Now you can choose from following:");
                Console.WriteLine();
                Console.WriteLine("      A. Write 'New tournament', if you want to simulate a tournament consisting only of single games.");
                Console.WriteLine("      B. Write 'Sorting by first names', if you want to sort the playerlist by first names");
                Console.WriteLine("      C. Write 'Sorting by last names', if you want to sort the playerlist by last names");
                Console.WriteLine("      D. Write 'Restart', if you want to restart the tournament.");
                Console.WriteLine(" ");
                Console.Write("Write chosen command: ");
                var answer = Console.ReadLine();

                if (answer == "New tournament")
                {
                    Console.WriteLine("Choose male or female games type");
                    Console.WriteLine("Game type: 1  = male games, 2 = female games " );
                    
                    string response = Console.ReadLine();

                    switch (response)
                    {
                        case "1":
                            MenGames();
                            break;

                        case "2":
                            WomenGames();
                            break;

                        default:
                            Console.WriteLine("Please choose 1 or 2");
                            break;
                    }
                }

                if (answer == "Sorting by first names")
                {
                    SortByFirstName();
                }

                if (answer == "Sorting by last names")
                {
                    SortByLastName();
                }

                var end = Console.ReadLine();

                if (end == "Restart")
                {
                    Console.Clear();
                    StartTournament();
                }
                else
                {
                    throw (new FormatException("You have typed incorrectly, try again... "));
                }
            }

            catch (FormatException exceptionObject)
            {
                Console.WriteLine("{0} exception caught.", exceptionObject);
            }

            finally
            {
                StartTournament();
            }
        }

    }

}




