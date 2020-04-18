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
        public ActionResult Index(string artist = null, string track = null)
        {
            try
            {
                var model = new SearchPageModel();
                ViewBag.Query = string.Empty;

                // Ensure that track and artist is not searched for concurrently
                if (!string.IsNullOrEmpty(artist) && !string.IsNullOrEmpty(track))
                {
                    return View("/Views/Home/Index.cshtml", model);
                } 
                else
                {
                    // Build the search result model if artist or track is specified
                    if (!string.IsNullOrEmpty(artist))
                    {
                        model.ArtistResults = SpotifyController.SearchArtist(artist);
                        ViewBag.Query = artist;
                    }
                    else if (!string.IsNullOrEmpty(track))
                    {
                        model.TrackResults = SpotifyController.SearchTrack(track);
                        ViewBag.Query = track;
                    }
                    return View("/Views/Home/Index.cshtml", model);
                }
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