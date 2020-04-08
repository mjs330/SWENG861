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
                // Initialize Spotify Client
                var client = new SpotifyClient();

                // Check if client token was populated
                if (client.Token == null)
                {
                    throw new Exception("Spotify client token is null.");
                }

                // Initialize Spotify WebAPI
                var api = new SpotifyWebAPI()
                {
                    AccessToken = client.Token.AccessToken,
                    TokenType = client.Token.TokenType
                };

                // Get and return search results
                return (api.SearchItemsEscaped(id, SearchType.Artist)).Artists;
            }
            catch (Exception Ex)
            {
                // Write error to the console and throw an exception to return a 500 error
                var message = "Exception Occurred: " + Ex.Message;
                Console.WriteLine(message);
                throw new Exception(message);
            }
        }

        [HttpGet]
        public Paging<FullTrack> SearchTitle(string id)
        {
            try
            {
                // Initialize Spotify Client
                var client = new SpotifyClient();

                // Check if client token was populated
                if (client.Token == null)
                {
                    throw new Exception("Spotify client token is null.");
                }

                // Initialize Spotify WebAPI
                var api = new SpotifyWebAPI()
                {
                    AccessToken = client.Token.AccessToken,
                    TokenType = client.Token.TokenType
                };

                // Get and return search results
                return (api.SearchItemsEscaped(id, SearchType.Track)).Tracks;
            }
            catch (Exception Ex)
            {
                // Write error to the console and throw an exception to return a 500 error
                var message = "Exception Occurred: " + Ex.Message;
                Console.WriteLine(message);
                throw new Exception(message);
            }
        }
    }
}
