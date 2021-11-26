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
        SocialEngine testSocialEngine = new SocialEngine();

        [TestMethod()]
        [DataRow("Alice", 1234, true)]
        public void TestLogin(string username, string password, bool expectedResult)
        {
            // Arrange
            List<User> testUsers = new List<User>();
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
        public void TestRegisterNewUser()
        {
            // Arrange
            

            // Act
            fakeSocialEngine.RegisterNewUser();


            // Assert

        }

        [TestMethod()]
        public void TestCreateUser()
        {
            // Arrange
            var userList = fakeSocialEngine.Users;
            User userToAdd = new User();
            userToAdd.Username = "Alice";
            userToAdd.Password = "12345";
            userToAdd.Id = guid.GetHashCode();

            // Act
            fakeSocialEngine.CreateUser(userToAdd);

            // Assert
            Assert.Fail();
        }
    }
}