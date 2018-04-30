using System;
using musicServiceCore.Models;
using musicServiceCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace musicServiceCore.Controllers
{
    [Route("api")]
    public class ValuesController : Controller
    {
        public IMusicRepository MusicRepository { get; set; }
        IMusicRepository mscRep;

        public ValuesController(MusicContext db, IMusicRepository musicRepository)
        {
            mscRep = musicRepository;
            mscRep.SetDbContext(db);
        }
        // GET api/values
        [HttpGet]
        [Route("GetAll")]
        public string GetAll(Guid userId)
        {
            return JsonConvert.SerializeObject(mscRep.GetAll(userId), Formatting.Indented);
        }

        [HttpGet]
        [Route("GetTracks")]
        public string GetTracks(Guid userId, long albumId)
        {
            return JsonConvert.SerializeObject(mscRep.GetTracks(userId, albumId), Formatting.Indented);
        }

        [HttpGet]
        [Route("GetFavoriteTracks")]
        public string GetFavoriteTracks(Guid userId)
        {
            return JsonConvert.SerializeObject(mscRep.GetFavoriteTracks(userId), Formatting.Indented);
        }

        [HttpGet]
        [Route("GetAlbums")]
        public string GetAlbums(long musicianId)
        {
            return JsonConvert.SerializeObject(mscRep.GetAlbums(musicianId), Formatting.Indented);
        }

        [HttpGet]
        [Route("GetMusicians")]
        public string GetMusicians()
        {
            return JsonConvert.SerializeObject(mscRep.GetMusicians(), Formatting.Indented);
        }

        [HttpGet]
        [Route("CreateUser")]
        public string CreateUser(string name, string sex)
        {
            var male = sex == "male";
            return JsonConvert.SerializeObject(mscRep.CreateUser(name, male), Formatting.Indented);
        }

        [HttpGet]
        [Route("GetTrack")]
        public string GetTrack(Guid userId, long trackId)
        {
            return JsonConvert.SerializeObject(mscRep.GetTrack(userId, trackId), Formatting.Indented);
        }

        [HttpGet]
        [Route("AddTrackToFavorite")]
        public string AddTrackToFavorite(Guid userId, long trackId)
        {
            return JsonConvert.SerializeObject(mscRep.AddTrackToFavorite(userId, trackId), 
                Formatting.Indented);
        }

        [HttpGet]
        [Route("RemoveTrackFromFavorite")]
        public string RemoveTrackFromFavorite(Guid userId, long trackId)
        {
            return JsonConvert.SerializeObject(mscRep.RemoveTrackFromFavorite(userId, trackId),
                Formatting.Indented);
        }

        [HttpGet]
        [Route("AddTrackToListened")]
        public string AddTrackToListened(Guid userId, long trackId)
        {
            return JsonConvert.SerializeObject(mscRep.AddTrackToListened(userId, trackId),
                Formatting.Indented);
        }

        [HttpGet]
        [Route("SetLikeStatus")]
        public string SetLikeStatus(Guid userId, long trackId, string status)
        {
            return JsonConvert.SerializeObject(mscRep.SetLikeStatus(userId, trackId, status),
                Formatting.Indented);
        }
    }
}
