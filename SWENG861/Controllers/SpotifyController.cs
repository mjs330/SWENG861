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
    public class SpotifyController
    {

        #region Search Methods

        public static List<ArtistDetails> SearchArtist(string id)
        {
            try
            {
                // Return null if null is passed
                if (string.IsNullOrEmpty(id))
                    return null;

                // Get and return search results
                return ConvertToArtistDetails(GetSpotifyWebAPIWithToken().SearchItemsEscaped(id, SearchType.Artist).Artists.Items);
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

        public static List<TrackDetails> SearchTitle(string id)
        {
            try
            {
                // Return null if null is passed
                if (string.IsNullOrEmpty(id))
                    return null;

                // Get and return search results
                return ConvertToTrackDetails(GetSpotifyWebAPIWithToken().SearchItemsEscaped(id, SearchType.Track).Tracks.Items);
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
        private static SpotifyWebAPI GetSpotifyWebAPIWithToken()
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
        /// Converts List<FullTrack> to List<TrackDetails>
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static List<TrackDetails> ConvertToTrackDetails(List<FullTrack> results)
        {
            try
            {
                // Return null if null is passed
                if (results == null)
                    return null;

                // Convert the results
                var convertedDetailss = new List<TrackDetails>();
                foreach (var result in results)
                {
                    convertedDetailss.Add(new TrackDetails
                    {
                        Id = result.Id,
                        Artists = ConvertToArtistDetails(result.Artists),
                        Title = result.Name,
                        Album = result.Album.Name,
                        ReleaseDate = result.Album.ReleaseDate
                    });
                }
                return convertedDetailss;
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }

        /// <summary>
        /// Converts List<FullArtist> to List<ArtistDetails> to return as search results
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static List<ArtistDetails> ConvertToArtistDetails(List<FullArtist> results)
        {
            try
            {
                // Return null if null is passed
                if (results == null)
                    return null;

                // Convert the results
                var convertedDetailss = new List<ArtistDetails>();
                foreach (var result in results)
                {
                    convertedDetailss.Add(new ArtistDetails
                    {
                        Id = result.Id,
                        Name = result.Name
                    });
                }
                return convertedDetailss;
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }

        /// <summary>
        /// Converts List<SimpleArtist> to List<ArtistDetails> to return as search results
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static List<ArtistDetails> ConvertToArtistDetails(List<SimpleArtist> results)
        {
            try
            {
                // Return null if null is passed
                if (results == null)
                    return null;

                // Convert the results
                var convertedDetailss = new List<ArtistDetails>();
                foreach (var result in results)
                {
                    convertedDetailss.Add(new ArtistDetails
                    {
                        Id = result.Id,
                        Name = result.Name
                    });
                }
                return convertedDetailss;
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
