using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOIModel
{
    public class Cell
    {
        public Position position { get; set; }
        public bool isAlive { get; set; }
        public Cell(int xPos,int yPos, bool isAlive)
        {
            position = new Position(xPos, yPos);
            this.isAlive = isAlive;
        }
    }
}
