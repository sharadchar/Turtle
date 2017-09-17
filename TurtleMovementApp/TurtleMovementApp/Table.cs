using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleMovementApp.Model;

namespace TurtleMovementApp
{
    public static class Table
    {
        public static TableDimension GetTableDimension()
        {
            int xAxis = Convert.ToInt32(ConfigurationManager.AppSettings["xUnits"].ToString());
            int yAxis = Convert.ToInt32(ConfigurationManager.AppSettings["yUnits"].ToString());

            TableDimension dim = new TableDimension();
            dim.XUnits = xAxis;
            dim.YUnits = yAxis;

            return dim;
        }
    }
}
