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
        public ActionResult Index(string artist = null, string title = null)
        {
            var model = new SearchPageModel()
            {
                ArtistResults = SpotifyController.SearchArtist(artist),
                TrackResults  = SpotifyController.SearchTrack(title)
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
            var model = new ArtistPageModel()
            {
                ArtistDetails = SpotifyController.GetArtistDetails(id)
            };
            return View("/Views/Home/Artist.cshtml", model);
        }

        public ActionResult Track(string id)
        {
            var model = new TrackPageModel()
            {
                TrackDetails = SpotifyController.GetTrackDetails(id)
            };
            return View("/Views/Home/Track.cshtml", model);
        }
    }
}