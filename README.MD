## About

This ASP.NET MVC web application is a project for SWENG837 taken at Penn State during the Spring 2020 semester.

It provides a front end for searching the Spotify Web API by artist or track and displaying the top results. It accomplishes this through the use of the SpotifyAPI.Web .NET library and a ColorLib site design.

## Usage

Open the SWENG861.sln file in [Visual Studio](https://visualstudio.microsoft.com/vs/) (preferably 2019) and click on the green run button at the top of the screen.

Once the web site starts, enter a search value and click search. Track and artist search may be toggled by clicking on the arrow on the right of the screen.

Use the following setting within <appSettings> in web.config to toggle whether minimum or full artist search results are retrieved. Full track search results are always retrieved.

```xml
<appSettings>
	<add key="GetMinimumArtistResults" value="false" />
</appSettings>
```

## Credits

* [ASP.NET MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)

* [Bootstrap](https://getbootstrap.com/)

* [ColorLib](https://colorlib.com/wp/template/music-2/)

* [jQuery](https://jquery.com/)

* [jQuery Validation](https://jqueryvalidation.org/)

* [Spotify Web API](https://developer.spotify.com/documentation/web-api/)

* [SpotifyAPI.Web](https://www.nuget.org/packages/SpotifyAPI.Web/5.1.0)
