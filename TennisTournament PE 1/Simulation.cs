using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Simulation
    {
        public void Games(List<Player> listOfPlayers, List<Referee> listOfReferees)
        {
            
            List<Referee> referees = listOfReferees;
            List<Player> players = listOfPlayers;
            

            while (players.Count > 1) 
            {
                List<Player> tempList = new List<Player>();
                

                if (players.Count == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Final");
                    Console.WriteLine();
                }

                if (players.Count == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Semi-Finals");
                    Console.WriteLine();
                }

                if (players.Count == 8)
                {
                    Console.WriteLine();
                    Console.WriteLine("Quater-Finals");
                    Console.WriteLine();
                }

                Console.WriteLine();

                for (int i = 0; i + 1 < players.Count; i += 2)
                {
                    for (int m = 0; m + 1 < referees.Count; m++)

                    {
                        Console.WriteLine();
                        Console.WriteLine(players[i].FirstName + " " + players[i].LastName + " vs. " + players[i + 1].FirstName + " " + players[i + 1].LastName);
                        Console.WriteLine();
                        Console.WriteLine("The Referee for this game is: " + referees[m].FirstName + " " + referees[m].LastName);
                        Console.WriteLine();
                        var game = new Game(players[i], players[i + 1], referees[m]);
                        var winner = game.Match();
                        tempList.Add(winner);
                    }
                
                }
                players = tempList;
            }
            Console.WriteLine();
            Console.WriteLine(players[0].FirstName + " " + players[0].LastName + " won the tournament!");
        }
    }
}
