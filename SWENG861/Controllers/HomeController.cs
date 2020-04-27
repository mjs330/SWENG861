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
        /// ActionResult for the home page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                return View("/Views/Home/Index.cshtml", new SearchPageModel());
            }
            catch (Exception Ex)
            {
                // Write error to the console and return a 500 error to the browser
                Console.WriteLine("Exception Occurred: " + Ex.Message);
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// ActionResult for the search page. Populates the page model with search results if artist or title parameters are passed.
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="title"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public ActionResult Search(string artist = null, string track = null, bool min = false)
        {
            try
            {
                // Ensure that track and artist are not empty and are not searched for concurrently
                if ((!string.IsNullOrEmpty(artist) && !string.IsNullOrEmpty(track))
                    || (string.IsNullOrEmpty(artist) && string.IsNullOrEmpty(track)))
                {
                    return View("/Views/Home/Index.cshtml", new SearchPageModel());
                }
                else
                {
                    // Build the search result model if an artist or track is specified
                    var model = new SearchPageModel();
                    ViewBag.Query = string.Empty;
                    if (!string.IsNullOrEmpty(artist))
                    {
                        model.ArtistResults = SpotifyController.SearchArtist(artist, min);
                        ViewBag.Query = artist;
                    }
                    else if (!string.IsNullOrEmpty(track))
                    {
                        model.TrackResults = SpotifyController.SearchTrack(track);
                        ViewBag.Query = track;
                    }
                    return View("/Views/Home/Search.cshtml", model);
                }
            }
            catch (Exception Ex)
            {
                // Write error to the console and return a 500 error to the browser
                Console.WriteLine("Exception Occurred: " + Ex.Message);
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        public ActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception Ex)
            {
                // Write error to the console and return a 500 error to the browser
                Console.WriteLine("Exception Occurred: " + Ex.Message);
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }


    }
}