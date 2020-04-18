using SWENG861.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SWENG861.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// ActionResult for the search page. Populates the page model with search results if artist or title parameters are passed
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public ActionResult Index(string artist = null, string title = null)
        {
            try
            {
                var model = new SearchPageModel()
                {
                    ArtistResults = SpotifyController.SearchArtist(artist),
                    TrackResults = SpotifyController.SearchTrack(title)
                };
                return View("/Views/Home/Index.cshtml", model);
            }
            catch (Exception Ex)
            {
                // Write error to the log and return a 500 error to the browser
                Console.WriteLine("Exception Occurred: " + Ex.Message);
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// ActionResult for the artist details page. Populates the page model with artist details based on the Spotify artist ID that's passed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Artist(string id)
        {
            try
            {
                var model = new ArtistPageModel()
                {
                    ArtistDetails = SpotifyController.GetArtistDetails(id)
                };
                return View("/Views/Home/Artist.cshtml", model);
            }
            catch (Exception Ex)
            {
                // Write error to the log and return a 500 error to the browser
                Console.WriteLine("Exception Occurred: " + Ex.Message);
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// ActionResult for the track details page. Populates the page model with artist details based on the Spotify track ID that's passed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Track(string id)
        {
            try
            {
                var model = new TrackPageModel()
                {
                    TrackDetails = SpotifyController.GetTrackDetails(id)
                };
                return View("/Views/Home/Track.cshtml", model);
            }
            catch (Exception Ex)
            {
                // Write error to the log and return a 500 error to the browser
                Console.WriteLine("Exception Occurred: " + Ex.Message);
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}