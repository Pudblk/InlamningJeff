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
    public class ConsoleHelperTests
    {
        [TestMethod()]
        [DataRow("Alice /post Hello World!", "/post"),
         DataRow("Alice /timeline", "/timeline"),
         DataRow("Alice /follow Hello World!", "/follow"),
         DataRow("Bob /post @Charlie what are your plans tonight?", "/post")]

        public void TestGetCommandFromUserInput(string userInput, string expectedResult)
        {
            // Arrange
            var consoleHelper = new ConsoleHelper();

            // Act
            var commandFromUserInput = consoleHelper.GetCommandFromUserInput(userInput);

            // Assert
            Assert.AreEqual(expectedResult, commandFromUserInput);
        }

        [TestMethod()]
        [DataRow("Alice /post Hello World!", "Alice"),
         DataRow("Spongebob /follow", "Spongebob"),
         DataRow("Bob /post @Charlie what are your plans tonight?", "Bob")]
        public void TestGetUserNameFromUserInput(string userInput, string expectedResult)
        {
            // Arrange
            var consoleHelper = new ConsoleHelper();

            // Act
            var userNameFromUserInput = consoleHelper.GetUserNameFromUserInput(userInput);

            // Assert
            Assert.AreEqual(expectedResult, userNameFromUserInput);
        }

        [TestMethod()]
        [DataRow("Bob /send_message Alice Hello Alice!", "Alice"),
         DataRow("Bob /send_message Charlie what are your plans tonight?", "Charlie")]
        public void TestGetRecieverUserNameFromUserInput(string userInput, string expectedResult)
        {
            // Arrange
            var consoleHelper = new ConsoleHelper();

            // Act
            var recieverUserNameFromUserInput = consoleHelper.GetRecieverUserNameFromUserInput(userInput);

            // Assert
            Assert.AreEqual(expectedResult, recieverUserNameFromUserInput);
        }

        [TestMethod()]
        [DataRow("Bob /send_message Alice Hello Alice!", "Hello Alice!"),
         DataRow("Bob /send_message Charlie What are your plans tonight?", "What are your plans tonight?")]
        public void TestGetMessageBodyFromUserInput(string userInput, string expectedResult)
        {
            // Arrange
            var consoleHelper = new ConsoleHelper();

            // Act
            var messageBody = consoleHelper.GetMessageBodyFromUserInput(userInput);

            // Assert
            Assert.AreEqual(expectedResult, messageBody);
        }

        [TestMethod()]
        [DataRow("Alice /post @Charlie Lunch?", "Charlie")]
        [DataRow("Alice /post @Spongebob Seafood?", "Spongebob")]
        public void TestGetUserNameOfTaggedUser(string userInput, string expectedResult)
        {
            // Arrange
            var consoleHelper = new ConsoleHelper();

            // Act
            var nameOfTaggedUser = consoleHelper.GetUserNameOfTaggedUser(userInput);

            // Assert
            Assert.AreEqual(expectedResult, nameOfTaggedUser);
        }
    }
}