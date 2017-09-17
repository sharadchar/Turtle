using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TurtleMovementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> moves = null;

                TurtleCommands turCommands = new TurtleCommands();
                var resourceName = "TurtleMovementApp.Files.TurtleMovementCommands.txt";

                var assembly = Assembly.GetExecutingAssembly();
                Stream stream = assembly.GetManifestResourceStream(resourceName);

                moves = turCommands.GetCommands(stream);

                MovementCommands4Turtle turtleCommandObj = new MovementCommands4Turtle(Table.GetTableDimension());          
                

                string position = "";
                foreach (string line in moves)
                {
                    if (!line.ToLower().Contains("report"))
                        turtleCommandObj.ProcessLine(line, turtleCommandObj);
                    else
                    {
                        position = turtleCommandObj.Report();
                        Console.WriteLine(position);
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}
