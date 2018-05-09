using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    class Program 
    {
        static void Main()
        {
            StartTournament();
        }

        public static void StartTournament()
        {
            Tournament Tournament = new Tournament("", 0, 32); 
            Tournament.StartTournament();
        }
    }
}
