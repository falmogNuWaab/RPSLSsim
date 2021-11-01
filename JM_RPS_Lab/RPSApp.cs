using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JM_RPS_Lab
{
    class RPSApp
    {
        public string[,] WinTable { get; set; } = new string[5, 5] { { "D", "L", "W", "W", "L" },
                                                                     { "W", "D", "L", "L", "W" },
                                                                     { "L", "W", "D", "W", "L" },
                                                                     { "L", "W", "L", "D", "W" },
                                                                     { "W", "L", "W", "L", "D" } };
        public Player PlayerOne { get; set; }
        public int PlayerOneWins { get; set; } = 0;
        public Player Opponent { get; set; }
        public int OpponentWins { get; set; } = 0;
        public int Draws { get; set; } = 0;        
        public List<string> Rules { get; set; } = new List<string> { "Scissors cut Paper", "Paper covers Rock", "Rock crushes Lizard", "Lizard poisons Spock", "Spock smashes Scissors", "Scissors decapitates Lizard", "Lizard eats Paper","Paper disproves Spock", "Spock vaporizes Rock", "And as it always has, Rock crushes Scissor"};

        public RPSApp()
        {
            //Create a New Player user and Set that as PlayerOne
            this.PlayerOne = new UserPlayer();
            this.Opponent = PickOpponent();                                
        }
        public Player PickOpponent()
        {
            //Have PlayerOne pick their opponent
            //Creating a method that returns the player so that I can force the user to select an opponent
            //Previously, the following switch was in the constructor and I was using a a default opponent, set to new Randa();
            //if I didn't get a 1 or 2
            Console.WriteLine("\nChoose your Oppoent from the list:");
            Console.WriteLine("[1]Rocky\n[2]Randa");
            Console.Write("Selection: ");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    return new Rocky();
                   
                case "2":
                    return new Randa();
                    
                default:
                    Console.WriteLine("That's not a valid choice."); 
                    break;
            }
            return PickOpponent();
        }

        //Have Player One pick a Game Mode.
        public GameMode PickMode()
        {
            Console.WriteLine("\nMODES:\n[1]Classic Mode\n[2]Rock, Paper, Scissors, Lizard, Spock");
            Console.Write("Selection:");
            string response = Console.ReadLine();        
           
            switch (response)
            {
                case "1":
                    return GameMode.Classic;
                case "2":
                    return GameMode.RockPaperScissorLizardSpock;                    
                default:
                    Console.WriteLine("That was not a valid selection.");
                    break;                    
            }
            return PickMode();
        }

        //In case PlayerOne has never played Rock, Paper, Scissors, or Rock, Player, Scissors, Lizard, Spock, offer to read the rules
        public string ReadRules(GameMode Mode)
        {
            Console.Write("\nWould you like to see the rules?(y/n)");
            string response = Console.ReadLine().Trim().ToLower();
            string ruleString = $"\nRULES:\n";
            if (response == "y")
            {
          
                if (Mode == GameMode.Classic)
                {
                    ruleString += $"1: {Rules[0]}\n";
                    ruleString += $"2: {Rules[1]}\n";
                    ruleString += $"3: {Rules[9]}\n";
                }
                else if (Mode == GameMode.RockPaperScissorLizardSpock)
                {
                    
                    for (int i = 0; i < Rules.Count; i++)
                    {
                        ruleString += $"{i + 1}: {Rules[i]}\n";
                    }
                }
                
            } 
            else if (response == "n")
            {
                ruleString = " ";
            }
            else
            {
                Console.WriteLine("I didn't understand that");
                return ReadRules(Mode);
            }
            return ruleString;

        }

        //Trying to add some flare to the app.
        //IN Real Life RPS/RPSLS before you show your hand, you yell out the name of the game....
        public void LetsGooooo(GameMode Mode)
        {
            int j = 0;
            int limiter = 0;
            //Previously used a list property created earlier. The line of code below does the same thing.
            //Ask about this in class. Why is it structured this way? and what is RPS[]?
            List<string> RPSList = ((RPS[])Enum.GetValues(typeof(RPS))).Select(c => c.ToString()).ToList(); 
            if(Mode == GameMode.Classic)
            {
                limiter = 2;
            }
            else
            {
                limiter = RPSList.Count-1;
            }
            for (int i = 0; i <= 1000000000; i++)
            {
                if (i % 200000000 == 0 && j<=limiter)
                {
                    Console.Write(RPSList[j] + " !! ");
                    j++;
                } 

            }
        }

        public Player Play()
        {
            
            GameMode Mode = PickMode();
            Console.WriteLine(ReadRules(Mode));                      
            
            UserPlayer drawPlayer = new UserPlayer("Draw"); //In the event of a Draw, this player is the winner.
            if (Mode == GameMode.Classic)
            {                
                PlayerOne.GenerateRPS();
                Opponent.GenerateRPS();
            }
            else if(Mode == GameMode.RockPaperScissorLizardSpock)
            {
                
                PlayerOne.GenerateRPSLS();
                Opponent.GenerateRPSLS();
            }
            Console.WriteLine();

            LetsGooooo(Mode);
            Console.WriteLine($"GO!!!!!");
            Console.WriteLine($"{PlayerOne.Name} chooses {PlayerOne.RockPaperScissorLizardSpock}");
            Console.WriteLine($"{Opponent.Name} chooses {Opponent.RockPaperScissorLizardSpock}");

            //Convert the players choices to their index and use them like coordinates to find the right cell in WinTable
            //Syntax for pulling from a 2D array goes like this ArrayName[index1,index2]
            //The table is layed out so that each row represents PlayerOne's choice
            //The Opponents choice will be used to find out if PlayerOnes choice results in a W(in) L(ose) or D(raw)
            //Each enum value has an underlying integer value (kinda like an index)
            //We can access that value by casting the enum to an int.
            //        public string[,] WinTable { get; set; } = new string[5, 5] { { "D", "L", "W", "W", "L" },
            //                                                                     { "W", "D", "L", "L", "W" },
            //                                                                     { "L", "W", "D", "W", "L" },
            //                                                                     { "L", "W", "L", "D", "W" },
            //                                                                     { "W", "L", "W", "L", "D" } };                                                                                                     

            string areTheOddsInYourFavor = WinTable[(int)PlayerOne.RockPaperScissorLizardSpock, (int)Opponent.RockPaperScissorLizardSpock];
            
            switch (areTheOddsInYourFavor)
            {
                case "D":
                    Draws++;
                    return drawPlayer;                    
                case "W":
                    PlayerOneWins++;
                    return PlayerOne;
                case "L":
                    OpponentWins++;
                    return Opponent;
            }
            return drawPlayer;
        }
        public bool Continue()
        {
            Console.Write("GG, Would you like to play again?(y/n) ");
            string response = Console.ReadLine();
            response = response.Trim().ToLower();
            if (response == "y")
            {
                return true;
            }
            else if (response == "n")
            {
                Console.WriteLine("It was fun playing with you, goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that, sorry");
                return Continue();
            }
        }

    }
}
