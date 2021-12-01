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
                var command = consoleHelper.GetCommandFromUserInput(userInputToProcess);
                var userNameOfSender = consoleHelper.GetUserNameFromUserInput(userInputToProcess);
                var userNameOfReciever = "";

                if (isPrivateMessage)
                {
                    userNameOfReciever = consoleHelper.GetRecieverUserNameFromUserInput(userInputToProcess);
                }

                switch (command)
                {
                    case "/post":
                        //engine.Post(userNameOfSender, textToPost);
                        break;

                    case "/timeline":
                        //engine.GetTimeline();
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
