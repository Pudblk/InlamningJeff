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
                Console.WriteLine("What do you want to do?");
                var userInputToProcess = Console.ReadLine();
                var isPrivateMessage = userInputToProcess.Contains("/send_message");
                var hasTaggedUser = userInputToProcess.Contains('@');

                var command = consoleHelper.GetCommandFromUserInput(userInputToProcess);
                var userNameOfSender = consoleHelper.GetUserNameFromUserInput(userInputToProcess);
                var messageBody = consoleHelper.GetMessageBodyFromUserInput(userInputToProcess);
                string userNameToInteractWith = null;

                if (hasTaggedUser)
                {
                    //userNameToInteractWith = consoleHelper.GetUserNameOfTaggedUser(userInputToProcess);
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
                        //engine.GetTimeline(userNameOfSender, userNameOfReciever);
                        break;

                    case "/follow":
                        //engine.FollowUser();
                        break;

                    case "/wall":
                        //engine.GetWall();
                        break;

                    case "/send_message":
                        //engine.SendPrivateMessage();
                        break;

                    case "view_messages":
                        //engine.GetAllPrivateMessages();
                        break;

                    default:
                        break;
                }

                Console.WriteLine("Do you want to continue: Y/N");
                if (command == "N")
                {
                    running = false;
                }
            }
        }
    }
}
