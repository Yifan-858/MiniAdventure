using MiniAdventure.Characters;
using MiniAdventure.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure.Managers
{
    public class ShopManager
    {
         //Shop
        public static void InitializeShop(Player player, List<BaseItem> shopInventory)
        {
            bool isInShop = true;

            while (isInShop)
            {
                //Generate items for buying
                List<string> shopAvailableOptions = new List<string> { };
                List<int> originInventoryIndex = new List<int> { };

                for (int i = 0; i < shopInventory.Count; i++)
                {
                    if (!shopInventory[i].IsUsed)
                    {
                        shopAvailableOptions.Add($"{shopInventory[i].Name} - {shopInventory[i].Description} | {shopInventory[i].Cost} Gold");
                        originInventoryIndex.Add(i);
                    }
                }

                //Attach "Leave shop" option at the end of items
                shopAvailableOptions.Add("Leave Shop");

                //Change shop narrative according to the inventory
                string shopMenuNarrative;
                if(shopAvailableOptions.Count > 1)
                {
                    shopMenuNarrative = "What do you want to buy?";
                }
                else
                {
                    shopMenuNarrative = "There is nothing to buy right now";
                }

                //Generate shop menu
                Menu shopMenu = new Menu(shopMenuNarrative, shopAvailableOptions);

                int index = shopMenu.ControlChoice();

                if(index == shopAvailableOptions.Count - 1)
                {
                    isInShop = false;
                }
                else
                {
                    //find original index in shopInventory
                    int indexSelected = originInventoryIndex[index];

                    if (CanAfford(shopInventory[indexSelected].Cost, player))
                    {
                        switch (shopInventory[indexSelected].ItemType)
                        {
                            case "ColorItem":
                                shopInventory[indexSelected].UseItem();
                                Console.WriteLine("Your status is painted with color now.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;

                            case "RestItem":
                                shopInventory[indexSelected].UseItem();
                                Console.WriteLine("You used the eye drop on the frog.");
                                Console.WriteLine("It turned into a prince and walked away.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey(true);
                                break;

                            default:
                                Console.WriteLine("Cannot find the item.");
                                break;

                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Your have {player.Gold} Gold. That's not enough.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                    }
                }
            }
        }

        public static bool CanAfford(int itemCost, Player player)
        {
            if(player.Gold >= itemCost)
            {
                player.SpendGold(itemCost);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
