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
        Guid idGenerator = new Guid();
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
        public bool RegisterNewUser()
        {
            bool sucessfullRegistration = false;
            User user = new User();
            
            Console.WriteLine("Please choose a username");
            user.Username = Console.ReadLine();

            Console.WriteLine("Enter a password");
            user.Password= Console.ReadLine();
            user.Id = idGenerator.GetHashCode();
            if (sucessfullRegistration)
            {
                Users.Add(user);
                Console.WriteLine("Registration Sucessfull");
                return true;
            }
            return false;
        }
        public void FollowUser(User userToFollow)
        {

        }
    }
}
