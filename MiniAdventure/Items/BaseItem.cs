using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure.Items
{
    public abstract class BaseItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public string Description { get; private set; }
        public bool IsUsed { get; private set; } = false;

        public BaseItem(string name, string description)
        {
            Id = GenerateId();
            Name = name;
            Description = description;
            
        }

        public abstract int GenerateId(); // generate different Id sequence for differnt type of items

        public void UseItem()
        {
           IsUsed = true;
        }
    }
}
