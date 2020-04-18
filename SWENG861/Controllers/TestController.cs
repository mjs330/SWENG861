using SWENG861.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWENG861.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(string id = "index", string artist = null, string track = null)
        {
            var model = new SearchPageModel()
            {
                ArtistResults = SpotifyController.SearchArtist(artist),
                TrackResults = SpotifyController.SearchTrack(track)
            };
            return View("/Views/Test/" + id.ToLower() + ".cshtml", model);
        }
    }
}