using System;
using System.Numerics;

namespace MiniAdventure.Characters
{
    public class Player : Character
    {
        public string HeroType { get; private set; }
        public int MaxHP { get; private set; }
        public int Gold { get; private set; } = 0;

        public Player(string name, int hp, int damage, string heroType, int maxHp, int gold = 0)
            : base(name, hp, damage)
        {
            HeroType = heroType;
            MaxHP = maxHp; 
            Gold = gold;
        }

        public void GainHP(int amount)
        {
            HP = Math.Min(HP + amount, MaxHP);

            if(HP < MaxHP)
            {
                Console.WriteLine($"You took a nap. Gain {amount} HP.");
                Console.WriteLine($"HP: {HP}/{MaxHP}");
            }
            else
            {
                Console.WriteLine("You have rested fully and reached the MaxHP.");
            }            
        }

        public void GainGold(int reward)
        {
            Gold += reward;
        }

        public void SpendGold(int cost)
        { 
            Gold -= cost;
        }
      
    }
}
