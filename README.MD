## About

This ASP.NET MVC web application is a project for SWENG861 taken at Penn State during the Spring 2020 semester.

It provides a front end for searching the Spotify Web API by artist or track and displaying the top results. It accomplishes this through the use of the SpotifyAPI.Web .NET library and a ColorLib site design.

## Usage

Open the web.config file and fill in the following with your [Spotify Web API](https://developer.spotify.com/documentation/web-api/) ClientID and ClientSecret.

```xml
<appSettings>
	<add key="ClientID" value="" />
	<add key="ClientSecret" value="" />
</appSettings>
```

Open the SWENG861.sln file in [Visual Studio](https://visualstudio.microsoft.com/vs/) (preferably 2019) and click on the green run button at the top of the screen.

Once the web site starts, enter a search value and click search. Track and artist search may be toggled by clicking on the arrow on the right of the screen.

By default, full artist and track search results are retrieved. If any lag is experienced when retrieving full artist results, the following setting can be used to switch to minimum artist results:

```xml
<appSettings>
	<add key="GetMinimumArtistResults" value="true" />
</appSettings>
```

Search results contain links to Spotify, Apple App Store, and Google Play. The link to Spotify is a direct link to the artist or track based on its Spotify ID while the links to Apple App Store and Google Play conduct searches on those platforms for the artist or track.

## Credits

* [ASP.NET MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)

* [Bootstrap](https://getbootstrap.com/)

* [ColorLib](https://colorlib.com/wp/template/music-2/)

* [jQuery](https://jquery.com/)

* [jQuery Validation](https://jqueryvalidation.org/)

* [Spotify Web API](https://developer.spotify.com/documentation/web-api/)

* [SpotifyAPI.Web](https://www.nuget.org/packages/SpotifyAPI.Web/5.1.0)
