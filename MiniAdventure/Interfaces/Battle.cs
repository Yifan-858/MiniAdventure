
using MiniAdventure.Characters;
using System;

namespace MiniAdventure.Interfaces
{
    public static class Battle
    {
        public static void EnterBattle(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine(enemy.Narrative);
            Console.WriteLine(enemy.Img);

            bool isInBattle = true;

            while (isBattle) 
            { 
                string battleNarrative = "You action:";
                string[] battleOptions = { "Fight", "Check your status", "Check enemy status","Oh no, I didn't mean to fight!" };

                Menu battleMenu = new Menu(battleNarrative, battleOptions);
                int indexSelected = battleMenu.ControlChoice(enemy);

                switch (battleOptions[indexSelected])
                {
                    case "Fight":
                        isInBattle= Fight(player, enemy);
                        break;

                    case "Check your status":
                        World.CheckStatus(player);
                        break;

                    case "Check enemy status":
                        CheckEnemyStatus(enemy);
                        break;

                    case "Oh no, I didn't mean to fight!":
                        Console.WriteLine("You try to avoid the fight and leave.");
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
        public static bool Fight(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine(enemy.Narrative);
            Console.WriteLine(enemy.Img);

            //Player's turn
            enemy.HP -= player.Damage;
            Console.WriteLine($"You attacked {enemy.Name}. Caused {player.Damage} damage.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);

            if (!isEnemyAlive(enemy))
            {
                GainGold(player, enemy);
                Console.WriteLine($"{enemy.Name}'s Hp is 0. You win. You got {enemy.GoldReward} gold.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                return false;
            }

            //Enemy's turn
            Console.WriteLine($"{enemy.Name} attacked you.");
            player.HP -= enemy.Damage;
            Console.WriteLine($"You took {enemy.Damage} damage!");

            if (!isPlayerAlive(player))
            {
                Console.WriteLine("Your Hp is 0.");
                Console.WriteLine("=== GAME OVER ===");
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
            Console.WriteLine("|          PLAYER STATUS         |");
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
