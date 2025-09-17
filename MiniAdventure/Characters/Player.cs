namespace MiniAdventure.Characters
{
    public class Player : Character
    {
        public string HeroType;
        public int MaxHP;
        public int Gold = 0;

        public Player(string name, int hp, int damage, string heroType, int maxHp, int gold)
            : base(name, hp, damage)
        {
            HeroType = heroType;
            MaxHP = maxHp; 
            Gold = gold;
        }
    }
}
