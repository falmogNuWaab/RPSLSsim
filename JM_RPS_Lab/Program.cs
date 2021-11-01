using System;
using System.Collections.Generic;

namespace JM_RPS_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepPlaying = true;            

            RPSApp gameTime = new RPSApp();
            List<Player> Leaderboard = new List<Player>();

            while (keepPlaying)
            {
                //Play a game and remember the winner
                Player winner = gameTime.Play();
                if (winner.Name != "Draw")
                {
                    Leaderboard.Add(winner);
                }
                 Console.WriteLine($"Winner: {winner.Name}");
                Console.WriteLine();
                //Keep Playing until the user has had enough
                keepPlaying = gameTime.Continue();
                
            }
            //Print the winner's circle.
            Console.WriteLine();
            Console.WriteLine("This Round: ");
            Console.WriteLine($"Win:{gameTime.PlayerOneWins} Lose:{gameTime.OpponentWins} Draw:{gameTime.Draws}");

            Console.WriteLine("\n!WINNER CIRCLE!");
            for (int i = 0; i < Leaderboard.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Leaderboard[i].Name}");
            }
        }

    }
}
