using System;
using System.Collections.Generic;
using System.Linq;
using musicServiceCore.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace musicServiceCore.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private MusicContext _db;

        public void SetDbContext(DbContext dbContext)
        {
            _db = dbContext as MusicContext;
        }

        public JObject GetAll(Guid userId)
        {
            var genres = _db.Genres.ToList();
            var albums = _db.Albums.ToList();
            var tracks = _db.Tracks.ToList();
            var usrListened = _db.UserListened.ToList();
            var usrFavorite = _db.UserFavorite.ToList();
            var musicians = _db.Musicians.ToList();
            var usersLikes = _db.UsersLikes.ToList();

            var result = new JObject();
            var jMusicians = new JArray();

            foreach (var musician in musicians)
            {
                var jMusician = ModelJsonConverter.GetJMusician(musician);
                var jAlbums = new JArray();
                var jGenres = new JArray();
                foreach (var genre in genres.FindAll(g => g.Id == musician.Id))
                    jGenres.Add(new JObject { ["id"] = genre.Id, ["name"] = genre.Name });

                foreach (var album in albums.FindAll(a => a.MusicianId == musician.Id))
                {
                    var jAlbum = ModelJsonConverter.GetJAlbum(album);
                    var jTracks = new JArray();
                    foreach (var track in tracks.FindAll(t => t.AlbumId == album.Id))
                    {
                        var jTrack = ModelJsonConverter.GetTrack(track);
                        jTrack["likeStatus"] = "none";
                        var rating = 0;
                        foreach (var usersLike in usersLikes.FindAll(ul => ul.TrackId == track.Id))
                        {
                            if (usersLike.UserId == userId)
                                if (usersLike.IsLike)
                                    jTrack["likeStatus"] = "liked";
                                else
                                    jTrack["likeStatus"] = "disliked";

                            if (usersLike.IsLike)
                                rating++;
                            else
                                rating--;
                        }

                        jTrack["rating"] = rating;
                        jTrack["isFavorite"] = usrFavorite.FirstOrDefault(uf => uf.UserId == userId
                                                                                && uf.TrackId == track.Id)
                                               != null;
                        jTrack["isListened"] = usrListened.FirstOrDefault(ul => ul.UserId == userId
                                                                                && ul.TrackId == track.Id)
                                               != null;
                        jTracks.Add(jTrack);

                    }

                    jAlbum["tracks"] = jTracks;
                    jAlbums.Add(jAlbum);
                }

                jMusician["genres"] = jGenres;
                jMusician["album"] = jAlbums;
                jMusicians.Add(jMusician);
            }

            result["mucisians"] = jMusicians;
            return result;
        }

        public JObject GetMusicians()
        {
            var musicians = _db.Musicians.ToList();
            var result = new JObject();
            var jMusicians = new JArray();
            foreach (var musician in musicians)
            {
                var jMusician = ModelJsonConverter.GetJMusician(musician);
                jMusicians.Add(jMusician);
            }

            result["musicians"] = jMusicians;
            return result;
        }

        public JObject GetAlbums(long musicianId)
        {
            var albums = _db.Albums.Where(a => a.MusicianId == musicianId).ToList();
            var result = new JObject();
            var jAlbums = new JArray();
            foreach (var album in albums)
            {
                var jAlbum = ModelJsonConverter.GetJAlbum(album);
                jAlbums.Add(jAlbum);
            }

            result["albums"] = jAlbums;
            return result;
        }

        public JObject GetTracks(Guid userId, long albumId)
        {
            var result = new JObject();
            var jTracks = new JArray();
            var tracks = _db.Tracks.Where(t => t.AlbumId == albumId).ToList();

            foreach (var track in tracks)
            {
                var usersLikes = _db.UsersLikes.Where(ul => ul.TrackId == track.Id);
                var userFavorite = _db.UserFavorite.Where(uf => uf.TrackId == track.Id
                                                                && uf.UserId == userId).ToList();
                var userListened = _db.UserListened.Where(ul => ul.TrackId == track.Id
                                                                && ul.UserId == userId).ToList();
                var jTrack = ModelJsonConverter.GetTrack(track);
                jTrack["likeStatus"] = "none";
                var rating = 0;

                foreach (var usersLike in usersLikes)
                {
                    if (usersLike.UserId == userId)
                        if (usersLike.IsLike)
                            jTrack["likeStatus"] = "liked";
                        else
                            jTrack["likeStatus"] = "disliked";

                    if (usersLike.IsLike)
                        rating++;
                    else
                        rating--;
                }

                jTrack["rating"] = rating;
                jTrack["isFavorite"] = userFavorite.Any();
                jTrack["isListened"] = userListened.Any();
                jTracks.Add(jTrack);

            }

            result["tracks"] = jTracks;
            return result;
        }

        public JObject GetFavoriteTracks(Guid userId)
        {
            var result = new JObject();
            var jTracks = new JArray();
            var userFavorite = _db.UserFavorite.Where(uf => uf.UserId == userId).ToList();
            var allTracks = _db.Tracks.ToList();
            var favoriteTracks = new List<Track>();
            foreach (var favorite in userFavorite)
                favoriteTracks.Add(allTracks.Where(tr => tr.Id == favorite.TrackId).ToList()[0]);


            foreach (var track in favoriteTracks)
            {
                var usersLikes = _db.UsersLikes.Where(ul => ul.TrackId == track.Id);

                var userListened = _db.UserListened.Where(ul => ul.TrackId == track.Id
                                                                && ul.UserId == userId).ToList();
                var jTrack = ModelJsonConverter.GetTrack(track);
                jTrack["likeStatus"] = "none";
                var rating = 0;

                foreach (var usersLike in usersLikes)
                {
                    if (usersLike.UserId == userId)
                        if (usersLike.IsLike)
                            jTrack["likeStatus"] = "liked";
                        else
                            jTrack["likeStatus"] = "disliked";

                    if (usersLike.IsLike)
                        rating++;
                    else
                        rating--;
                }

                jTrack["rating"] = rating;
                jTrack["isFavorite"] = userFavorite.Any();
                jTrack["isListened"] = userListened.Any();
                jTracks.Add(jTrack);

            }

            result["tracks"] = jTracks;
            return result;
        }

        public JObject CreateUser(string name, bool male = true)
        {
            var user = new User { FirstName = name, Male = male };
            _db.Users.Add(user);
            _db.SaveChanges();
            return ModelJsonConverter.GetUser(user);

        }
        public JObject GetTrack(Guid userId, long trackId)
        {
            var tracks = _db.Tracks.Where(t => t.Id == trackId).ToList();

            foreach (var track in tracks)
            {
                var usersLikes = _db.UsersLikes.Where(ul => ul.TrackId == track.Id);
                var userFavorite = _db.UserFavorite.Where(uf => uf.TrackId == track.Id
                                                                && uf.UserId == userId).ToList();
                var userListened = _db.UserListened.Where(ul => ul.TrackId == track.Id
                                                                && ul.UserId == userId).ToList();
                var jTrack = ModelJsonConverter.GetTrack(track);
                jTrack["likeStatus"] = "none";
                var rating = 0;

                foreach (var usersLike in usersLikes)
                {
                    if (usersLike.UserId == userId)
                        if (usersLike.IsLike)
                            jTrack["likeStatus"] = "liked";
                        else
                            jTrack["likeStatus"] = "disliked";

                    if (usersLike.IsLike)
                        rating++;
                    else
                        rating--;
                }

                jTrack["rating"] = rating;
                jTrack["isFavorite"] = userFavorite.Any();
                jTrack["isListened"] = userListened.Any();
                
                return jTrack;
            }

            return ModelJsonConverter.GetError(1);
        }

        public JObject AddTrackToFavorite(Guid userId, long trackId)
        {
            try
            {
                var userFavorite = new UserFavorite { UserId = userId, TrackId = trackId };
                _db.UserFavorite.Add(userFavorite);
                _db.SaveChanges();

                return GetTrack(userId, trackId);
            }
            catch (Exception e)
            {
                return ModelJsonConverter.GetError(0, e.Message);
            }

        }

        public JObject RemoveTrackFromFavorite(Guid userId, long trackId)
        {
            try
            {
                var deleted = _db.UserFavorite.FirstOrDefault(uf => uf.UserId == userId
                                                                    && uf.TrackId == trackId);
                if (deleted == null)
                    return ModelJsonConverter.GetError(1);

                _db.UserFavorite.Remove(deleted);
                _db.SaveChanges();

                return GetTrack(userId, trackId);
            }
            catch (Exception e)
            {
                return ModelJsonConverter.GetError(0, e.Message);
            }

        }

        public JObject AddTrackToListened(Guid userId, long trackId)
        {
            try
            {
                var userListened = new UserListened { UserId = userId, TrackId = trackId };
                _db.UserListened.Add(userListened);
                _db.SaveChanges();

                return GetTrack(userId, trackId);
            }
            catch (Exception e)
            {
                return ModelJsonConverter.GetError(0, e.Message);
            }

        }
        public JObject SetLikeStatus(Guid userId, long trackId, string status)
        {
            try
            {
                var uLike = _db.UsersLikes.FirstOrDefault(ul => ul.UserId == userId
                                                               && ul.TrackId == trackId);
                switch (status)
                {
                    case "like":
                        {
                            if (uLike == null)
                            {
                                uLike = new UsersLike
                                {
                                    IsLike = true,
                                    TrackId = trackId,
                                    UserId = userId
                                };
                                _db.UsersLikes.Add(uLike);
                            }
                            else
                                uLike.IsLike = true;
                        }
                        break;

                    case "dislike":
                        {
                            if (uLike == null)
                            {
                                uLike = new UsersLike
                                {
                                    IsLike = false,
                                    TrackId = trackId,
                                    UserId = userId
                                };
                                _db.UsersLikes.Add(uLike);
                            }
                            else
                                uLike.IsLike = false;
                        }
                        break;

                    case "none":
                        {
                            if (uLike != null)
                            {
                                _db.UsersLikes.Remove(uLike);
                            }
                        }
                        break;
                    default:
                        return ModelJsonConverter.GetError(2);
                }

                _db.SaveChanges();
                return GetTrack(userId, trackId);
            }
            catch (Exception e)
            {
                return ModelJsonConverter.GetError(0, e.Message);
            }

        }
    }
}
