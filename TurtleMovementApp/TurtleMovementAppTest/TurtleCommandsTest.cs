using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleMovementApp;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace TurtleMovementAppTest
{
    [TestClass]
    public class TurtleCommandsTest
    {
        /// <summary>
        /// This method is used to read the text file and fill it in the list of strings
        /// This method test to skips the commands before the first place command
        /// This method also skips the empty lines from the file  
        /// </summary>
        [TestMethod]
        public void TestGetCommandsMethod()
        {
            TurtleCommands turCommands = new TurtleCommands();
            var resourceName = "TurtleMovementAppTest.Files.TurtleMovementCommands.txt";

            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resourceName);

            List<string> commandLines = turCommands.GetCommands(stream);

            Assert.AreEqual(14, commandLines.Count);

        }
    }
}
