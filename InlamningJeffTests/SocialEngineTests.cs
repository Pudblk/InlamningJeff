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
        public void TestGetTimeline()
        {
            // Arrange
            var engine = new SocialEngine();
            var userToGetPostsFrom = new User("Alice");
            engine.Users.Add(userToGetPostsFrom);

            var aliceFirstPost = new Post("Hello World!");
            userToGetPostsFrom.Posts.Add(aliceFirstPost);

            var aliceSecondPost = new Post("Goodbye!");
            userToGetPostsFrom.Posts.Add(aliceSecondPost);

            var expectedResult = userToGetPostsFrom.Posts;

            var userToRecievePosts = new User("Bob");
            engine.Users.Add(userToRecievePosts);

            // Act
            var actualResult = engine.GetTimeline("Alice");

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}