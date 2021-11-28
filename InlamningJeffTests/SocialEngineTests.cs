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
        SocialEngine testSocialEngine = new SocialEngine();

        [TestMethod()]
        [DataRow("Alice", "1234", true), DataRow("Alice", "12", false), DataRow("Bob", "1234", false)]
        public void TestLogin(string username, string password, bool expectedResult)
        {
            // Arrange
            List<User> testUsers = testSocialEngine.Users;
            User testUser = new User();
            testUser.Username = username;
            testUser.Password = password;
            testUsers.Add(testUser);

            // Act
            var actualResult = testSocialEngine.Login(username, password);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod()]
        [DataRow("Alice", "1234", true), DataRow("Bob", "1234", true)]
        public void TestRegisterNewUser(string username, string password, bool expectedResult)
        {
            // Arrange
            List<User> users = testSocialEngine.Users;


            // Act
            testSocialEngine.RegisterNewUser();


            // Assert
            Assert.Fail();
        }
    }
    internal class FakeSocialEngine : ISocialEngine
    {
        public List<User> Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void FollowUser(User userToFollow)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool RegisterNewUser()
        {
            throw new NotImplementedException();
        }
    }
}