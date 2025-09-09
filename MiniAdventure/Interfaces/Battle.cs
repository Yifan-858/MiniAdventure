
using MiniAdventure.Characters;

namespace MiniAdventure.Interfaces
{
    public static class Battle
    {
        public static bool IsPlayerAlive(Player player )
        {
            if(player.HP <= 0)
            {
                Console.WriteLine("Your Hp is 0. Game over.");
                return false;
            }   

            return true;
        }

        public static bool IsEnemyAlive(Enemy enemy)
        {
             if(enemy.HP <= 0)
             {
                Console.WriteLine($"Enemy's Hp is 0. You win. You got {enemy.GoldReward}");
                return false;
             }

             return true;

        }
        public static void Attack(Player player, Enemy enemy, bool isPlayersTurn)
        {
            Console.Clear();
            Console.WriteLine(enemy.Narrative);
            Console.WriteLine(enemy.Img);

            while(player.HP > 0 && enemy.HP > 0)
            {
                if (isPlayersTurn)
                {
                    enemy.HP -= player.Damage;
                    Console.WriteLine($"You attacked {enemy.Name}. Caused {player.Damage} damage.");
                }
                else
                {
                    player.HP -= enemy.Damage;
                    Console.WriteLine($"{enemy.Name} attacked you. Caused {enemy.Damage} damage.");
                }

                isPlayersTurn = !isPlayersTurn;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
            
        }
    }
}
