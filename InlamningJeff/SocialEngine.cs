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
            Users = new List<User>();
        }
        public bool Login(string username, string password)
        {
            foreach (User user in Users)
            {
                if(user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            Console.WriteLine("Wrong Username or Password");
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
