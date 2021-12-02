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

        public void Post(string userName, string bodyOfPost)
        {
            Post post = new Post(bodyOfPost);
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

        public void SendPrivateMessage(string userNameOfSender, string messageBody, string userNameOfReciever)
        {
            var sender = Users.FirstOrDefault(user => user.Name == userNameOfSender);
            var reciever = Users.FirstOrDefault(user => user.Name == userNameOfReciever);
            Message message = new Message(messageBody);
            message.From = userNameOfSender;
            message.TimeStamp = DateTime.Now;

            reciever.PrivateMessages.Add(message);
        }

        public List<Post> GetWall(string userName)
        {
            var user = Users.FirstOrDefault(user => user.Name == userName);
            List<Post> wallPosts = new List<Post>();
            foreach (var item in user.Following)
            {
                foreach (var post in user.Posts)
                {
                    wallPosts.Add(post);
                }
            }
            return wallPosts;
        }

        public List<Message> GetAllPrivateMessages()
        {
            List<Message> allPrivateMessages = new List<Message>();
            foreach (User user in Users)
            {
                foreach (Message message in user.PrivateMessages)
                {
                    allPrivateMessages.Add(message);
                }
            }
            return allPrivateMessages;
        }
    }
}
