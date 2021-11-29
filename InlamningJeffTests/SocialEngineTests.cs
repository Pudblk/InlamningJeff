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
        [DataRow("Bob", "/timeline", "Alice")]
        public void TestReadUserPosts(string user, string command, string userPostsToRead)
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
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
        [DataRow("Charlie", "Bob", "Hello world!")]
        public void TestViewWall(string username, string userToFollow, string message)
        {
            //// Arrange
            //var engine = new SocialEngine();

            //// Act
            //engine.Post(username, message);
            //engine.Post(username, message);
            //engine.Post(username, message);
            //engine.FollowUser(username, userToFollow);


            //// Assert
            //Assert.AreEqual(message, actualPost);
        }

        [TestMethod()]
        [DataRow("Bob", "/post", "@", "Charlie")]
        public void TestTagOtherUser(string user, string command, char tagCharacter, string userToTag)
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

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
        [DataRow("Alice", "/view_messages")]
        public void TestAliceCanSeeAllPrivateMessages(string user, string command)
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }
    }
}