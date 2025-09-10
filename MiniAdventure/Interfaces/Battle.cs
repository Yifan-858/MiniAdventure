
using MiniAdventure.Characters;
using System;

namespace MiniAdventure.Interfaces
{
    public static class Battle
    {
        public static void EnterBattle(Player player, Enemy enemy, ref int winCount)
        {
            Console.Clear();
            Console.WriteLine(enemy.Narrative);
            Console.WriteLine(enemy.Img);
            Console.WriteLine();

            bool isInBattle = true;

            while (isInBattle) 
            { 
                string battleNarrative = "You action:";
                string[] battleOptions = { "Fight", "Check your status", "Check enemy status","Oh no, I didn't mean to loss!" };

                Menu battleMenu = new Menu(battleNarrative, battleOptions);
                int indexSelected = battleMenu.ControlChoice(enemy);

                switch (indexSelected)
                {
                    case 0:
                        isInBattle= Fight(player, enemy, ref winCount);
                        break;

                    case 1:
                        World.CheckStatus(player, winCount);
                        break;

                    case 2:
                        CheckEnemyStatus(enemy);
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("You try to avoid the fight and flee.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey(true);
                        isInBattle = false;
                        break;

                    default:
                        Console.WriteLine("Invalid options");
                        break;
                }
            }

        }
        public static bool Fight(Player player, Enemy enemy, ref int winCount)
        {
            Console.Clear();
            Console.WriteLine(enemy.Narrative);
            Console.WriteLine(enemy.Img);

            //Player's turn
            enemy.HP -= player.Damage;
            Console.WriteLine($"You attacked the {enemy.Name}. Caused {player.Damage} damage.");

            if (!isEnemyAlive(enemy))
            {
                GainGold(player, enemy);
                winCount ++;
                Console.WriteLine($"The {enemy.Name}'s Hp is 0. You got the food and {enemy.GoldReward} gold.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                return false;
            }

            //Enemy's turn
            Console.WriteLine($"The {enemy.Name}'s turn...(press any key)");
            Console.ReadKey(true);
            Console.WriteLine($"The {enemy.Name} attacked you.");
            player.HP -= enemy.Damage;
            Console.WriteLine($"You took {enemy.Damage} damage!");

            if (!isPlayerAlive(player))
            {
                Console.WriteLine("Your Hp is 0.");
                Thread.Sleep(1000);
                Console.WriteLine("You are too hungry to fight back...");
                Thread.Sleep(1000);
                Console.WriteLine("  ____                         ___                 \r\n / ___| __ _ _ __ ___   ___   / _ \\__   _____ _ __ \r\n| |  _ / _` | '_ ` _ \\ / _ \\ | | | \\ \\ / / _ \\ '__|\r\n| |_| | (_| | | | | | |  __/ | |_| |\\ V /  __/ |   \r\n \\____|\\__,_|_| |_| |_|\\___|  \\___/  \\_/ \\___|_|   ");
                Environment.Exit(0);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            return true;
                    
        }
        public static bool isPlayerAlive(Player player )
        {
            if(player.HP <= 0)
            {
                return false;
            }   

            return true;
        }

        public static bool isEnemyAlive(Enemy enemy)
        {
             if(enemy.HP <= 0)
             {
                return false;
             }

             return true;

        }

        public static void GainGold(Player player, Enemy enemy)
        {
            player.Gold += enemy.GoldReward;
        }

        public static void CheckEnemyStatus(Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("+================================+");
            Console.WriteLine("|           ENEMY STATUS         |");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine($"| Name      : {enemy.Name,-19}|");
            Console.WriteLine($"| HP        : {enemy.HP,-19}|");
            Console.WriteLine($"| Damage    : {enemy.Damage,-19}|");
            Console.WriteLine($"| Gold      : {enemy.GoldReward,-19}|");
            Console.WriteLine("+================================+");

            Console.WriteLine($"Press any key to return.");
            Console.ReadKey(true);
        }

    }
}
