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

        public List<Post> Wall(string user, string message)
        {
            List<Post> allPosts { get; set;}
           return Users.FirstOrDefault(x => x.Name).TimelinePosts;
        }

        public void Post(object username, string message)
        {
            throw new NotImplementedException();
        }
    }
}
