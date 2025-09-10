using MiniAdventure.Interfaces;

namespace MiniAdventure.Characters
{
    public class Player
    {
        public string Name;
        public string HeroType;
        public int HP ; //MAXHP?
        public int Damage ;
        public int Gold = 0;

        public Player(string name, string heroType)
        {
            Name = name;
            HeroType = heroType;

            switch (HeroType)
            {
                case "Warrior":
                    HP = 20;
                    Damage = 5;
                    break;

                case "Mage":
                    HP = 15;
                    Damage = 10;
                    break;

                case "Rouge":
                    HP = 18;
                    Damage = 8;
                    break;
            }
        }

        public static Player CreatePlayer(string[] heroTypeOption)
        {
            Console.Clear();
            string name = "";
            //Get Name from user
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
            Player player = new Player(name, heroTypeOption[indexSelected]);   
            
            Console.WriteLine($"Cool, your name is {player.Name} and you are a {player.HeroType}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return player;
        }
    }
}
