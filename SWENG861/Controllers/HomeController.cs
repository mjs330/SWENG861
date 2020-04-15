using SWENG861.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWENG861.Controllers
{
    public class HomeController : Controller
    {
        #region Pages

        public ActionResult Index(string artist = null, string title = null)
        {
            var model = new SearchPageModel()
            {
                ArtistResults = SpotifyController.SearchArtist(artist),
                TrackResults  = SpotifyController.SearchTitle(title)
            };
            return View("/Views/Home/Index.cshtml", model);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult Artist(string id)
        {
            return View();
        }

        public ActionResult Title(string id)
        {
            return View();
        }

        #endregion


        #region Helper Methods

        // TODO

        #endregion
    }
}