using MiniAdventure.Interfaces;

namespace MiniAdventure.Characters
{
    public class Player
    {
        public string Name;
        public string HeroType;
        public int HP ;
        public int MaxHP;
        public int Damage ;
        public int Gold = 0;

        public Player(string name, string heroType, int hp, int maxHp, int damage, int gold)
        {
            Name = name;
            HeroType = heroType;
            HP = hp;
            MaxHP = maxHp;
            Damage = damage;
            Gold = gold;
        }
    }
}
