using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Body { get; set; }

        public Post(string body)
        {
            TimeStamp = DateTime.Now;
            Body = body;
        }
    }
}
