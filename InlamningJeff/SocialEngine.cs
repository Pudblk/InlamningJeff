using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff
{
    public class SocialEngine
    {
        public List<User> Users { get; set; }
        public SocialEngine()
        {
            Users = new List<User>();
        }

        public void Post(string userName, string textToPost)
        {
            Post post = new Post(textToPost);

            var userExist = Users.FirstOrDefault(x => x.Name == userName);

            if (userExist == null)
            {
                var userToCreate = new User(userName);
                userToCreate.Posts.Add(post);
                Users.Add(userToCreate);
            }
            else
            {
                userExist.Posts.Add(post);
            }
        }

        public List<Post> GetTimeline(string userToGetTimelineFrom)
        {
            var list = new List<Post>();

            var userTimeline = Users.FirstOrDefault(user => user.Name == userToGetTimelineFrom);

            list = userTimeline.Posts;

            return list;
        }

        public void FollowUser(string userToFollow, string userNameOfFollower)
        {
            var followUser = Users.FirstOrDefault(user => user.Name == userToFollow);
            var followingUser = Users.FirstOrDefault(user => user.Name == userNameOfFollower);
            followingUser.Following.Add(followUser);
        }

        public void GetWall(string userName)
        {
            var user = Users.FirstOrDefault(user => user.Name == userName);

            foreach (var item in user.Following)
            {
                foreach (var post in user.Posts)
                {
                    user.Wall.Add(post);
                }
            }
        }

        public void ProcessUserInput(string inputToProcess)
        {
            string userName, userCommand, userMessage;
            inputToProcess.Trim();

            string[] choppedInput = inputToProcess.Split(" ");
            userName = choppedInput[0];
            userCommand = choppedInput[1];
            userMessage = choppedInput.Skip(2).Aggregate("", (current, next) => $"{current} {next}").Trim();
        }
    }
}
