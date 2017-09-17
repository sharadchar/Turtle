using System.Collections.Generic;
using System.IO;

namespace TurtleMovementApp
{
    public class TurtleCommands
    {
        /// <summary>
        /// This method reads the resource from the assembly and returns a list of strings commands.
        /// </summary>
        /// <param name="resourceName">Name of resource where to get the  commands</param>
        /// <returns></returns>
        public List<string> GetCommands(Stream stream)
        {
            List<string> moves = new List<string>();
            
            using (stream)
            using (StreamReader reader = new StreamReader(stream))
            {
                ReadFromFile(moves, reader);
            }

            return moves;
        }

        /// <summary>
        /// This method reads the file and add the comments to the list of comments
        /// </summary>
        /// <param name="lines">List of strings</param>
        /// <param name="reader">File reader streem</param>
        private void ReadFromFile(List<string> lines, StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //skip all the lines before first place statement
                if (lines.Count == 0 && (!line.ToLower().Contains("place")))
                    continue;
                else if (line.Length == 0)//skip all the blank lines
                    continue;
                else
                    lines.Add(line.Trim());//trim the space and add the line to the command list
            }
        }
    }
}
