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

        public int Cost { get; private set; }
        public bool IsUsed { get; private set; } = false;

        public BaseItem(string name, string description, int cost)
        {
            Id = GenerateId();
            Name = name;
            Description = description;
            Cost = cost;
        }

        public abstract int GenerateId(); // generate different Id sequence for differnt type of items

        public virtual void UseItem() // optionally custimize it to fit the item effect
        {
            IsUsed = true;
        }
    }
}
