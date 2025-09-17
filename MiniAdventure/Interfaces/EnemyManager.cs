using MiniAdventure.Characters;

namespace MiniAdventure.Interfaces
{
    public static class EnemyManager
    {
        public static readonly string[] EnemyNames = { "Worm", "Dog", "Monkey", "Candles" };
        public static readonly int[] HpValue = { 10, 12, 16, 20 };
        public static readonly int[] DamageValue = { 3, 4, 8, 1 };
        public static readonly int[] GoldRewardValue = { 2, 3, 5, 6 };
        public static readonly string[] EnemyNarrtives = { 
            "You spot a shiny, delicious apple on the ground. But beaware! A tiny worm pokes its head out, glaring at you like you just insulted its entire family. It clearly does not want to share.",
            "You spot a hotdog in front of you. But beware! The dog might bite. Yes, even a hot dog. Its teeth has no mercy.",
            "You spot a banana in the distance...but a chunky monkey is clinging to it! Try to touch the banana, and it might just be your toughest fight yet.",
            "A half-eaten cake appears from nowhere, seemingly innocent. But you just don't believe this world any more. Something is wrong. Those candles, they will make you regert every bite!" };
       public static readonly string[] EnemyImages = { "\r\n      _        ,..\r\n ,--._\\\\_.--, (-00)\r\n; #         _:(  -)\r\n:          (_____/\r\n:            :\r\n '.___..___.`", 
            "                                  .-.\r\n     (___________________________()6 `-,\r\n-----(   ______________________   /''\"`-----\r\n     //\\\\                      //\\\\\r\n     \"\" \"\"                     \"\" \"\"", 
            "        .--.  .-\"     \"-.  .--.\r\n       / .. \\/  .-. .-.  \\/ .. \\\r\n      | |  '|  /   Y   \\  |'  | |\r\n      | \\   \\  \\ 0 | 0 /  /   / |\r\n       \\ '- ,\\.-\"`` ``\"-./, -' /\r\n        `'-' /_   ^ ^   _\\ '-'`\r\n        .--'|  \\._ _ _./  |'--. \r\n      /`    \\   \\.-.  /   /    `\\\r\n     /       '._/  |-' _.'       \\\r\n    /          ;  /--~'   |       \\\r\n   /        .'\\|.-\\--.     \\       \\\r\n  /   .'-. /.-.;\\  |\\|'~'-.|\\       \\\r\n  \\       `-./`|_\\_/ `     `\\'.      \\\r\n   '.      ;     ___)        '.`;    /\r\n     '-.,_ ;     ___)          \\/   /\r\n      \\   ``'------'\\       \\   `  /\r\n       '.    \\       '.      |   ;/_\r\n     ___>     '.       \\_ _ _/   ,  '--.\r\n   .'   '.   .-~~~~~-. /     |--'`~~-.  \\\r\n  // / .---'/  .-~~-._/ / / /---..__.'  /\r\n ((_(_/    /  /      (_(_(_(---.__    .'", 
            "              (        (\r\n             ( )      ( )          (\r\n      (       Y        Y          ( )\r\n     ( )     |\"|      |\"|          Y\r\n      Y      | |      | |         |\"|\r\n     |\"|     | |.-----| |---.___  | |\r\n     | |  .--| |,~~~~~| |~~~,,,,'-| |\r\n     | |-,,~~'-'___   '-'       ~~| |._\r\n    .| |~       // ___            '-',,'.\r\n   /,'-'     <_// // _  __             ~,\\\r\n  / ;     ,-,     \\\\_> <<_______________;_)\r\n  | ;    {(_)} _,      . |================|\r\n  |     '-.__ ~~~~~~~~~~~|________________|   \r\n  |\\         `'----------|\r\n  | '=._                 |\r\n  :     '=.__            |\r\n   \\         `'==========|\r\n    '-._                 |\r\n        '-.__            |\r\n             `'----------|" };

        //Create a random index for enemey array
        private static readonly Random Rdm = new Random();
        private static int EnemyIndex = 0;
        private static int PreviousIndex = -1;
        private static int PreviousSecondIndex = -1;
        
        public static List<Enemy> GetEnemyArr()
        {
            List<Enemy> enemyArr = new List<Enemy> {};
            for(int i=0; i < EnemyNames.Length; i++)
            {
                Enemy enemy = new Enemy(EnemyNames[i], HpValue[i], DamageValue[i], GoldRewardValue[i], EnemyNarrtives[i],EnemyImages[i]);
                enemyArr.Add(enemy);
            }

            return enemyArr;
        }

         public static int PickRandomEnemy(List<Enemy>enemyArr)
        {
            //Loop through the enemey array without repeating the previous first and second   
            do
            {
                EnemyIndex = Rdm.Next(0, enemyArr.Count);
            } while (EnemyIndex == PreviousIndex || EnemyIndex == PreviousSecondIndex );

            PreviousSecondIndex = PreviousIndex;
            PreviousIndex = EnemyIndex;

            return EnemyIndex;

        }  

        public static void RestoreEnemyHP(List<Enemy> enemyArr)
        {
            for(int i = 0; i < enemyArr.Count; i++)
            {
                enemyArr[i].HP = HpValue[i];
            }
        }

        //Extra Feature: Increase enemy damage and gold by 1 after the player wins
        public static void IncreaseEnemyDamage(List<Enemy> enemyArr)
        {
            foreach(Enemy enemy in enemyArr)
            {
                enemy.Damage ++;
                enemy.GoldReward ++;
            }
        }

        
    }
}
