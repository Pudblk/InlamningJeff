using System;

namespace InlamningJeff
{
    class Program
    {
        static void Main(string[] args)
        {
            SocialEngine engine = new SocialEngine();
            ConsoleHelper consoleHelper = new ConsoleHelper();
            bool running = true;

            while(running)
            {
                Console.WriteLine("Hello");
                var userInputToProcess = Console.ReadLine();
                var isPrivateMessage = userInputToProcess.Contains("/send_message");
                var hasTaggedUser = userInputToProcess.Contains('@');

                var command = consoleHelper.GetCommandFromUserInput(userInputToProcess);
                var userNameOfSender = consoleHelper.GetUserNameFromUserInput(userInputToProcess);
                var messageBody = consoleHelper.GetMessageBodyFromUserInput(userInputToProcess);
                var userNameToInteractWith = consoleHelper.GetUserNameToInteractWith(userInputToProcess);

                if(userNameOfSender == "Alice" && command == "view_messages")
                {
                    var allPrivateMessages = engine.GetAllPrivateMessages();
                }

                if (hasTaggedUser)
                {
                    userNameToInteractWith = consoleHelper.GetUserNameOfTaggedUser(userInputToProcess);
                }

                if (isPrivateMessage)
                {
                    userNameToInteractWith = consoleHelper.GetRecieverUserNameFromUserInput(userInputToProcess);
                }

                switch (command)
                {
                    case "/post":
                        engine.Post(userNameOfSender, messageBody);
                        break;

                    case "/timeline":
                        engine.GetTimeline(userNameToInteractWith);
                        break;

                    case "/follow":
                        engine.FollowUser(userNameOfSender, userNameToInteractWith);
                        break;

                    case "/wall":
                        engine.GetWall(userNameOfSender);
                        break;

                    case "/send_message":
                        //engine.SendPrivateMessage(userNameOfSender, userNameToInteractWith);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
