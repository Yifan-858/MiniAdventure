using MiniAdventure.Characters;

namespace MiniAdventure.Interfaces
{
    public static class GameManager
    {
        //Extra Feature: Disable Rest every second round
        public static bool disableRest = false;
        public static bool UpdateDisableRest()
        {
            return disableRest = PlayerManager.WinCount != 0 && PlayerManager.WinCount % 2 == 0;
        }
        
       
    } 
}
