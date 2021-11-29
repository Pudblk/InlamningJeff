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
        public void FollowUser(string username, User userToFollow)
        {

        }

        public void Post(string userName, string textToPost)
        {
            Post post = new Post();
            post.Body = textToPost;
            post.TimeStamp = DateTime.Now;

            var userExist = Users.FirstOrDefault(x => x.Name == userName);

            if(userExist == null)
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
    }
}
