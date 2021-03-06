using Microsoft.VisualStudio.TestTools.UnitTesting;
using InlamningJeff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InlamningJeffTests;

namespace InlamningJeff.Tests
{
    [TestClass()]
    public class SocialEngineTests
    {
        //[TestInitialize]

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
        [DataRow("Mallory", "Message To Alice", "Alice")]
        [DataRow("Bob", "What are your plans tonight?", "Alice")]
        public void TestSendPrivateMessage(string userNameOfSender, string messageBody, string userNameOfReciever)
        {
            // Arrange
            var engine = new SocialEngine();
            var userToSendPrivateMessage = new User(userNameOfSender);
            engine.Users.Add(userToSendPrivateMessage);

            var userToRecieveMessage = new User(userNameOfReciever);
            engine.Users.Add(userToRecieveMessage);


            // Act
            engine.SendPrivateMessage(userNameOfSender, messageBody, userNameOfReciever);
            var recieverInbox = userToRecieveMessage.PrivateMessages.FirstOrDefault(message => message.Body == messageBody).Body;

            // Assert
            Assert.AreEqual(messageBody, recieverInbox);
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
        [DataRow("Bob", "Alice", "Charlie")]
        public void TestGetWall(string userName, string firstUserName, string secondUserName)
        {
            // Arrange
            var engine = new SocialEngine();
            var fakeEngineData = new FakeEngineData();

            var firstUser = new User(firstUserName);
            firstUser.Posts = fakeEngineData.GetFakePosts();
            engine.Users.Add(firstUser);

            var secondUser = new User(secondUserName);
            secondUser.Posts = fakeEngineData.GetFakePosts();
            engine.Users.Add(secondUser);

            var user = new User(userName);
            user.Following.Add(firstUser);
            user.Following.Add(secondUser);
            engine.Users.Add(user);

            var expectedWallResult = user.Wall;

            // Act
            engine.GetWall(userName);
            var actualUser = engine.Users.FirstOrDefault(user => user.Name == userName);
            var actualWallResult = actualUser.Wall;

            // Assert
            Assert.AreEqual(expectedWallResult, actualWallResult);
        }

        [TestMethod()]
        [DataRow("Bob", "Alice", "What are your plans tonight?")]
        public void TestTagUser(string userNameOfSender, string taggedUserName, string postBody)
        {
            // Arrange
            var engine = new SocialEngine();
            var userSender = new User(userNameOfSender);
            engine.Users.Add(userSender);

            var taggedUser = new User(taggedUserName);
            engine.Users.Add(taggedUser);
            bool gotTagged = false;

            string senderCorrectPost = null;
            string recieverCorrectPost = null;

            // Act
            engine.TagUser(userNameOfSender, taggedUserName, postBody);

            foreach (var post in userSender.Posts)
            {
                if (post.Body == postBody)
                {
                    senderCorrectPost = post.Body;
                }
            }

            foreach (var post in taggedUser.Posts)
            {
                if(post.Body == postBody)
                {
                    recieverCorrectPost = post.Body;
                }
            }

            if(senderCorrectPost == recieverCorrectPost)
            {
                gotTagged = true;
            }

            // Assert
            Assert.IsTrue(gotTagged);
        }

        [TestMethod()]
        [DataRow("Mallory", "Message To Alice", "Alice")]
        [DataRow("Bob", "What are your plans tonight?", "Alice")]
        public void TestGetAllPrivateMessages(string userNameOfSender, string privateMessage, string userNameOfReciever)
        {
            // Arrange
            var engine = new SocialEngine();
            List<Message> expectedResult = new List<Message>();

            var user = new User(userNameOfSender);
            engine.Users.Add(user);

            var message = new Message(privateMessage);
            user.PrivateMessages.Add(message);

            expectedResult.Add(message);

            // Act
            var allPrivateMessages = engine.GetAllPrivateMessages();
            bool isMessageSame = false;

            foreach (var sentMessage in allPrivateMessages)
            {
                foreach (var expectedMessage in expectedResult)
                {
                    if(sentMessage == expectedMessage)
                    {
                        isMessageSame = true;
                    }
                }
            }

            // Assert
            Assert.IsTrue(isMessageSame);
        }
    }
}