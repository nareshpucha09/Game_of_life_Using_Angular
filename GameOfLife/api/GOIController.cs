using GameOfLife.APIModels.Request;
using GOIData;
using GOIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameOfLife.api
{
    public class GOIController : ApiController
    {
        private IGOIAlg goiAlg;
        public GOIController(IGOIAlg _goiAlg)
        {
            goiAlg = _goiAlg;
        }

        [Route("api/initializeGOIGrid/{totalRows}"), HttpGet]
        public HttpResponseMessage InitializeGOIGrid(int totalRows)
        {
            goiAlg.SetGOISize(totalRows);
            goiAlg.ProcessGrid();
            return this.Request.CreateResponse(HttpStatusCode.OK, new { gridCells = goiAlg.GetUpdatedGrid() });
        }

        [Route("api/updateGOIGrid"), HttpPost]
        public HttpResponseMessage InitializeGOIGrid(UpdateGOIGridCellModel req)
        {
            goiAlg.SetGOISize(req.gridData.totalRows);
            UpdateGOIGridCellRequest request = req.gridData;
            foreach (List<Cell> rC in request.gridCells)
            {
                foreach (Cell c in rC.Where(a => a.isAlive).ToList())
                {
                    goiAlg.SetCellState(c.position.x, c.position.y);
                }
            }
            goiAlg.ProcessGrid();
            return this.Request.CreateResponse(HttpStatusCode.OK, new { gridCells = goiAlg.GetUpdatedGrid() });
        }
    }
}
