using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure.Characters
{
    public class Player
    {
        public string Name{ get; set; }
        public string HeroType{ get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Gold = 0;

        public Player(string name, string heroType)
        {
            //Throw an error if user enter an empty name.
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can not be empty");
            }

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
