using MiniAdventure.Interfaces;

namespace MiniAdventure.Characters
{
    public class Player
    {
        public string Name;
        public string HeroType;
        public int HP ;
        public int MaxHP;
        public int Damage ;
        public int Gold = 0;

        public Player(string name, string heroType, int selectedIndex)
        {
            Name = name;
            HeroType = heroType;

            switch (selectedIndex)
            {
                case 0:
                    HP = 20;
                    MaxHP = 20;
                    Damage = 5;
                    break;

                case 1:
                    HP = 15;
                    MaxHP = 15;
                    Damage = 10;
                    break;

                case 2:
                    HP = 18;
                    MaxHP = 18;
                    Damage = 8;
                    break;
            }
        }

        public static Player CreatePlayer(string[] heroTypeOption)
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
            //Get HeroType
            string createPlayerNarrtive = "Choose your hero type:";
            Menu heroTypeMenu = new Menu(createPlayerNarrtive, heroTypeOption);
            int indexSelected = heroTypeMenu.ControlChoice();

            //Create the player
            Player player = new Player(name, heroTypeOption[indexSelected], indexSelected);

            Console.WriteLine();
            Console.WriteLine($"Cool, your name is {player.Name} and you are a {player.HeroType}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return player;
        }
    }
}
