namespace MiniAdventure.Interfaces
{
    public static class GameManager
    {
        public static int WinCount = 0;

        //Extra Feature: Disable Rest every second fight round
        public static bool disableRest = false;
        public static bool UpdateDisableRest()
        {
            return disableRest = WinCount != 0 && WinCount % 2 == 0;
        }
        
       
    } 
}
