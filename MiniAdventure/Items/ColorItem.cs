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
        public ColorItem(string name, string description) : base(name, description)
        {
        }

        public override int GenerateId()
        {
            return nextId++;
        }


    }
}
