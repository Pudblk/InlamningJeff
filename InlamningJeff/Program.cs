using System;

namespace InlamningJeff
{
    class Program
    {
        static void Main(string[] args)
        {
            SocialEngine engine = new SocialEngine();
            ConsoleHelper consoleHelper = new ConsoleHelper();
            Console.WriteLine("Hello");

            while(true)
            {
                var userInputToProcess = Console.ReadLine();

                var processedUserInput = consoleHelper.ProcessUserInput(userInputToProcess);

                var isPrivateMessage = processedUserInput.IsPrivateMessage;
                var hasTaggedUser = processedUserInput.HasTaggedUser;

                var command = processedUserInput.Command;
                var userNameOfSender = processedUserInput.NameOfSender;
                var messageBody = processedUserInput.Body;
                var userNameToInteractWith = processedUserInput.NameOfReciever;

                if (userNameOfSender == "Alice" && command == "view_messages")
                {
                    var allPrivateMessages = engine.GetAllPrivateMessages();
                    foreach (var privateMessage in allPrivateMessages)
                    {
                        Console.WriteLine($"{privateMessage.Body} {privateMessage.TimeStamp} {privateMessage.From}");
                    }
                }

                if (hasTaggedUser)
                {
                    engine.TagUser(userNameOfSender, userNameToInteractWith, messageBody);
                }

                switch (command)
                {
                    case "/post":
                        engine.Post(userNameOfSender, messageBody);
                        break;

                    case "/timeline":
                        var timeline = engine.GetTimeline(userNameToInteractWith);
                        foreach (var post in timeline)
                        {
                            Console.WriteLine($"Post: {post.Body} Timestamp: {post.TimeStamp}");
                        }
                        break;

                    case "/follow":
                        engine.FollowUser(userNameOfSender, userNameToInteractWith);
                        Console.WriteLine($"You started following {userNameToInteractWith}");
                        break;

                    case "/wall":
                        var wallPosts =  engine.GetWall(userNameOfSender);
                        foreach (var wallpost in wallPosts)
                        {
                            Console.WriteLine($"{wallpost.Body} {wallpost.TimeStamp}");
                        }
                        break;

                    case "/send_message":
                        engine.SendPrivateMessage(userNameOfSender, messageBody, userNameToInteractWith);
                        Console.WriteLine($"Message: {messageBody} sent to: {userNameToInteractWith}");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
