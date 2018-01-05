using GOIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLife.APIModels.Request
{
    public class UpdateGOIGridCellRequest
    {
        public int totalRows { get; set; }
        public List<List<Cell>> gridCells { get; set; }
    }

    public class UpdateGOIGridCellModel {
        public UpdateGOIGridCellRequest gridData { get; set; }
    }
}