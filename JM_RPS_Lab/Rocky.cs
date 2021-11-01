using System;
using System.Collections.Generic;
using System.Text;

namespace JM_RPS_Lab
{
    class Rocky : Player
    {
        public Rocky() : base("Rocky")
        {
            this.RockPaperScissorLizardSpock = RPS.Rock;
        }
        public override RPS GenerateRPS()
        {            
            return RockPaperScissorLizardSpock;
        }
        public override RPS GenerateRPSLS()
        {
            return RockPaperScissorLizardSpock;
        }

    }
}
