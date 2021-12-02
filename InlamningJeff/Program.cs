﻿using System;

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

                var isPrivateMessage = userInputToProcess.Contains("/send_message");
                var hasTaggedUser = userInputToProcess.Contains('@');

                var command = consoleHelper.GetCommandFromUserInput(userInputToProcess);
                var userNameOfSender = consoleHelper.GetUserNameFromUserInput(userInputToProcess);
                var messageBody = consoleHelper.GetMessageBodyFromUserInput(userInputToProcess);
                var userNameToInteractWith = consoleHelper.GetUserNameToInteractWith(userInputToProcess);

                if(userNameOfSender == "Alice" && command == "view_messages")
                {
                    var allPrivateMessages = engine.GetAllPrivateMessages();
                    foreach (var privateMessage in allPrivateMessages)
                    {
                        Console.WriteLine($"{privateMessage.Body} {privateMessage.TimeStamp} {privateMessage.From}");
                    }
                }

                if (hasTaggedUser)
                {
                    userNameToInteractWith = consoleHelper.GetUserNameOfTaggedUser(userInputToProcess);
                    engine.TagUser(userNameOfSender, userNameToInteractWith, messageBody);
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
