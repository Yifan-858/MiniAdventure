using MiniAdventure.Characters;

namespace MiniAdventure.Interfaces
{
    public static class EnemeyData
    {
        public static List<Enemy> GetEnemyArr(int winCount)
        {
            //Generate an array of the enemies
            string[] enemyNames = { "Worm", "Dog", "Monkey", "Candles" };
            int[] hpValue = { 10, 12, 16, 20 };
            int[] damageValue = { 3, 6, 10, 2 };
            int[] goldRewardValue = { 2, 3, 5, 6 };
            string[] enemyNarrtives = { 
                "You spot a shiny, delicious apple on the ground. But beaware! A tiny worm pokes its head out, glaring at you like you just insulted its entire family. It clearly does not want to share.",
                "You spot a hotdog in front of you. But beware! The dog might bite. Yes, even a hot dog. Its teeth has no mercy.",
                "You spot a banana in the distance...but a chunky monkey is clinging to it! Try to touch the banana, and it might just be your toughest fight yet.",
                "A half-eaten cake appears from nowhere, seemingly innocent. But you just don't believe this world any more. Something is wrong. Those candles, they will make you regert every bite!" };
            string[] enemyImages = { "\r\n      _        ,..\r\n ,--._\\\\_.--, (-00)\r\n; #         _:(  -)\r\n:          (_____/\r\n:            :\r\n '.___..___.`", 
                "                                  .-.\r\n     (___________________________()6 `-,\r\n-----(   ______________________   /''\"`-----\r\n     //\\\\                      //\\\\\r\n     \"\" \"\"                     \"\" \"\"", 
                "        .--.  .-\"     \"-.  .--.\r\n       / .. \\/  .-. .-.  \\/ .. \\\r\n      | |  '|  /   Y   \\  |'  | |\r\n      | \\   \\  \\ 0 | 0 /  /   / |\r\n       \\ '- ,\\.-\"`` ``\"-./, -' /\r\n        `'-' /_   ^ ^   _\\ '-'`\r\n        .--'|  \\._ _ _./  |'--. \r\n      /`    \\   \\.-.  /   /    `\\\r\n     /       '._/  |-' _.'       \\\r\n    /          ;  /--~'   |       \\\r\n   /        .'\\|.-\\--.     \\       \\\r\n  /   .'-. /.-.;\\  |\\|'~'-.|\\       \\\r\n  \\       `-./`|_\\_/ `     `\\'.      \\\r\n   '.      ;     ___)        '.`;    /\r\n     '-.,_ ;     ___)          \\/   /\r\n      \\   ``'------'\\       \\   `  /\r\n       '.    \\       '.      |   ;/_\r\n     ___>     '.       \\_ _ _/   ,  '--.\r\n   .'   '.   .-~~~~~-. /     |--'`~~-.  \\\r\n  // / .---'/  .-~~-._/ / / /---..__.'  /\r\n ((_(_/    /  /      (_(_(_(---.__    .'", 
                "              (        (\r\n             ( )      ( )          (\r\n      (       Y        Y          ( )\r\n     ( )     |\"|      |\"|          Y\r\n      Y      | |      | |         |\"|\r\n     |\"|     | |.-----| |---.___  | |\r\n     | |  .--| |,~~~~~| |~~~,,,,'-| |\r\n     | |-,,~~'-'___   '-'       ~~| |._\r\n    .| |~       // ___            '-',,'.\r\n   /,'-'     <_// // _  __             ~,\\\r\n  / ;     ,-,     \\\\_> <<_______________;_)\r\n  | ;    {(_)} _,      . |================|\r\n  |     '-.__ ~~~~~~~~~~~|________________|   \r\n  |\\         `'----------|\r\n  | '=._                 |\r\n  :     '=.__            |\r\n   \\         `'==========|\r\n    '-._                 |\r\n        '-.__            |\r\n             `'----------|" };

            List<Enemy> enemyArr = new List<Enemy> {};
            for(int i=0; i < enemyNames.Length; i++)
            {
                Enemy enemy = new Enemy(enemyNames[i], hpValue[i], damageValue[i] + winCount, goldRewardValue[i] + winCount,enemyNarrtives[i],enemyImages[i]);
                enemyArr.Add(enemy);
            }

            return enemyArr;
        }
    }
}
