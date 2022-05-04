using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Enemy : Alive
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxDamage { get; set; }
        public int RewardXP { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }

        public Enemy(int id, string name, int maxDamage, int rewardXP,
            int rewardGold, int currentHitPoints, int maximumHitPoints) : base(currentHitPoints,
                maximumHitPoints)
        {
            ID = id;
            Name = name;
            MaxDamage = maxDamage;
            RewardXP = rewardXP;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();
        }
    }
}
