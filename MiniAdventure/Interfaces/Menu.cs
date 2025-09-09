
using MiniAdventure.Characters;
using System;

namespace MiniAdventure.Interfaces
{
    class Menu
    {
        public string Narrative;
        public string[] Options;
        public int IndexSelected;

        public Menu(string narrative,string[] options)
        {
            Narrative = narrative;
            Options = options;
            IndexSelected = 0;
        }

        private void DisplayOptions()
        {
            for(int i=0; i<Options.Length; i++)
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
                Console.WriteLine($"{pointer} {Options[i]}");
            }
        }

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
                DisplayOptions();

                keyPressed = Console.ReadKey(true).Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    IndexSelected --;

                    //Loop the number to prevent the index go out of range.
                    if(IndexSelected == -1)
                    {
                        IndexSelected = Options.Length - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    IndexSelected ++;

                    if(IndexSelected == Options.Length)
                    {
                        IndexSelected = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return IndexSelected;

        }
    }
}
