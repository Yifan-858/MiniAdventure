using MiniAdventure.Items;
using MiniAdventure.Characters;


namespace MiniAdventure.Managers
{
    public class GameManager
    {
        public static int WinCount = 0;

        //Extra Feature: Disable Rest every second fight round
        public static bool disableRest = false;
        public static bool UpdateDisableRest()
        {
            return disableRest = WinCount != 0 && WinCount % 2 == 0;
        }


        //Shop
        public static void InitializeShop(Player player, List<BaseItem> shopInventory)
        {
            bool isInShop = true;

            while (isInShop)
            {
                //Generate items for buying
                List<string> itemDescriptionList = new List<string> { };
                for(int i=0; i < shopInventory.Count; i++)
                {
                    if (!shopInventory[i].IsUsed)
                    {
                        itemDescriptionList.Add($"{shopInventory[i].Name} - {shopInventory[i].Description}");
                    }
                }

                //Attach "Leave shop" option at the end of items
                itemDescriptionList.Add("Leave Shop");

                //Change shop narrative according to the inventory
                string shopMenuNarrative;
                if(itemDescriptionList.Count > 1)
                {
                    shopMenuNarrative = "What do you want to buy?";
                }
                else
                {
                    shopMenuNarrative = "There is nothing to buy right now";
                }

                //Generate shop menu
                Menu shopMenu = new Menu(shopMenuNarrative, itemDescriptionList);

                int indexSelected = shopMenu.ControlChoice();

                if(indexSelected == itemDescriptionList.Count - 1)
                {
                    isInShop = false;
                }
                else
                {
                    if (CanAfford(shopInventory[indexSelected].Cost, player))
                    {
                        shopInventory[indexSelected].UseItem();
                        Console.WriteLine($"You bought {shopInventory[indexSelected].Name}.Your status changed.");
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
                player.SpendGold(itemCost);//not hooked with use
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                return false;
            }
            
        }
    } 
}
