
namespace MiniAdventure.Characters 
{
    public class Enemy : Character
    {
        public int GoldReward;
        public string Narrative;
        public string Img;
        

        public Enemy(string name, int hp, int damage, int goldReward, string narrative, string img)
            : base(name, hp, damage)
        {
            GoldReward = goldReward;
            Narrative = narrative;
            Img = img;
        }
    }
}


