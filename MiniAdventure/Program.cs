using MiniAdventure.Characters;
using MiniAdventure.Interfaces;

namespace MiniAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Generate an array of the enemies

            //basic values
            string[] enemyNames = { "Apple", "Sausage", "Banana", "Cake" };
            int[] hpValue = { 10, 12, 16, 20 };
            int[] damageValue = { 3, 6, 10, 2 };
            int[] goldRewardValue = { 2, 3, 5, 6 };

            //generate logic
            Random randomNumber = new Random();
            int index = randomNumber.Next(0, enemyNames.Length);
            List<Enemy> enemyArr = new List<Enemy> {};

            for(int i=0; i < enemyNames.Length; i++)
            {
                Enemy enemy = new Enemy(enemyNames[i], hpValue[i], damageValue[i], goldRewardValue[i]);
                enemyArr.Add(enemy);
            }

            //Start Game
            while (true)
            {   
                Console.WriteLine("HungerGame");
                Console.WriteLine("Press Enter to start the game");

                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.Enter)
                {
                    //Initialize the player
                    Player player = null;

                    while(player == null)
                    { 
                        //Get Name
                        Console.WriteLine("Create your character"); 
                        Console.WriteLine("Enter your name here:");
                        string name = Console.ReadLine()!;

                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Please enter a name");
                            continue;
                        }

                        //Get HeroType
                        string[] heroTypeOption = { "Warrior", "Mage", "Rogue" };

                        Console.WriteLine("Choose your hero by typing the name excatly:");
                        for(int i=0; i<heroTypeOption.Length; i++)
                        {
                            Console.WriteLine($"> {heroTypeOption[i]}");
                        }

                        string heroType = Console.ReadLine()!.Trim();

                        if (string.IsNullOrEmpty(heroType))
                        {
                            Console.WriteLine("You entered nothing. Please enter a hero type.");
                            continue;
                        }
                        else if(heroType != "Warrior" && heroType != "Mage" && heroType != "Rogue")
                        { 
                            Console.WriteLine("You typed something wrong. Please re-enter a hero type.");
                            continue;
                        }

                        //Create the player
                        player = new Player(name, heroType);

                        continue;
                    }

                    bool isGaming = true;
                    
                    while (isGaming) 
                    { 
                        //Create the world menu
                        string[] worldNarrative = { "Welcome to this strange world. You are on a bizzard street when you open your eyes. Oddly, you are very hungry. You decide to...","You ate up the food, but don't feel anything in you belly. You decide to..." };
                        string[] worldOptions = { "Explore", "Rest", "Check Status", "Quit Game" };
                        Menu worldMenu = new Menu(worldNarrative[0], worldOptions);
                        int indexSelected = worldMenu.Run();

                        switch (worldOptions[indexSelected])
                        {
                            case "Quit Game":
                                Console.WriteLine("See you soon.");
                                isGaming = false;
                                return;

                            case "Check Status":
                                Console.WriteLine($"Name: {player.Name}");
                                Console.WriteLine($"Hero Type: {player.HeroType}");
                                Console.WriteLine($"HP: {player.HP}");
                                Console.WriteLine($"Damage: {player.Damage}");
                                Console.WriteLine($"Gold: {player.Gold}");
                                Console.WriteLine($"Press any key to return");
                                Console.ReadKey(true);
                                break;

                            case "Rest":
                                player.HP += 2;
                                Console.WriteLine($"You took a nap. Gain 2 HP.");
                                Console.WriteLine($"HP: {player.HP}");
                                Console.WriteLine($"Press any key to return");
                                Console.ReadKey(true);
                                break;

                            case "Explore":
                                Console.WriteLine(indexSelected);
                                Console.ReadKey(true);
                                break;

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
