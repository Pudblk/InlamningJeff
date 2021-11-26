using Microsoft.VisualStudio.TestTools.UnitTesting;
using InlamningJeff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningJeff.Tests
{
    [TestClass()]
    public class SocialEngineTests
    {
        Guid guid = new Guid();
        FakeSocialEngine fakeSocialEngine = new FakeSocialEngine();

        [TestMethod()]
        public void TestCreateUser()
        {
            // Arrange
            var userList = fakeSocialEngine.Users;
            User userToAdd = new User();
            userToAdd.Username = "Alice";
            userToAdd.Id = guid.GetHashCode();

            // Act
            fakeSocialEngine.CreateUser(userToAdd);

            // Assert
            Assert.Fail();
        }

    }
    internal class FakeSocialEngine : ISocialEngine
    {
        public List<User> Users { get; set; }

        public void CreateUser(User userToCreate)
        {
            throw new NotImplementedException();
        }

        public void FollowUser(User userToFollow)
        {
            throw new NotImplementedException();
        }
    }
}