using GOIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOIData
{
    public class GOIAlg : IGOIAlg
    {
        private bool[,] currentState;
        private bool[,] nextState;
        public int Size { get; set; }

        public void SetGOISize(int size)
        {
            this.Size = size;
            currentState = new bool[size, size];
            nextState = new bool[size, size];
        }

        public bool this[int x, int y]
        {
            get { return this.currentState[x, y]; }
            set { this.currentState[x, y] = value; }
        }
        /// <summary>
        /// Assign cell status to true
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool SetCellState(int x, int y)
        {
            return this.currentState[x, y] = true;
        }

        /// <summary>
        /// Process grid state
        /// </summary>
        public void ProcessGrid()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    // Check the cell's current state, and count its living neighbors.
                    bool living = this[i, j];
                    int count = GetLivingNeighbors(i, j);
                    bool result = false;

                    // Apply the rules and set the next state.
                    if (living && count < 2)
                        result = false;

                    if (living && (count == 2 || count == 3))
                        result = true;

                    if (living && count > 3)
                        result = false;

                    if (!living && count == 3)
                        result = true;


                    nextState[i, j] = result;
                }
            }
        }

        private int GetLivingNeighbors(int x, int y)
        {
            int count = 0;

            // Check cell on the right.
            if (x != Size - 1)
                if (this[x + 1, y])
                    count++;

            // Check cell on the bottom right.
            if (x != Size - 1 && y != Size - 1)
                if (this[x + 1, y + 1])
                    count++;

            // Check cell on the bottom.
            if (y != Size - 1)
                if (this[x, y + 1])
                    count++;

            // Check cell on the bottom left.
            if (x != 0 && y != Size - 1)
                if (this[x - 1, y + 1])
                    count++;

            // Check cell on the left.
            if (x != 0)
                if (this[x - 1, y])
                    count++;

            // Check cell on the top left.
            if (x != 0 && y != 0)
                if (this[x - 1, y - 1])
                    count++;

            // Check cell on the top.
            if (y != 0)
                if (this[x, y - 1])
                    count++;

            // Check cell on the top right.
            if (x != Size - 1 && y != 0)
                if (this[x + 1, y - 1])
                    count++;

            return count;
        }

        /// <summary>
        /// Get updated grid state
        /// </summary>
        /// <returns></returns>
        public List<List<Cell>> GetUpdatedGrid()
        {
            List<List<Cell>> gridCells = new List<List<Cell>>();
            for (int y = 0; y < this.Size; y++)
            {
                List<Cell> rowCells = new List<Cell>();
                for (int x = 0; x < this.Size; x++)
                {
                    Cell gCell = new Cell(y, x, nextState[y, x]);
                    rowCells.Add(gCell);
                }
                gridCells.Add(rowCells);
            }
            return gridCells;

        }
    }
}
