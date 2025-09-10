using MiniAdventure.Characters;
using MiniAdventure.Interfaces;

namespace MiniAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Herotypes
             string[] heroTypeOption = { "Spoon Warrior", "Tomato Mage", "Cookie Rogue" };

            //World
             string[] worldNarrative = { "Welcome to this strange world. You are on a bizzard street when you open your eyes. Oddly, you are very hungry. You look around and decide to...","You ate up the food, but don't feel anything in you belly. You decide to..." };
             string[] worldOptions = { "Explore", "Rest", "Check Status", "Quit Game" };

            //Enemey
            List<Enemy> enemyArr = EnemeyData.GetEnemyArr();

            //Create a random index for enemey array
            Random rdm = new Random();
            int previousIndex = -1;
            int previousSecondIndex = -1;
            int previousThirdIndex = -1;
            
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
                    player = Player.CreatePlayer(heroTypeOption);
                }

                bool isWorld = true;
                    
                while (isWorld) 
                { 
                    //Create the world menu
                    Menu worldMenu = new Menu(worldNarrative[0], worldOptions);
                    int indexSelected = worldMenu.ControlChoice();

                    //Loop through the enemey array without repeating  
                    int enemyIndex;
                        
                    do
                    {
                        enemyIndex = rdm.Next(0, enemyArr.Count);
                    } while (enemyIndex == previousIndex || enemyIndex == previousSecondIndex || enemyIndex == previousThirdIndex);

                    previousThirdIndex = previousSecondIndex;
                    previousSecondIndex = previousIndex;
                    previousIndex = enemyIndex;
                        

                    switch (worldOptions[indexSelected])
                    {
                        case "Explore":
                            World.Explore(player, enemyArr[enemyIndex]);
                            break;

                        case "Rest":
                            player.HP = World.Rest(player);   
                            break;
                                
                        case "Check Status":
                            World.CheckStatus(player);
                            break;

                        case "Quit Game":
                            inGame = World.QuitGame();
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
