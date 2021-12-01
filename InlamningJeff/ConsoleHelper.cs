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

        public string GetRecieverUserNameFromUserInput(string userInputToGetRecieverNameFrom)
        {
            userInputToGetRecieverNameFrom.Trim();
            var recieverUserName = "";

            return recieverUserName;
        }

        public string GetCommandFromUserInput(string userInputToGetCommandFrom)
        {
            userInputToGetCommandFrom.Trim();
            var haveTaggedUser = userInputToGetCommandFrom.Contains('@');
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
            return commandFromUserInput;
        }

        public string GetUserNameFromUserInput(string userInputToGetNameFrom)
        {
            userInputToGetNameFrom.Trim();
            var lastIndexOfUserName = userInputToGetNameFrom.IndexOf(' ');
            var userName = userInputToGetNameFrom.Substring(0, lastIndexOfUserName);
            return userName;
        }
    }
}
