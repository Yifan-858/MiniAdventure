using MiniAdventure.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure.Items
{
    public class ColorItem : BaseItem
    {
        private int nextId = 1;
        public static ConsoleColor[] NewColor = {ConsoleColor.DarkMagenta, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.DarkYellow, ConsoleColor.Red};

        public ColorItem(string name, string itemType, string description, int cost) : base(name, itemType, description, cost)
        {
        }

        public override int GenerateId()
        {
            return nextId++;
        }
        public override void UseItem()
        {
            base.UseItem();
            WorldManager.SetColor(NewColor);
        }
    }
}
