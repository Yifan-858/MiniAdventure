using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure.Characters
{
    public class Character
    {
        public string Name;
        public int HP;
        public int Damage;

        public Character(string name, int hp, int damage)
        {
            Name = name;
            HP = hp;
            Damage = damage;
        }
    }
}
