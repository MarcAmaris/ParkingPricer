using System;
using System.Collections.Generic;

namespace ParkingPricer
{
    /// <summary>
    /// Display a menu with options in cmd
    /// </summary>
    public class ConsoleMenu
    {
        private List<string> _options = new List<string>();
        private string _descriptionMessage;

        public ConsoleMenu(string descriptionMessage)
        {
            _descriptionMessage = descriptionMessage;
        }

        /// <summary>
        /// Add option to menu
        /// </summary>
        /// <param name="option">option to add, added only if not null or whitespace</param>
        public void AddOption(string option)
        {
            if (!string.IsNullOrWhiteSpace(option)) 
            {
                _options.Add(option);
            }
        }

        /// <summary>
        /// Shoz menu in cmd, display options in insertion order
        /// </summary>
        /// <returns>selected option index</returns>
        public int Show()
        {
            int selectedOptionIndex = 0;
            ConsoleKeyInfo k = new ConsoleKeyInfo();

            do
            {           
                // first clear cmd and show description msg    
                Console.Clear();
                Console.WriteLine(_descriptionMessage);

                // show options with char '>' in front of selected option
                for (int i = 0; i < _options.Count; i++)
                {
                    var isSelectedChar = selectedOptionIndex == i ? ">" : " ";
                    Console.WriteLine("{0} {1}", isSelectedChar, _options[i]);
                }

                // Read key, supported keys : up, down and enter
                k = Console.ReadKey();

                // if up, decrease selectedOption index, go to last if selected option was first
                if (k.Key == ConsoleKey.UpArrow)
                {
                    selectedOptionIndex--;
                    if (selectedOptionIndex < 0) selectedOptionIndex = _options.Count - 1;
                }

                // if down, increase selectedOption index, go to first if selected option was last
                if (k.Key == ConsoleKey.DownArrow)
                {
                    selectedOptionIndex++;
                    if (selectedOptionIndex >= _options.Count) selectedOptionIndex = 0;
                }
            }
            while (k.Key != ConsoleKey.Enter);

            // break while if enter is pressed and return selectedOptionIndex
            return selectedOptionIndex;
        }
    }
}