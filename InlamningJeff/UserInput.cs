using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff
{
    public class UserInput
    {
        public string NameOfSender { get; set; }
        public string NameOfReciever { get; set; }
        public string Command { get; set; }
        public string Body { get; set; }
        public bool HasTaggedUser { get; set; }
        public UserInput()
        {
            
        }
    }
}
