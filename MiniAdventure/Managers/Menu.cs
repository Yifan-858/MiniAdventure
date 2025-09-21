
using MiniAdventure.Characters;
using System;

namespace MiniAdventure.Managers
{
    class Menu
    {
        public string Narrative;
        public List<string> Options;
        public int IndexSelected;

        public Menu(string narrative,List<string> options)
        {
            Narrative = narrative;
            Options = options;
            IndexSelected = 0;
        }

        private void DisplayOptions()
        {
            for(int i=0; i<Options.Count; i++)
            {
                string optionSelected = Options[i];
                string pointer;

                if( i == IndexSelected)
                {
                    pointer = ">";
                }
                else
                {
                    pointer = " ";
                }
            
                //Gray out the Rest option when isRestDisabled is true
                //WorldManager.UpdateRest();

                //if( optionSelected == "Rest" && WorldManager.isRestDisabled)
                //{
                //    Console.ForegroundColor = ConsoleColor.DarkGray;
                //}
                //else
                //{
                //    Console.ResetColor();
                //}
                Console.ResetColor();

                Console.WriteLine($"{pointer} {Options[i]}");
            }
        }

        //Return the index of user's choice.
        //If meet an enemy, take in enemy as parameter to re-render its text and image.
        public int ControlChoice(Enemy? enemy=null)
        {
            ConsoleKey keyPressed ;

            do
            
                { 
                Console.Clear();

                if (enemy != null)
                {
                    Console.WriteLine(enemy.Narrative);
                    Console.WriteLine(enemy.Img);
                }
                
                Console.WriteLine(Narrative);
                Console.WriteLine();
                DisplayOptions();

                keyPressed = Console.ReadKey(true).Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    IndexSelected --;

                    //Loop the number to prevent the index go out of range.
                    if(IndexSelected == -1)
                    {
                        IndexSelected = Options.Count - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    IndexSelected ++;

                    if(IndexSelected == Options.Count)
                    {
                        IndexSelected = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return IndexSelected;

        }
    }
}
