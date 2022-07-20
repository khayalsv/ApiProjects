using SpotifyWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyWebApi.Services
{
    public interface ISpotify
    {
        Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken);
    }
}
