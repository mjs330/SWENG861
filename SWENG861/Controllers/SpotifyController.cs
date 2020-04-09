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

namespace SWENG861.Controllers
{
    public class SpotifyController : ApiController
    {
        [HttpGet]
        public Paging<FullArtist> SearchArtist(string id)
        {
            try
            {
                // Initialize Spotify WebAPI
                var creds = new SpotifyCredentials();
                var api = new SpotifyWebAPI()
                {
                    AccessToken = creds.Token.AccessToken,
                    TokenType = creds.Token.TokenType
                };

                // Get and return search results
                return (api.SearchItemsEscaped(id, SearchType.Artist)).Artists;
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
        public Paging<FullTrack> SearchTitle(string id)
        {
            try
            {
            
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


    }
}
