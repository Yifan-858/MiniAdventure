using MiniAdventure.Characters;
using MiniAdventure.Items;


namespace MiniAdventure.Managers
{
   public static class WorldManager
    {
        public static ConsoleColor[] TextColor { get; private set; } =
        {
            ConsoleColor.White, ConsoleColor.White, ConsoleColor.White, ConsoleColor.White, ConsoleColor.White, ConsoleColor.White, 
            ConsoleColor.White
        };

        public static void ChangeConsoleColor(ConsoleColor[] newColor)
        {
            for(int i = 0; i < 8; i++)
            {
                TextColor[i] = newColor[i];
            }
        }
        public static void CheckStatus(Player player, ColorItem )
        {
            if (ColorItem.IsUsed)
            {
                ChangeConsoleColor();
            }
            Console.Clear();
            Console.ForegroundColor = TextColor[1];
            Console.WriteLine("+================================+");
            Console.WriteLine("|          PLAYER STATUS         |");
            Console.WriteLine("+--------------------------------+");
            Console.ForegroundColor = TextColor[2];
            Console.WriteLine($"| Name      : {player.Name,-19}|");
            Console.ForegroundColor = TextColor[3];
            Console.WriteLine($"| Hero Type : {player.HeroType,-19}|");
            Console.ForegroundColor = TextColor[4];
            Console.WriteLine($"| HP        : {player.HP}|{player.MaxHP,-16}|");
            Console.ForegroundColor = TextColor[5];
            Console.WriteLine($"| Damage    : {player.Damage,-19}|");
            Console.ForegroundColor = TextColor[6];
            Console.WriteLine($"| Gold      : {player.Gold,-19}|");
            Console.ForegroundColor = TextColor[7];
            Console.WriteLine($"| Kills     : {GameManager.WinCount,-19}|");
             Console.ForegroundColor = TextColor[1];
            Console.WriteLine("+================================+");

            Console.WriteLine($"Press any key to return.");
            Console.ReadKey(true);
        }

        public static void Rest(Player player)
        {
            Console.Clear();

            GameManager.UpdateDisableRest();

            if (GameManager.disableRest)
            {
                Console.WriteLine("            _   _\r\n           (.)_(.)\r\n        _ (   _   ) _\r\n       / \\/`-----'\\/ \\\r\n     __\\ ( (     ) ) /__\r\n     )   /\\ \\._./ /\\   (\r\n      )_/ /|\\   /|\\ \\_(");
                Console.WriteLine();
                Console.WriteLine("A tiny frog stares at you with unblinking judgment. Somehow, you lose the will to rest here.");
            }
            else
            {
                player.GainHP(2);
            }
                
            Console.WriteLine($"Press any key to return");
            Console.ReadKey(true);
        }

        public static void Explore(Player player, Enemy enemy, List<Enemy> enemyArr)
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
                    Battle.EnterBattle(player, enemy,enemyArr);
                    break;

                case 1:
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        }

         public static bool QuitGame()
        {
            Console.WriteLine("See you soon.");
            return false;
        }
    }
}
