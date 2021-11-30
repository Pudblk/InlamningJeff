using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff
{
    public class User
    {
        public string Name { get; set; }
        public List<Message> PrivateMessages { get; set; }
        public List<Post> Posts { get; set; }
        public List<User> Following { get; set; }
        public List<Post> Wall { get; set; }

        public User(string userName)
        {
            Name = userName;
            Posts = new List<Post>();
            Following = new List<User>();
            PrivateMessages = new List<Message>();
            Wall = new List<Post>();
        }
    }
}
