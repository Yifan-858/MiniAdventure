using MiniAdventure.Items;

namespace MiniAdventure.Managers
{
    public class GameManager
    {
        public static int WinCount = 0;

        //Extra Feature: Disable Rest every second fight round
        public static bool disableRest = false;
        public static bool UpdateDisableRest()
        {
            return disableRest = WinCount != 0 && WinCount % 2 == 0;
        }

        public ColorItem paintBallGun = new ColorItem("Paint Ball Gun", "Make your status colorful");

        //UseItem in the shop when check case ColorItem Gold>cost UseItem()
    } 
}
