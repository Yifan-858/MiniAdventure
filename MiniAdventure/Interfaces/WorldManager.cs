using MiniAdventure.Characters;
using MiniAdventure.Interfaces;

namespace MiniAdventure.Interfaces
{
   public static class WorldManager
    {
        public static bool QuitGame()
        {
            Console.WriteLine("See you soon.");
            return false;
        }

        public static void CheckStatus(Player player, int winCount)
        {
            Console.Clear();
            Console.WriteLine("+================================+");
            Console.WriteLine("|          PLAYER STATUS         |");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine($"| Name      : {player.Name,-19}|");
            Console.WriteLine($"| Hero Type : {player.HeroType,-19}|");
            Console.WriteLine($"| HP        : {player.HP}|{player.MaxHP,-16}|");
            Console.WriteLine($"| Damage    : {player.Damage,-19}|");
            Console.WriteLine($"| Gold      : {player.Gold,-19}|");
            Console.WriteLine($"| Kills     : {winCount,-19}|");
            Console.WriteLine("+================================+");

            Console.WriteLine($"Press any key to return.");
            Console.ReadKey(true);
        }

        public static int Rest(Player player)
        {
            Console.Clear();
            player.HP += 2;
           
            if(player.HP < player.MaxHP)
            {
                Console.WriteLine($"You took a nap. Gain 2 HP.");
                Console.WriteLine($"HP: {player.HP}/{player.MaxHP}");
            }
            else
            {
                player.HP = player.MaxHP;
                Console.WriteLine($"You have reached the MaxHP.");
            }
    
            Console.WriteLine($"Press any key to return");
            Console.ReadKey(true);

            return player.HP;
        }

        public static void Explore(Player player, Enemy enemy, ref int winCount, List<Enemy> enemyArr)
        {
            if (enemy == null)
            {
                Console.WriteLine("No enemy encountered.");
                return;
            }

            Console.Clear();
            Console.WriteLine(enemy.Narrative);
            Console.WriteLine(enemy.Img);
            string encounterNarrative = "What do you want to do?";
            string[] encounterOptions = { "Take the food!", "Walk away..." };

            Menu encounterMenu = new Menu(encounterNarrative, encounterOptions);
            int indexSelected = encounterMenu.ControlChoice(enemy);
            

            switch (indexSelected)
            {
                case 0:
                    Battle.EnterBattle(player, enemy, ref winCount,enemyArr);
                    break;

                case 1:
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        }
    }
}
