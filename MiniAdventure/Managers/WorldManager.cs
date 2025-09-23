using MiniAdventure.Characters;
using MiniAdventure.Items;
using System.Numerics;


namespace MiniAdventure.Managers
{
   public static class WorldManager
    {
        public static void GameIntro()
        {
            Console.WriteLine(" ▄  █   ▄      ▄     ▄▀  ▄███▄   █▄▄▄▄       ▄▀  ██   █▀▄▀█ ▄███▄  \r\n█   █    █      █  ▄▀    █▀   ▀  █  ▄▀     ▄▀    █ █  █ █ █ █▀   ▀ \r\n██▀▀█ █   █ ██   █ █ ▀▄  ██▄▄    █▀▀▌      █ ▀▄  █▄▄█ █ ▄ █ ██▄▄   \r\n█   █ █   █ █ █  █ █   █ █▄   ▄▀ █  █      █   █ █  █ █   █ █▄   ▄▀\r\n   █  █▄ ▄█ █  █ █  ███  ▀███▀     █        ███     █    █  ▀███▀  \r\n  ▀    ▀▀▀  █   ██                ▀                █    ▀          \r\n                                                  ▀                ");
                Console.WriteLine();
                Thread.Sleep(800);
                Console.WriteLine("No mercy, no snacks.");
                Thread.Sleep(800);
                Console.WriteLine("Every bite is earned.");
                Thread.Sleep(800);
                Console.WriteLine("Fight for your life... or starve!");
                Thread.Sleep(800);
                Console.Write("If you are ready");
                Thread.Sleep(400);
                Console.Write(".");
                Thread.Sleep(400);
                Console.Write(".");
                Thread.Sleep(400);
                Console.WriteLine(".");
                Thread.Sleep(800);
                Console.WriteLine();
                Console.WriteLine("Press any key to start the game.");
                Console.ReadKey(true);
        }

        private static ConsoleColor[] TextColor =
        {
            ConsoleColor.Gray, ConsoleColor.Gray, ConsoleColor.Gray, ConsoleColor.Gray, ConsoleColor.Gray, ConsoleColor.Gray, 
            ConsoleColor.Gray
        };

        public static void SetColor(ConsoleColor[] ColorTheme)
        {
            for(int i = 0; i < TextColor.Length; i++)
                {
                    TextColor[i] = ColorTheme[i];
                }
        }

        //Extra Feature: Disable Rest every second fight round or Use item to unlock Rest
        public static int WinCount { get; private set; } = 0;
        public static bool isRestDisabled { get; private set; } = false;
        private static bool isRestAlwaysAvailable = false;
        public static void DisableRestByWin()
        {
            if (!isRestAlwaysAvailable)
            {
                isRestDisabled = WinCount % 2 == 0;
            }
            else
            {
                isRestDisabled = false;
            }
        }

        public static void MakeRestAlwaysAvailable(RestItem restItem)
        {
            isRestAlwaysAvailable = restItem.IsUsed;
        }

        public static void IncreaseWin()
        {
            WinCount++;
        }
        
        public static void CheckStatus(Player player)
        {
            
            Console.Clear();
            Console.ForegroundColor = TextColor[0];
            Console.WriteLine("+================================+");
            Console.WriteLine("|          PLAYER STATUS         |");
            Console.WriteLine("+--------------------------------+");
            Console.ForegroundColor = TextColor[1];
            Console.WriteLine($"| Name      : {player.Name,-19}|");
            Console.ForegroundColor = TextColor[2];
            Console.WriteLine($"| Hero Type : {player.HeroType,-19}|");
            Console.ForegroundColor = TextColor[3];
            if(player.HP.ToString().Length > 1)
            {
                Console.WriteLine($"| HP        : {player.HP}|{player.MaxHP,-16}|");
            }
            else
            {
                Console.WriteLine($"| HP        : {player.HP}|{player.MaxHP,-17}|");
            }
                
            Console.ForegroundColor = TextColor[4];
            Console.WriteLine($"| Damage    : {player.Damage,-19}|");
            Console.ForegroundColor = TextColor[5];
            Console.WriteLine($"| Gold      : {player.Gold,-19}|");
            Console.ForegroundColor = TextColor[6];
            Console.WriteLine($"| Kills     : {WinCount,-19}|");
            Console.ForegroundColor = TextColor[0];
            Console.WriteLine("+================================+");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Press any key to return.");
            Console.ReadKey(true);
        }

        public static void Rest(Player player)
        {
            Console.Clear();

            DisableRestByWin();

            if (isRestDisabled)
            {
                Console.WriteLine("            _   _\r\n           (.)_(.)\r\n        _ (   _   ) _\r\n       / \\/`-----'\\/ \\\r\n     __\\ ( (     ) ) /__\r\n     )   /\\ \\._./ /\\   (\r\n      )_/ /|\\   /|\\ \\_(");
                Console.WriteLine();
                Console.WriteLine("A tiny frog stares at you with unblinking judgment. Somehow, you lose the will to rest here.");
            }
            else
            {
                Console.WriteLine("There is no frog around. You feel relaxed.");
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
            List<string> encounterOptions = new List<string> { "Take the food!", "Walk away..." };

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
