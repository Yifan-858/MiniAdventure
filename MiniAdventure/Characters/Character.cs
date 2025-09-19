using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure.Characters
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int HP { get; protected set; }
        public int Damage { get; private set; }

        public Character(string name, int hp, int damage)
        {
            Name = name;
            HP = hp;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if(HP < 0) HP = 0; 
        }

        public void IncreaseDamage(int amount)
        {
            Damage += amount;
        }
        
        
    }
}
