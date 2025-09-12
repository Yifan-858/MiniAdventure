using MiniAdventure.Characters;
using MiniAdventure.Interfaces;

namespace MiniAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Enemy> enemyArr = EnemyManager.GetEnemyArr();

            //World
             string[] worldNarrative = { "Welcome to this strange world. You are on a bizzard street when you open your eyes. Oddly, you are very hungry. You look around and decide to...","You ate up the food, but don't feel anything in you belly. You decide to..." };
             string[] worldOptions = { "Explore", "Rest", "Check Status", "Quit Game" };

            //Count how many battle the player has won
            int winCount = 0;
            int enemyIndex = 0;
            //Start Game
            bool inGame = true;

            while (inGame)
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
   
                Player player = null;

                while(player == null)
                {
                    player = PlayerManager.CreatePlayer();
                }

                bool isWorld = true;
                    
                while (isWorld) 
                { 
                    //Create the world menu
                    Menu worldMenu = new Menu(worldNarrative[0], worldOptions);
                    int indexSelected = worldMenu.ControlChoice();

                    switch (indexSelected)
                    {
                        case 0:
                            enemyIndex = EnemyManager.PickRandomEnemy(enemyArr);
                            WorldManager.Explore(player, enemyArr[enemyIndex], ref winCount, enemyArr);
                            break;

                        case 1:
                            player.HP = WorldManager.Rest(player);   
                            break;
                                
                        case 2:
                            WorldManager.CheckStatus(player, winCount);
                            break;

                        case 3:
                            inGame = WorldManager.QuitGame();
                            return;

                        default:
                            Console.WriteLine("Choose a valid option");
                            break;
                    }
                }                
            }
        }
    }
}
