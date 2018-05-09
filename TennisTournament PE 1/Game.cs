using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Game
    {
        static Random rand = new Random();
        Player Player1 { get;}
        Player Player2 { get;}
        Referee Referee { get; }
        public Player[] players;
        public int setsNumber;
        int[] set = new int[2];
        List<int> player1Points = new List<int>();
        List<int> player2Points = new List<int>();
        public Player winner;
        
        public Game(Player player1, Player player2, Referee referee)
        {

           this.Player1 = player1;
           this.Player2 = player2;
           this.Referee = referee;
 
        }

        private Gender GetGender()
        {
            return Player1.Gender;
        }


        public int GetNumberOfSets()
        {
            if (GetGender() == Gender.Male)
            {
                setsNumber = 5;
            }
            else
            {
                setsNumber = 3;
            }

            return setsNumber;
        }

        public int[] GetSet()
        {
            int side1 = 0;
            int side2 = 0;

            side1 = rand.Next(0, 1000);
            side2 = rand.Next(0, 1000);


            if (side1 == side2)
            {
                set[0] = 6;
                set[1] = rand.Next(0, 5);
            }
            else if (side1 > side2)
            {
                set[0] = 6;
                set[1] = rand.Next(0, 5);
            }
            else
            {
                set[0] = rand.Next(0, 5);
                set[1] = 6;
            }

            player1Points.Add(set[0]);
            player2Points.Add(set[1]);
            
            return set;
        }


        public Player Match()

        {
            int player1Wins = 0;
            int player2Wins = 0;

            for (int i = 0; i < GetNumberOfSets(); i++)
            {
                int [] set = GetSet();
                
                if (set[0] > set[1])
                {
                    player1Wins = player1Wins + 1;
                    
                }
                else
                {
                    player2Wins = player2Wins + 1;
                    
                }
            }

            if (player1Wins > player2Wins)
            {
                if (player1Points.Count == 5)
                {
                    Console.WriteLine(Player1.FirstName + " " + Player1.LastName + ": " + player1Points[0] + " - " + player1Points[1] + " - " + player1Points[2] + " - " + player1Points[3] + " - " + player1Points[4]);
                    Console.WriteLine(Player2.FirstName + " " + Player2.LastName + ": " + player2Points[0] + " - " + player2Points[1] + " - " + player2Points[2] + " - " + player2Points[3] + " - " + player2Points[4]);
                }
                else
                {
                    Console.WriteLine(Player1.FirstName + " " + Player1.LastName + ": " + player1Points[0] + " - " + player1Points[1] + " - " + player1Points[2]);
                    Console.WriteLine(Player2.FirstName + " " + Player2.LastName + ": " + player2Points[0] + " - " + player2Points[1] + " - " + player2Points[2]);
                }

                Console.WriteLine();
                Console.WriteLine(Player1.FirstName + " " + Player1.LastName + " won the game");
                Console.WriteLine();
                winner = Player1;
            }
            else
            {
                if (player1Points.Count == 5)
                {

                    Console.WriteLine(Player1.FirstName + " " + Player1.LastName + ": " + player1Points[0] + " - " + player1Points[1] + " - " + player1Points[2] + " - " + player1Points[3] + " - " + player1Points[4]);
                    Console.WriteLine(Player2.FirstName + " " + Player2.LastName + ": " + player2Points[0] + " - " + player2Points[1] + " - " + player2Points[2] + " - " + player2Points[3] + " - " + player2Points[4]);
                }
                else
                {
                    Console.WriteLine(Player1.FirstName + " " + Player1.LastName +  ": " + player1Points[0] + " - " + player1Points[1] + " - " + player1Points[2]);
                    Console.WriteLine(Player2.FirstName + " " + Player2.LastName + ": " + player2Points[0] + " - " + player2Points[1] + " - " + player2Points[2]);
                }

                Console.WriteLine();
                Console.WriteLine(Player2.FirstName + " " + Player2.LastName + "  won the game");
                Console.WriteLine();
                winner = Player2;
            }

            return winner;
        }

    }

}












   