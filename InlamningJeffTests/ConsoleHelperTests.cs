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
        [DataRow("Alice /post Hello World!")]
        public void GetCommandFromUserInput(string userInput)
        {
            // Arrange
            var consoleHelper = new ConsoleHelper();

            // Act
            var commandFromUserInput = consoleHelper.GetCommandFromUserInput(userInput);

            // Assert
            Assert.AreEqual("/post", commandFromUserInput);
        }

        [TestMethod()]
        [DataRow("Alice /post Hello World!")]
        public void TestProcessUserInput(string inputToProcess)
        {
            // Arrange
            var consoleHelper = new ConsoleHelper();
            string[] expectedResult = { "Alice", "/post", "Hello World!" };

            // Act
            var actualResult = consoleHelper.ProcessUserInput(inputToProcess);
            bool isTheSame = expectedResult.SequenceEqual(actualResult);

            // Assert
            Assert.IsTrue(isTheSame);
        }
    }
}