﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Stores artist details
    /// </summary>
    public class ArtistDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        // TODO add more for artist page information
    }

    /// <summary>
    /// Stores track details
    /// </summary>
    public class TrackDetails
    {
        public string Id { get; set; }
        public List<ArtistDetails> Artists { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string ReleaseDate { get; set; }
        // TODO add more for track page information
    }

    public class SearchPageModel
    {
        public List<ArtistDetails> ArtistResults = null;
        public List<TrackDetails> TrackResults = null;
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