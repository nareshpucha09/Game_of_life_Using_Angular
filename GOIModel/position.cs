using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOIModel
{
    public class Position
    {
        public Position(int xPos, int yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
}
