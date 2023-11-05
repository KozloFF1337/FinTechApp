using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechApp
{
    internal class FinTech
    {
        public int id { get; set; }
        public double Value { get; set; }
        public string Column { get; set; }
        public string Row { get; set; }
        public FinTech() { }
        public FinTech( string column, string row, double value)
        {
            Value = value;
            Column = column;
            Row = row;
        }
    }
}
