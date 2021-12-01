using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff
{
    public class ConsoleHelper
    {
        public ConsoleHelper()
        {

        }
        public string GetCommandFromUserInput(string userInputToGetCommandFrom)
        {
            userInputToGetCommandFrom.Trim();
            string commandFromUserInput = "";

            var startIndexOfCommand = userInputToGetCommandFrom.IndexOf('/');
            for (int i = startIndexOfCommand; i < userInputToGetCommandFrom.Length; i++)
            {
                if (userInputToGetCommandFrom[i] == ' ')
                {
                    return commandFromUserInput;
                }
                else
                {
                    commandFromUserInput += userInputToGetCommandFrom[i];
                    continue;
                }
            }

            return "Something went wrong!";
        }
    }
}
