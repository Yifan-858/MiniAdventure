using MiniAdventure.Characters;
using MiniAdventure.Interfaces;

namespace MiniAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Herotypes
             string[] heroTypeOption = { "Warrior", "Mage", "Rogue" };

            //World
             string[] worldNarrative = { "Welcome to this strange world. You are on a bizzard street when you open your eyes. Oddly, you are very hungry. You look around and decide to...","You ate up the food, but don't feel anything in you belly. You decide to..." };
             string[] worldOptions = { "Explore", "Rest", "Check Status", "Quit Game" };

            //Generate an array of the enemies
            string[] enemyNames = { "Apple", "Sausage", "Banana", "Cake" };
            int[] hpValue = { 10, 12, 16, 20 };
            int[] damageValue = { 3, 6, 10, 2 };
            int[] goldRewardValue = { 2, 3, 5, 6 };
            string[] enemyNarrtives = { "Oh, you see an delicious apple on the side. But someone is enjoy it. A worm sticks its head out of the apple. It does not like to share the apple with you.","oh, Dog","Oh, Monkey","Oh,Cake" };
            string[] enemyImages = { "AppleImg", "dOgImg", "monkeyImg", "cakeImg" };

            List<Enemy> enemyArr = new List<Enemy> {};
            for(int i=0; i < enemyNames.Length; i++)
            {
                Enemy enemy = new Enemy(enemyNames[i], hpValue[i], damageValue[i], goldRewardValue[i],enemyNarrtives[i],enemyImages[i]);
                enemyArr.Add(enemy);
            }
     
            
            //Start Game
            bool inGame = true;

            while (inGame)
            {   
                Console.WriteLine("HungerGame");
                Console.WriteLine("Press Enter to start the game");

                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.Enter)
                {
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
                        Random rdm = new Random();
                        int enemyIndex = rdm.Next(0, enemyArr.Count - 1);//not same number

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
}
