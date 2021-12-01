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
         DataRow("Alice /timeline Hello World!", "/timeline"),
         DataRow("Alice /follow Hello World!", "/follow"),
         DataRow("Bob /post @Charlie what are your plans tonight?", "/post")]
        
        public void GetCommandFromUserInput(string userInput, string expectedResult)
        {
            // Arrange
            var consoleHelper = new ConsoleHelper();

            // Act
            var commandFromUserInput = consoleHelper.GetCommandFromUserInput(userInput);

            // Assert
            Assert.AreEqual(expectedResult, commandFromUserInput);
        }
    }
}