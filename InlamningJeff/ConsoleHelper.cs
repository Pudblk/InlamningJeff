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

        public UserInput ProcessUserInput(string inputByUser)
        {
            UserInput userInput = new UserInput();
            userInput.NameOfSender = GetUserNameFromUserInput(inputByUser);
            userInput.NameOfReciever = GetRecieverUserNameFromUserInput(inputByUser);
            userInput.Command = GetCommandFromUserInput(inputByUser);
            userInput.HasTaggedUser = inputByUser.Contains('@');
            userInput.IsPrivateMessage = inputByUser.Contains("/send_message");
            userInput.Body = GetMessageBodyFromUserInput(inputByUser);
            return userInput;
        }

        public string GetRecieverUserNameFromUserInput(string userInputToGetRecieverNameFrom)
        {
            userInputToGetRecieverNameFrom.Trim();
            string[] choppedInput = userInputToGetRecieverNameFrom.Split(' ');
            var recieverUserNameFromInput = choppedInput[2];
            return recieverUserNameFromInput;
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
            return commandFromUserInput;
        }

        public string GetUserNameFromUserInput(string userInputToGetNameFrom)
        {
            userInputToGetNameFrom.Trim();
            var lastIndexOfUserName = userInputToGetNameFrom.IndexOf(' ');
            var userName = userInputToGetNameFrom.Substring(0, lastIndexOfUserName);
            return userName;
        }

        public string GetMessageBodyFromUserInput(string userInputToGetMessageBodyFrom)
        {
            userInputToGetMessageBodyFrom.Trim();

            string[] choppedUserInput = userInputToGetMessageBodyFrom.Split(' ');
            string messageBody = choppedUserInput.Skip(3).Aggregate("", (current, next) => $"{current} {next}").Trim();

            return messageBody;
        }

        public string GetUserNameOfTaggedUser(string userInputToGetTaggedUserFrom)
        {
            userInputToGetTaggedUserFrom.Trim();

            var startIndexOfUserName = 1 + userInputToGetTaggedUserFrom.IndexOf('@');
            var userNameLength = 0;
            for (int i = startIndexOfUserName; i < userInputToGetTaggedUserFrom.Length; i++)
            {
                if (userInputToGetTaggedUserFrom[i] == ' ')
                {
                    userNameLength = i - startIndexOfUserName;
                    break;
                }
            }
            string taggedUserName = userInputToGetTaggedUserFrom.Substring(startIndexOfUserName, userNameLength);

            return taggedUserName;
        }

        public string GetUserNameToInteractWith(string userInputToGetFollowingNameFrom)
        {
            userInputToGetFollowingNameFrom.Trim();

            string[] choppedUserInput = userInputToGetFollowingNameFrom.Split(' ');
            string userNameToFollow = choppedUserInput[2];
            return userNameToFollow;
        }
    }
}
