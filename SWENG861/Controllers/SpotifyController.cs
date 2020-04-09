using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SWENG861.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Newtonsoft.Json;

namespace SWENG861.Controllers
{
    public class SpotifyController : ApiController
    {
        [HttpGet]
        public object SearchArtist(string id)
        {
            try
            {
                // Get and return search results
                return JsonConvert.SerializeObject(GetSpotifyWebAPIWithToken().SearchItemsEscaped(id, SearchType.Artist).Artists);
            }
            catch (Exception Ex)
            {
                // Write error to the console
                var message = "Exception Occurred: " + Ex.Message;
                Console.WriteLine(message);
            }

            // Return null by default
            return null;
        }

        [HttpGet]
        public object SearchTitle(string id)
        {
            try
            {
                // Get and return search results
                return JsonConvert.SerializeObject(GetSpotifyWebAPIWithToken().SearchItemsEscaped(id, SearchType.Track).Tracks);
            }
            catch (Exception Ex)
            {
                // Write error to the console
                var message = "Exception Occurred: " + Ex.Message;
                Console.WriteLine(message);
            }

            // Return null by default
            return null;
        }

        private SpotifyWebAPI GetSpotifyWebAPIWithToken()
        {
            try
            {
                // Initialize Spotify WebAPI
                var creds = new SpotifyCredentials();
                return new SpotifyWebAPI()
                {
                    AccessToken = creds.Token.AccessToken,
                    TokenType = creds.Token.TokenType
                };
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }
    }
}
