using System.Collections.Generic;

namespace InlamningJeff
{
    public interface ISocialEngine
    {
        public List<User> Users { get; set; }
        public void CreateUser(User userToAdd);
        public void FollowUser(User userToFollow);
    }
}