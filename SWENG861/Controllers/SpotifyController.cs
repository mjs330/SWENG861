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

        /// <summary>
        /// Searches for an artist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Searches for a track
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<TrackDetails> SearchTrack(string id)
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


        #region Detail Methods

        /// <summary>
        /// Gets artist details by the artist's Spotify ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ArtistDetails GetArtistDetails(string id)
        {
            try
            {
                // Return null if null is passed
                if (string.IsNullOrEmpty(id))
                    return null;

                // Get and return artist details with related artists and top tracks
                var details = ConvertToArtistDetails(GetSpotifyWebAPIWithToken().GetArtist(id));
                details.RelatedArtists = ConvertToArtistDetails(GetSpotifyWebAPIWithToken().GetRelatedArtists(id).Artists);
                details.TopTracks = ConvertToTrackDetails(GetSpotifyWebAPIWithToken().GetArtistsTopTracks(id, "US").Tracks);
                return details;
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

        /// <summary>
        /// Gets track details by the track's Spotify ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TrackDetails GetTrackDetails(string id)
        {
            try
            {
                // Return null if null is passed
                if (string.IsNullOrEmpty(id))
                    return null;

                // Get and return artist details
                return ConvertToTrackDetails(GetSpotifyWebAPIWithToken().GetTrack(id));
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
        /// Instantiates SpotifyWebAPI with a token
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
        /// Converts FullTrack to TrackDetails
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static TrackDetails ConvertToTrackDetails(FullTrack result)
        {
            try
            {
                // Return null if null is passed
                if (result == null)
                    return null;

                // Convert the results
                return new TrackDetails
                {
                    Id = result.Id,
                    Artists = ConvertToArtistDetails(result.Artists),
                    Title = result.Name,
                    Album = result.Album.Name,
                    ReleaseDate = result.Album?.ReleaseDate,
                    ImageUrl = result.Album?.Images?.Select(x => x.Url).FirstOrDefault(),
                    Explicit = result.Explicit
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
                var convertedDetails = new List<TrackDetails>();
                foreach (var result in results)
                {
                    convertedDetails.Add(ConvertToTrackDetails(result));
                }
                return convertedDetails;
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }

        /// <summary>
        /// Converts FullArtist to ArtistDetails
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static ArtistDetails ConvertToArtistDetails(FullArtist result)
        {
            try
            {
                // Return null if null is passed
                if (result == null)
                    return null;

                // Convert and return the results
                return new ArtistDetails
                {
                    Id = result.Id,
                    Name = result.Name,
                    Genres = result.Genres,
                    ImageUrl = result.Images?.Select(x => x.Url).FirstOrDefault()                
                };
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }

        /// <summary>
        /// Converts List<FullArtist> to List<ArtistDetails>
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
                var convertedDetails = new List<ArtistDetails>();
                foreach (var result in results)
                {
                    convertedDetails.Add(ConvertToArtistDetails(result));
                }
                return convertedDetails;
            }
            catch (Exception Ex)
            {
                // Throw a new exception to bubble up
                throw new Exception("Exception Occurred: " + Ex.Message);
            }
        }

        /// <summary>
        /// Converts List<SimpleArtist> to List<ArtistDetails>
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
