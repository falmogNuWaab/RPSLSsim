using System;
using System.Collections.Generic;
using System.Text;

namespace JM_RPS_Lab
{
    class Randa : Player
    {
        public Randa() : base("Randa")
        {

        }
        public override RPS GenerateRPS()
        {
            Random rand = new Random();
            int om = 0;
                om = rand.Next(0, 3);
            
            switch (om)
            {
                case 0:
                    RockPaperScissorLizardSpock = RPS.Rock;
                    break;
                case 1:
                    RockPaperScissorLizardSpock = RPS.Paper;
                    break;
                case 2:
                    RockPaperScissorLizardSpock = RPS.Scissors;
                    break;
                default:
                    return GenerateRPS();
            }
            
            return RockPaperScissorLizardSpock;
        }

        public override RPS GenerateRPSLS()
        {                  
            Random rand = new Random();
            int om = 0;
            om = rand.Next(0, 5);
            
            switch (om)
            {
                case 0:
                    RockPaperScissorLizardSpock = RPS.Rock;
                    break;
                case 1:
                    RockPaperScissorLizardSpock = RPS.Paper;
                    break;
                case 2:
                    RockPaperScissorLizardSpock = RPS.Scissors;
                    break;
                case 3:
                    RockPaperScissorLizardSpock = RPS.Lizard;
                    break;
                case 4:
                    RockPaperScissorLizardSpock = RPS.Spock;
                    break;
                default:
                    return GenerateRPSLS();
            }
            
            return RockPaperScissorLizardSpock;
        }
    }

    
}
