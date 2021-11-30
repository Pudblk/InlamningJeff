using System;

namespace InlamningJeff
{
    enum Command {Post, TimeLine, Follow, Wall, SendMessage, ViewMessages}
    class Program
    {
       
        static void Main(string[] args)
        {
            SocialEngine engine = new SocialEngine();
            bool running = true;
            string command;
            while(running)
            {
                Console.WriteLine("This is SocialEngine.");
                Console.WriteLine("To interact first write your name followed the command you want to execute.");
                Console.WriteLine("Following commands are avaiable:\n" +
                    "To post to your wall write: \"Your username \" /post.\n" +
                    "To see another users timeline write: \"Your username\" /timeline \"The username of another user.\"\n" +
                    "To follow another user write: \"Your username\" /follow \"The username of another user.\"\n" +
                    "To see a wall of posts from all the users you are following write: \"Your username\" /wall.");
                Console.WriteLine("What do you want to do?");

                engine.ProcessUserInput(Console.ReadLine());


                Console.WriteLine("Do you want to continue: Y/N");
                command = Console.ReadLine();
                if(command == "N")
                {
                    running = false;
                }
            }
        }
    }
}
