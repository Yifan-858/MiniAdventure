using MiniAdventure.Characters;

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
    }
}
