using GOIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOIData
{
    public interface IGOIAlg
    {
        /// <summary>
        /// Initialize goi grid with size
        /// </summary>
        /// <param name="size"></param>
        void SetGOISize(int size);
        /// <summary>
        /// Process grid state
        /// </summary>
        void ProcessGrid();

        /// <summary>
        /// Assign cell status to true
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool SetCellState(int x, int y);

        /// <summary>
        /// Get updated grid state
        /// </summary>
        /// <returns></returns>
        List<List<Cell>> GetUpdatedGrid();
    }
}
