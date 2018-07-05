using System;
using System.Collections.Generic;

namespace ParkingPricer
{
    public class Menu
    {
        private List<string> _options = new List<string>();
        private string _descriptionMessage;

        public Menu(string descriptionMessage)
        {
            _descriptionMessage = descriptionMessage;
        }

        public void AddOption(string option)
        {
            if (!string.IsNullOrWhiteSpace(option)) 
            {
                _options.Add(option);
            }
        }

        public int Show()
        {
            int selectedOption = 0;
            ConsoleKeyInfo k = new ConsoleKeyInfo();

            do
            {               
                Console.Clear();
                Console.WriteLine(_descriptionMessage);

                for (int i = 0; i < _options.Count; i++)
                {
                    var isSelectedChar = selectedOption == i ? ">" : " ";
                    Console.WriteLine("{0} {1}", isSelectedChar, _options[i]);
                }

                k = Console.ReadKey();

                if (k.Key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 0) selectedOption = _options.Count - 1;
                }

                if (k.Key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption >= _options.Count) selectedOption = 0;
                }
            }
            while (k.Key != ConsoleKey.Enter);

            return selectedOption;
        }
    }
}