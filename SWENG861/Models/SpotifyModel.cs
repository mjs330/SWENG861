using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;

namespace SWENG861.Models
{
    public class SpotifyClient
    {
        private static readonly string ClientID = "***REMOVED***";
        private static readonly string ClientSecret = "***REMOVED***";
        public Token Token = null;

        // Populate Token when the class is instantiated
        public SpotifyClient()
        {
            GetToken();
        }
        private async void GetToken()
        {
            Token = await (new CredentialsAuth(ClientID, ClientSecret)).GetToken();
        }
    }
}