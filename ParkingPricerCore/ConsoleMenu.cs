using System;
using System.Collections.Generic;

namespace ParkingPricerCore
{
    /// <summary>
    /// Display a menu with options in cmd
    /// </summary>
    public class ConsoleMenu: IConsoleMenu
    {
        private List<string> _keys = new List<string>();
        private List<string> _values = new List<string>();
        private string _descriptionMessage;

        public ConsoleMenu(string descriptionMessage)
        {
            _descriptionMessage = descriptionMessage;
        }

        /// <summary>
        /// Add option to menu
        /// </summary>
        /// <param name="key">option key</param>
        /// <param name="value">option to display, added only if not null or whitespace</param>
        public void AddOption(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(value)) 
            {
                _keys.Add(key);
                _values.Add(value);
            }
        }

        /// <summary>
        /// Shoz menu in cmd, display options in insertion order
        /// </summary>
        /// <returns>selected option key</returns>
        public string Show()
        {
            int selectedOptionIndex = 0;
            ConsoleKeyInfo k = new ConsoleKeyInfo();

            do
            {           
                // first clear cmd and show description msg    
                Console.Clear();
                Console.WriteLine(_descriptionMessage);

                // show options with char '>' in front of selected option
                for (int i = 0; i < _values.Count; i++)
                {
                    var isSelectedChar = selectedOptionIndex == i ? ">" : " ";
                    Console.WriteLine("{0} {1}", isSelectedChar, _values[i]);
                }

                // Read key, supported keys : up, down and enter
                k = Console.ReadKey();

                // if up, decrease selectedOption index, go to last if selected option was first
                if (k.Key == ConsoleKey.UpArrow)
                {
                    selectedOptionIndex--;
                    if (selectedOptionIndex < 0) selectedOptionIndex = _values.Count - 1;
                }

                // if down, increase selectedOption index, go to first if selected option was last
                if (k.Key == ConsoleKey.DownArrow)
                {
                    selectedOptionIndex++;
                    if (selectedOptionIndex >= _values.Count) selectedOptionIndex = 0;
                }
            }
            while (k.Key != ConsoleKey.Enter);

            // break while if enter is pressed and return selected option key
            return _keys[selectedOptionIndex];
        }
    }

    public interface IConsoleMenu
    {
    }
}