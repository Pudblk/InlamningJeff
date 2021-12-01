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
        public string[] ProcessUserInput(string inputToProcess)
        {
            string userName, userCommand, userMessage;
            inputToProcess.Trim();

            string[] choppedInput = inputToProcess.Split(" ");
            userName = choppedInput[0];
            userCommand = choppedInput[1];
            userMessage = choppedInput.Skip(2).Aggregate("", (current, next) => $"{current} {next}").Trim();

            string[] processedInput = { userName, userCommand, userMessage };
            return processedInput;
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
