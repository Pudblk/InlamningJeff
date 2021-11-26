using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff
{
    public class User : IUser
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public User()
        {

        }
    }
}
