using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameOfLife.Controllers
{
    public class GameOfLifeController : Controller
    {
        //// GET: GameOfLife
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Sample()
        //{
        //    return View();
        //}

        public ActionResult NewSample()
        {
            return View();
        }
    }
}