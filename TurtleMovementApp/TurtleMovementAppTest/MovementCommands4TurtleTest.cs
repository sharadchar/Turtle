using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleMovementApp;
using TurtleMovementApp.Model;

namespace TurtleMovementAppTest
{
    [TestClass]
    public class MovementCommands4TurtleTest
    {
        MovementCommands4Turtle obj;

        [TestInitialize()]
        public void Initialize()
        {
            obj = new MovementCommands4Turtle(Table.GetTableDimension());
        }

        /// <summary>
        /// This method tests the Place method to check if the Place method places the turtle at the specified location
        /// </summary>
        [TestMethod]
        public void TestPlaceMethod()
        {
            int x = 3;
            int y = 4;
            string direction = "North";

            obj.Place(x, y, direction);

            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("North", Turtle.Direction);

        }

        /// <summary>
        /// This method tests the Place method to check if error happen when xAxis is set less than 0
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Placement Error: XAxis should be greater than or equal to 0 and less than 5.")]
        public void TestPlaceMethodforNegXAxisValue()
        {
            int x = -3;
            int y = 4;
            string direction = "North";

            obj.Place(x, y, direction);

        }

        /// <summary>
        /// This method tests the Place method to check if error happen when xAxis is set greater than or equal to the dimension of the table
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Placement Error: XAxis should be greater than or equal to 0 and less than 5.")]
        public void TestPlaceMethodforXAxisValueGt5()
        {
            int x = 5;
            int y = 4;
            string direction = "North";

            obj.Place(x, y, direction);

        }

        /// <summary>
        /// This method tests the Place method to check if error happen when xAxis is set less than 0
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Placement Error: YAxis should be greater than or equal to 0 and less than 5.")]
        public void TestPlaceMethodforNegYAxisValue()
        {
            int x = 3;
            int y = -4;
            string direction = "North";

            obj.Place(x, y, direction);

        }

        /// <summary>
        /// This method tests the Place method to check if error happen when YAxis is set greater or equal to the dimension of the table
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Placement Error: YAxis should be greater than or equal to 0 and less than 5.")]
        public void TestPlaceMethodforNegYAxisValueGT5()
        {
            int x = 3;
            int y = 5;
            string direction = "North";

            obj.Place(x, y, direction);

        }

        /// <summary>
        /// This method tests the Place method to check if error happen when an invalid direction is set
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Placement Error: Invalid Direction.")]
        public void TestPlaceMethodfordirection()
        {
            int x = 3;
            int y = 5;
            string direction = "XXYYL";

            obj.Place(x, y, direction);

        }

        /// <summary>
        /// This method tests the Move method to check test if turtle moves one step when move command is given
        /// </summary>
        [TestMethod]
        public void TestMoveMethod()
        {
            int x = 1;
            int y = 1;
            string direction = "North";
            Turtle.XAxis = x;
            Turtle.YAxis = y;
            Turtle.Direction = direction;

            obj.Move();

            Assert.AreEqual(2, Turtle.YAxis);

            Turtle.Direction = DirectionEnum.East.ToString();
            obj.Move();

            Assert.AreEqual(2, Turtle.XAxis);
            Turtle.Direction = DirectionEnum.South.ToString();
            obj.Move();

            Assert.AreEqual(1, Turtle.YAxis);

            Turtle.Direction = DirectionEnum.West.ToString();
            obj.Move();

            Assert.AreEqual(1, Turtle.XAxis);

        }

        /// <summary>
        /// This method tests the Move method to check Movement out of the edeges of the board
        /// </summary>
        [TestMethod]
        public void TestMoveMethodOutOfBoard()
        {
            int x = 0;
            int y = 0;
            string direction = "South";
            Turtle.XAxis = x;
            Turtle.YAxis = y;
            Turtle.Direction = direction;

            obj.Move();

            Assert.AreEqual(0, Turtle.YAxis);

            Turtle.Direction = DirectionEnum.West.ToString();
            obj.Move();

            Assert.AreEqual(0, Turtle.XAxis);

            Turtle.XAxis = 4;
            Turtle.YAxis = 4;
            Turtle.Direction = DirectionEnum.North.ToString();
            obj.Move();

            Assert.AreEqual(4, Turtle.YAxis);

            Turtle.Direction = DirectionEnum.East.ToString();
            obj.Move();

            Assert.AreEqual(4, Turtle.XAxis);

        }

        /// <summary>
        /// This method tests the Left method to check for the left turn of the turtle
        /// </summary>
        [TestMethod]
        public void TestLeftMethod()
        {
            int x = 3;
            int y = 4;
            string direction = "South";
            Turtle.XAxis = x;
            Turtle.YAxis = y;
            Turtle.Direction = direction;

            obj.Left();
            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("East", Turtle.Direction);


            obj.Left();
            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("North", Turtle.Direction);

            obj.Left();
            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("West", Turtle.Direction);

            obj.Left();
            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("South", Turtle.Direction);
        }

        /// <summary>
        /// This method tests the Right method to check for the right turn of the turtle
        /// </summary>
        [TestMethod]
        public void TestRightMethod()
        {
            int x = 3;
            int y = 4;
            string direction = "South";
            Turtle.XAxis = x;
            Turtle.YAxis = y;
            Turtle.Direction = direction;

            obj.Right();
            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("West", Turtle.Direction);


            obj.Right();
            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("North", Turtle.Direction);

            obj.Right();
            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("East", Turtle.Direction);

            obj.Right();
            Assert.AreEqual(3, Turtle.XAxis);
            Assert.AreEqual(4, Turtle.YAxis);
            Assert.AreEqual("South", Turtle.Direction);
        }

        /// <summary>
        /// This method tests the Report method for the message 
        /// </summary>
        [TestMethod]
        public void TestReportMethod()
        {
            int x = 3;
            int y = 4;
            string direction = "South";
            Turtle.XAxis = x;
            Turtle.YAxis = y;
            Turtle.Direction = direction;
            string message = obj.Report();
            Assert.AreEqual("Turtle Position is : 3,4,South", message);

        }

        /// <summary>
        /// This method tests the process method with place command with non number value
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid placement values")]
        public void TestProcessMethodPlaceWithNonNumberinput()
        {
            string line = "Place A,        4   ,North";
            obj.ProcessLine(line, obj);
        }
    }
}
