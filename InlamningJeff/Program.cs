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
                var command = consoleHelper.GetCommandFromUserInput(userInputToProcess);
                var userName = consoleHelper.GetUserNameFromUserInput(userInputToProcess);

                switch (command)
                {
                    case "/post":
                        //engine.Post(userName, textToPost);
                        break;
                    case "/timeline":
                        //engine.GetTimeline();
                        break;
                    case "/follow":
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
