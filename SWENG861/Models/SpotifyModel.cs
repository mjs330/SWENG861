using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web.Models;

namespace SWENG861.Models
{
    /// <summary>
    /// Abstract class for details
    /// </summary>
    public abstract class Details
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
    }

    /// <summary>
    /// Stores artist details
    /// </summary>
    public class ArtistDetails : Details
    {
        public string Name { get; set; }
        public List<string> Genres { get; set; }
        public List<ArtistDetails> RelatedArtists { get; set; }
        public List<TrackDetails> TopTracks { get; set; }
    }

    /// <summary>
    /// Stores track details
    /// </summary>
    public class TrackDetails : Details
    {
        public List<ArtistDetails> Artists { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string ReleaseDate { get; set; }
        public bool Explicit { get; set; }
    }

    /// <summary>
    /// Stores search results for the search page
    /// </summary>
    public class SearchPageModel
    {
        public List<ArtistDetails> ArtistResults = null;
        public List<TrackDetails> TrackResults = null;
        public bool GetMinimumArtistResults = ConfigurationManager.AppSettings["GetMinimumArtistResults"] != null ? bool.Parse(ConfigurationManager.AppSettings["GetMinimumArtistResults"]) : false;
    }

    /// <summary>
    /// Stores search results for the artist page
    /// </summary>
    public class ArtistPageModel
    {
        public ArtistDetails ArtistDetails = null;
    }

    /// <summary>
    /// Stores search results for the track page
    /// </summary>
    public class TrackPageModel
    {
        public TrackDetails TrackDetails = null;
    }

    /// <summary>
    /// Generates a Spotify token on instantiation
    /// </summary>
    public class SpotifyCredentials
    {
        // Store Spotify client ID and client secret
        private static readonly string ClientID = "***REMOVED***";
        private static readonly string ClientSecret = "***REMOVED***";

        public Token Token = null;

        // Get Spotify token when class is instantiated
        public SpotifyCredentials()
        {
            try
            {
                // Make call to Spotify for authorization
                var webClient = new WebClient();
                var postparams = new NameValueCollection
                {
                    { "grant_type", "client_credentials" }
                };
                webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes($"{ClientID}:{ClientSecret}")));
                var TokenJObject = JObject.Parse(Encoding.UTF8.GetString(webClient.UploadValues("https://accounts.spotify.com/api/token", postparams)));
                Token = new Token
                {
                    AccessToken = TokenJObject["access_token"].Value<string>(),
                    TokenType = TokenJObject["token_type"].Value<string>(),
                    ExpiresIn = TokenJObject["expires_in"].Value<double>(),
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