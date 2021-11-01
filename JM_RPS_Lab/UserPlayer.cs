using System;
using System.Collections.Generic;
using System.Text;

namespace JM_RPS_Lab
{
    class UserPlayer : Player
    {
        public UserPlayer() : base("")
        {
            Console.WriteLine("What's your name?");
            string response = Console.ReadLine();
            this.Name = response;
        }
        
        public UserPlayer(string Name) : base(Name)
        {
            
        }

        public override RPS GenerateRPS()
        {
            Console.WriteLine("Please choose:\n[1]Rock\n[2]Paper\n[3]Scissor");
            string response = Console.ReadLine();
            
            switch (response)
            {
                case "1":
                    this.RockPaperScissorLizardSpock = RPS.Rock;
                    break;
                case "2":
                    this.RockPaperScissorLizardSpock = RPS.Paper;
                    break;
                case "3":
                    this.RockPaperScissorLizardSpock = RPS.Scissors;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    return GenerateRPS();
            }
            
            return RockPaperScissorLizardSpock;
        }
        public override RPS GenerateRPSLS()
        {
            Console.WriteLine("Please choose:\n[1]Rock\n[2]Paper\n[3]Scissor\n[4]Lizard\n[5]Spock");
            string response = Console.ReadLine();
            
            switch (response)
            {
                case "1":
                    this.RockPaperScissorLizardSpock = RPS.Rock;
                    break;
                case "2":
                    this.RockPaperScissorLizardSpock = RPS.Paper;
                    break;
                case "3":
                    this.RockPaperScissorLizardSpock = RPS.Scissors;
                    break;
                case "4":
                    this.RockPaperScissorLizardSpock = RPS.Lizard;
                    break;
                case "5":
                    this.RockPaperScissorLizardSpock = RPS.Spock;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                   return GenerateRPSLS();
                   
            }
            
            return RockPaperScissorLizardSpock;
        }
    }
}
