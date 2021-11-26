using System.Collections.Generic;

namespace InlamningJeff
{
    public interface ISocialEngine
    {
        public List<User> Users { get; set; }
        public bool Login(string username, string password);
        public void FollowUser(User userToFollow);
        public bool RegisterNewUser();
    }
}