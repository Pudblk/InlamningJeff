using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff
{
    public class SocialEngine : ISocialEngine
    {
        public List<User> Users { get; set; }

        public SocialEngine()
        {

        }
        public bool Login(string username, string password)
        {
            bool loginResult = false;
            return false;
        }
        public void RegisterNewUser()
        {

        }
        public void CreateUser(User userToCreate)
        {

        }
        public void FollowUser(User userToFollow)
        {

        }
    }
}
