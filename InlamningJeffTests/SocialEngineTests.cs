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
        [DataRow("Alice", "Hello World!", "Goodbye!", "Bob")]
        [DataRow("Charlie", "First Message", "Second Message", "Alice")]
        public void TestGetTimeline(string userNameToGetFrom, string firstPost, string secondPost, string userNameToRecieve)
        {
            // Arrange
            var engine = new SocialEngine();
            var userToGetPostsFrom = new User(userNameToGetFrom);
            engine.Users.Add(userToGetPostsFrom);

            var aliceFirstPost = new Post(firstPost);
            userToGetPostsFrom.Posts.Add(aliceFirstPost);

            var aliceSecondPost = new Post(secondPost);
            userToGetPostsFrom.Posts.Add(aliceSecondPost);

            var expectedResult = userToGetPostsFrom.Posts;

            var userToRecievePosts = new User(userNameToRecieve);
            engine.Users.Add(userToRecievePosts);

            // Act
            var actualResult = engine.GetTimeline(userNameToGetFrom);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        [DataRow("Alice", "Charlie")]
        [DataRow("Bob", "James")]
        public void TestFollowUser(string leaderUserName, string followerUserName)
        {
            // Arrange
            var engine = new SocialEngine();

            var leader = new User(leaderUserName);
            engine.Users.Add(leader);

            var follower = new User(followerUserName);
            engine.Users.Add(follower);

            var expectedResult = follower.Following;

            // Act
            engine.FollowUser(leaderUserName, followerUserName);

            var actualUser = engine.Users.FirstOrDefault(user => user.Name == followerUserName);
            var actualResult = actualUser.Following;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void TestGetWall()
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }
    }
}