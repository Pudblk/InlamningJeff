using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public List<Message> PrivateMessages { get; set; }

        public User()
        {

        }
    }
}
