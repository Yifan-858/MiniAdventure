
namespace MiniAdventure.Characters
{
    public class Enemy
    {
        public string Name;
        public int HP;
        public int Damage;
        public int GoldReward;
        public string Narrative;
        public string Img;
        

        public Enemy(string name, int hp, int damage, int goldReward, string narrative, string img)
        {
            Name = name;
            HP = hp;
            Damage = damage;
            GoldReward = goldReward;
            Narrative = narrative;
            Img = img;
        }
    }
}


