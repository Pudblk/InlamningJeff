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
        public void TestRegisterNewUser()
        {
            // Arrange


            // Act


            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void TestCreateUser()
        {
            // Arrange
            User userToAdd = new User();
            userToAdd.Username = "Alice";
            userToAdd.Password = "12345";

            // Act

            // Assert
            Assert.Fail();
        }
    }
}