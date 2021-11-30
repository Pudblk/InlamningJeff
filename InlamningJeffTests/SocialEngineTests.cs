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
        [TestMethod()]
        [DataRow("Mallory", "Hello World!")]
        [DataRow("Bob", "Goodbye World!")]
        public void TestPost(string expectedUserName, string expectedPost)
        {
            // Arrange
            var engine = new SocialEngine();

            // Act
            engine.Post(expectedUserName, expectedPost);
            var actualUser = engine.Users.FirstOrDefault(user => user.Name == expectedUserName);
            var actualPost = actualUser.Posts.FirstOrDefault(user => user.Body == expectedPost);

            // Assert
            Assert.AreEqual(expectedUserName, actualUser.Name);
            Assert.AreEqual(expectedPost, actualPost.Body);
        }

        [TestMethod()]
        [DataRow("Mallory", "Hello World!", "Alice")]
        [DataRow("Bob", "Goodbye World!", "Alice")]
        public void TestGetWallFromUser(string userName, string message, string userToGetWallFrom)
        {
            // Arrange
            var engine = new SocialEngine();
            

            // Act
            engine.Post(userToGetWallFrom, message);
            engine.Post(userToGetWallFrom, message);
            var user = engine.Users.FirstOrDefault(user => user.Name == userToGetWallFrom);
            var expectedUserWall = user.Posts;
            var actualWall = engine.GetWallFrom(userName);

            // Assert
            Assert.AreEqual(expectedUserWall, actualWall);
        }

        [TestMethod()]
        [DataRow("Charlie", "/follow", "Alice")]
        public void TestFollowOtherUser(string user, string command, string userToFollow)
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("Bob", "Charlie")]
        public void TestTagOtherUser(string user, string userToTag)
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

       

        [TestMethod()]
        [DataRow("Alice")]
        public void TestAliceCanSeeAllPrivateMessages(string user)
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }
    }
}