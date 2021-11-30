using InlamningJeff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeffTests
{
    public class FakeEngineData
    {
        public List<User> Users { get; set; }
        public FakeEngineData()
        {
            Users = new List<User>();
        }

        public List<Post> GetFakePosts()
        {
            var fakePosts = new List<Post>();

            for(int i = 0; i < 10; i++)
            {
                Post post = new Post($"This is post: {i}");
                fakePosts.Add(post);
            }

            return fakePosts;
        }
    }
}
