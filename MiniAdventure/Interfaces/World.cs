using MiniAdventure.Characters;
using MiniAdventure.Interfaces;

namespace MiniAdventure.Interfaces
{
   public static class World
    {
        public static bool QuitGame()
        {
            Console.WriteLine("See you soon.");
            return false;
        }

        public static void CheckStatus(Player player)
        {
            Console.Clear();
            Console.WriteLine("+================================+");
            Console.WriteLine("|          PLAYER STATUS         |");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine($"| Name      : {player.Name,-19}|");
            Console.WriteLine($"| Hero Type : {player.HeroType,-19}|");
            Console.WriteLine($"| HP        : {player.HP,-19}|");
            Console.WriteLine($"| Damage    : {player.Damage,-19}|");
            Console.WriteLine($"| Gold      : {player.Gold,-19}|");
            Console.WriteLine("+================================+");

            Console.WriteLine($"Press any key to return to menu.");
            Console.ReadKey(true);
        }

        public static int Rest(Player player)
        {
            Console.Clear();
            player.HP += 2;
            Console.WriteLine($"You took a nap. Gain 2 HP.");
            Console.WriteLine($"HP: {player.HP}");
            Console.WriteLine($"Press any key to return");
            Console.ReadKey(true);

            return player.HP;
        }

        public static void Explore(Player player, Enemy enemy)
        {
            if (enemy == null)
            {
                Console.WriteLine("No enemy encountered.");
                return;
            }

            Console.Clear();
            Console.WriteLine(enemy.Narrative);
            Console.WriteLine(enemy.Img);
            string actionNarrative = "What do you want to do?";
            string[] actionOptions = { "Take the food", "Check enemey status", "Check your status", "Walk away" };

            Menu actionMenu = new Menu(actionNarrative, actionOptions);
            int indexSelected = actionMenu.ControlChoice(enemy);
            bool isPlayersTurn = true;

            switch (actionOptions[indexSelected])
            {
                case "Take the food":
                    Battle.Attack(player, enemy, isPlayersTurn);
                    break;

                case "Check enemey status":
                    Console.WriteLine("2");
                    break;

                case "Check your status":
                    Console.WriteLine("3");
                    break;

                case "Walk away":
                    Console.WriteLine("4");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        }
    }
}
