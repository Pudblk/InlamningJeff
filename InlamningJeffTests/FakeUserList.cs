using InlamningJeff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeffTests
{
    public class FakeUserList
    {
        public List<User> FakeFilledUserList { get; set; }

        public FakeUserList()
        {
        }
        public List<User> GetFilledUserList()
        {
            return FakeFilledUserList;
        }
    }
}
