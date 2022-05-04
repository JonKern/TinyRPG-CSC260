using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Alive
    {
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }

        public Alive(int currentHP, int maxHPoints)
        {
            CurrentHP = currentHP;
            MaxHP = maxHPoints;
        }
    }
}
