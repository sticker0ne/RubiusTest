using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace musicServiceCore.Repositories
{
    public interface IMusicRepository
    {
        JObject GetAll(Guid userId);
        void SetDbContext(DbContext dbContext);
        JObject GetMusicians();
        JObject GetAlbums(long musicianId);
        JObject GetTracks(Guid userId, long albumId);
        JObject GetFavoriteTracks(Guid userId);
        JObject CreateUser(string name, bool male = true);
        JObject GetTrack(Guid userId, long trackId);
        JObject AddTrackToFavorite(Guid userId, long trackId);
        JObject RemoveTrackFromFavorite(Guid userId, long trackId);
        JObject AddTrackToListened(Guid userId, long trackId);
        JObject SetLikeStatus(Guid userId, long trackId, string status);
    }
}
