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
using System.Globalization;

namespace SWENG861.Controllers
{
    public class SpotifyController : ApiController
    {

        #region Search Methods

        [HttpGet]
        public List<ArtistResult> SearchArtist(string id)
        {
            try
            {
                // Get and return search results
                return ConvertToArtistResult(GetSpotifyWebAPIWithToken().SearchItemsEscaped(id, SearchType.Artist).Artists.Items);
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
        public List<TrackResult> SearchTitle(string id)
        {
            try
            {
                // Get and return search results
                return ConvertToTrackResult(GetSpotifyWebAPIWithToken().SearchItemsEscaped(id, SearchType.Track).Tracks.Items);
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

        #endregion


        #region Helper Methods

        /// <summary>
        /// Instantiate SpotifyWebAPI with a token
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Converts List<FullTrack> to List<TrackResult>
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private List<TrackResult> ConvertToTrackResult(List<FullTrack> results)
        {
            try
            {
                // Return null if null is passed
                if (results == null)
                    return null;

                // Convert the results
                var convertedResults = new List<TrackResult>();
                foreach (var result in results)
                {
                    convertedResults.Add(new TrackResult
                    {
                        Id = result.Id,
                        Artists = ConvertToArtistResult(result.Artists),
                        Title = result.Name,
                        Album = result.Album.Name,
                        ReleaseDate = result.Album.ReleaseDate
                    });
                }
                return convertedResults;
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }

        /// <summary>
        /// Converts List<FullArtist> to List<ArtistResult>
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private List<ArtistResult> ConvertToArtistResult(List<FullArtist> results)
        {
            try
            {
                // Return null if null is passed
                if (results == null)
                    return null;

                // Convert the results
                var convertedResults = new List<ArtistResult>();
                foreach (var result in results)
                {
                    convertedResults.Add(new ArtistResult
                    {
                        Id = result.Id,
                        Name = result.Name
                    });
                }
                return convertedResults;
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }

        /// <summary>
        /// Converts List<SimpleArtist> to List<ArtistResult>
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private List<ArtistResult> ConvertToArtistResult(List<SimpleArtist> results)
        {
            try
            {
                // Return null if null is passed
                if (results == null)
                    return null;

                // Convert the results
                var convertedResults = new List<ArtistResult>();
                foreach (var result in results)
                {
                    convertedResults.Add(new ArtistResult
                    {
                        Id = result.Id,
                        Name = result.Name
                    });
                }
                return convertedResults;
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }

        #endregion

    }
}
