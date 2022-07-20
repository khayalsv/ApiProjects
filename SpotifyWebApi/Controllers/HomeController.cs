using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SpotifyWebApi.Models;
using SpotifyWebApi.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyWebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAccount _spotifyAccount;
        private readonly IConfiguration _configuration;
        private readonly ISpotify _spotify;

        public HomeController(ISpotifyAccount spotifyAccount, IConfiguration configuration, ISpotify spotify)
        {
            _spotifyAccount = spotifyAccount;
            _configuration = configuration;
            _spotify = spotify;
        }

        public async Task<IActionResult> Index()
        {
            var newReleases = await GetReleases();

            return View(newReleases);
        }

        private async Task<IEnumerable<Release>> GetReleases()
        {
            try
            {
                var token = await _spotifyAccount.GetToken(
                    _configuration["Spotify:ClientId"],
                    _configuration["Spotify:ClientSecret"]);

                var newReleases = await _spotify.GetNewReleases("US", 20, token);

                return newReleases;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Release>();
            }
        }


    }
}
