using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure.Characters
{
    public class Enemy
    {
        public string Name;
        public int HP;
        public int Damage;
        public int GoldReward;

        public Enemy(string name, int hp, int damage, int goldReward)
        {
            Name = name;
            HP = hp;
            Damage = damage;
            GoldReward = goldReward;
        }
    }
}


