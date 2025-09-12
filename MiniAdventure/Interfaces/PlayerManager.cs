using MiniAdventure.Characters;

namespace MiniAdventure.Interfaces
{
    public static class PlayerManager
    {
        public static readonly string[] heroTypeOption = { "Spoon Warrior", "Tomato Mage", "Cookie Rogue" };
        public static Player CreatePlayer()
        {
            Console.Clear();
            string name = "";
           
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Create your character"); 
                Console.WriteLine("Enter your name here:");
                name = Console.ReadLine()!;

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Please enter a name");

                }
            }

            //Get HeroType from the user
            string createPlayerNarrtive = "Choose your hero type:";

            //Create HeroType Menu
            Menu heroTypeMenu = new Menu(createPlayerNarrtive, heroTypeOption);
            int indexSelected = heroTypeMenu.ControlChoice();

            //Prepare the player data
            int hp = 0; // ?
            int damage = 0;
            int maxHp = 0;
            int gold = 0;

            switch (indexSelected)
            {
                case 0:
                    hp = 20;
                    maxHp = 20;
                    damage = 5;
                    break;

                case 1:
                    hp = 15;
                    maxHp = 15;
                    damage = 10;
                    break;

                case 2:
                    hp = 18;
                    maxHp = 18;
                    damage = 8;
                    break;
            }

            //Create the player
            Player player = new Player(name, heroTypeOption[indexSelected], hp, maxHp, damage, gold);

            Console.WriteLine();
            Console.WriteLine($"Cool, your name is {player.Name} and you are a {player.HeroType}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return player;
        }
    }
}
