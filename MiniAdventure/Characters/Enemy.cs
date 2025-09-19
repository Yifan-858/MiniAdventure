using MiniAdventure.Interface;
using System.Numerics;
using System;

namespace MiniAdventure.Characters 
{
    public class Enemy : Character, IVisual
    {
        public int GoldReward;
        public string Narrative { get; set; }
        public string Img { get; set; }

        public Enemy(string name, int hp, int damage, int goldReward, string narrative, string img)
            : base(name, hp, damage)
        {
            GoldReward = goldReward;
            Narrative = narrative;
            Img = img;
        }
        
        public void restoreTotalHP(int hp)
        {
            HP = hp;
        }

        internal void restoreHP(int v)
        {
            throw new NotImplementedException();
        }
    }
}


