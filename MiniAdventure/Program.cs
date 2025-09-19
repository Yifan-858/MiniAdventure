using MiniAdventure.Characters;
using MiniAdventure.Managers;
using System.Media;

namespace MiniAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get enemies
            List<Enemy> enemyArr = EnemyManager.GetEnemyArr();
            int enemyIndex = 0;

            //World
             string[] worldNarrative = { "Welcome to this strange world. You are on a bizzard street when you open your eyes. Oddly, you are very hungry. You look around and decide to...","You ate up the food, but don't feel anything in you belly. You decide to..." };
             string[] worldOptions = { "Explore", "Rest", "Check Status", "Quit Game" };

            //Start Game
            bool inGame = true;

            SoundPlayer soundPlayer = new SoundPlayer("Spookwave.wav");
            soundPlayer.PlayLooping();

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
                            WorldManager.Explore(player, enemyArr[enemyIndex], enemyArr);
                            break;

                        case 1:
                            WorldManager.Rest(player);   
                            break;
                                
                        case 2:
                            WorldManager.CheckStatus(player);
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
