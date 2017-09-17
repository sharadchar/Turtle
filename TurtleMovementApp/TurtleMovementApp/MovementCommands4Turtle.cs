using System;
using TurtleMovementApp.Model;

namespace TurtleMovementApp
{
    public class MovementCommands4Turtle
    {
        private TableDimension tabdim;
        
        public MovementCommands4Turtle(TableDimension dim)
        {
            tabdim = dim;
        }

        /// <summary>
        /// This method is used to Place the Turtle at a specific location on the board
        /// </summary>
        /// <param name="xaxis">integer value representing the xaxis location</param>
        /// <param name="yaxis">integer value representing the yaxis location</param>
        /// <param name="direction">String value representing the faceing direction</param>
        public void Place(int xaxis, int yaxis, string direction)
        {
            try
            {
                if (xaxis > (tabdim.XUnits-1) || xaxis < 0)
                    throw new Exception("Placement Error: XAxis should be greater than or equal to 0 and less than " + tabdim.XUnits);
                if (yaxis > (tabdim.YUnits-1) || yaxis < 0)
                    throw new Exception("Placement Error: YAxis should be greater than or equal to 0 and less than " + tabdim.YUnits);
                if ((direction != DirectionEnum.East.ToString()) && (direction != DirectionEnum.West.ToString()) &&
                    direction != DirectionEnum.North.ToString() && direction != DirectionEnum.South.ToString())
                    throw new Exception("Placement Error: Invalid Direction");

                Turtle.XAxis = xaxis;
                Turtle.YAxis = yaxis;
                Turtle.Direction = direction;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Method used to move the turtle in the specific direction 
        /// </summary>
        /// <param name="turtleObj">Takes the turtle object</param>
        public void Move()
        {
            try
            {
                if ((Turtle.XAxis >= (tabdim.XUnits-1) && Turtle.Direction == DirectionEnum.East.ToString()) ||
                    (Turtle.XAxis <= 0 && Turtle.Direction == DirectionEnum.West.ToString()))
                    return;
                if ((Turtle.YAxis >= (tabdim.YUnits-1) && Turtle.Direction == DirectionEnum.North.ToString()) ||
                    (Turtle.YAxis <= 0 && Turtle.Direction == DirectionEnum.South.ToString()))
                    return;

                switch (Turtle.Direction.ToString())
                {
                    case "East":
                        Turtle.XAxis++;
                        break;
                    case "West":
                        Turtle.XAxis--;
                        break;
                    case "North":
                        Turtle.YAxis++;
                        break;
                    case "South":
                        Turtle.YAxis--;
                        break;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method is used to rotate the direction of the turtle to 90 degrees left
        /// </summary>
        /// <param name="turtleObj">Takes the turtle object</param>
        public void Left()
        {
            try
            {
                switch (Turtle.Direction.ToString())
                {
                    case "East":
                        Turtle.Direction = DirectionEnum.North.ToString();
                        break;
                    case "West":
                        Turtle.Direction = DirectionEnum.South.ToString();
                        break;
                    case "North":
                        Turtle.Direction = DirectionEnum.West.ToString();
                        break;
                    case "South":
                        Turtle.Direction = DirectionEnum.East.ToString();
                        break;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method is used to rotate the direction of the turtle to 90 degrees right
        /// </summary>
        /// <param name="turtleObj">Takes the turtle object</param>
        public void Right()
        {
            try
            {
                switch (Turtle.Direction.ToString())
                {
                    case "East":
                        Turtle.Direction = DirectionEnum.South.ToString();
                        break;
                    case "West":
                        Turtle.Direction = DirectionEnum.North.ToString();
                        break;
                    case "North":
                        Turtle.Direction = DirectionEnum.East.ToString();
                        break;
                    case "South":
                        Turtle.Direction = DirectionEnum.West.ToString();
                        break;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method is used to get the position of the turtle
        /// </summary>
        /// <param name="turtleObj">Takes the turtle object</param>
        public string Report()
        {
            try
            {
                return "Turtle Position is : " + Turtle.XAxis.ToString() + "," + Turtle.YAxis.ToString() + "," + Turtle.Direction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public void ProcessLine(string line, MovementCommands4Turtle turtleCommandObj)
        {
            try
            {
                //string position = "";
                string templine = "";
                if (line.ToLower().Contains("place"))
                {
                    templine = line.Substring(5, line.Length - 5);
                    string[] temparr = templine.Split(',');
                    int x=0;
                    int y=0;
                    if (!int.TryParse(temparr[0].Trim(), out x) || !int.TryParse(temparr[1].Trim(), out y))
                        throw new Exception("Invalid placement values");


                    turtleCommandObj.Place(int.Parse(temparr[0].Trim()), int.Parse(temparr[1].Trim()), temparr[2].Trim());
                }

                if (line.ToLower().Contains("move"))
                {
                    turtleCommandObj.Move();
                }

                if (line.ToLower().Contains("left"))
                {
                    turtleCommandObj.Left();
                }

                if (line.ToLower().Contains("right"))
                {
                    turtleCommandObj.Right();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
