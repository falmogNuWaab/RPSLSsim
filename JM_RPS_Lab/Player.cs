using System;
using System.Collections.Generic;
using System.Text;

namespace JM_RPS_Lab
{
    abstract class Player
    {
        public string Name { get; set; }
        public RPS RockPaperScissorLizardSpock { get; set; }
        public Player(string Name)
        {
            this.Name = Name;
        }
        public abstract RPS GenerateRPS();
        public abstract RPS GenerateRPSLS();
    }
}
