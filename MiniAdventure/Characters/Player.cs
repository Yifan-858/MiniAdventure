using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure.Characters
{
    public class Player
    {
        public string Name;
        public string HeroType;
        public int HP ;
        public int Damage ;
        public int Gold = 0;

        public Player(string name, string heroType)
        {
            Name = name;
            HeroType = heroType;

            switch (HeroType)
            {
                case "Warrior":
                    HP = 20;
                    Damage = 5;
                    break;

                case "Mage":
                    HP = 15;
                    Damage = 10;
                    break;

                case "Rouge":
                    HP = 18;
                    Damage = 8;
                    break;
            }
        }
    }
}
