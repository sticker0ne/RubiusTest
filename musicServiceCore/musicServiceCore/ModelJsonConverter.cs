using System;
using musicServiceCore.Models;
using Newtonsoft.Json.Linq;

namespace musicServiceCore
{
    public class ModelJsonConverter
    {
        public static JObject GetJMusician(Musician musician)
        {
            var jMusician = new JObject
            {
                ["id"] = musician.Id,
                ["name"] = musician.Name,
                ["careerStartYear"] = musician.CareerStartYear.Year,
                ["age"] = DateTime.Today.Year - musician.BirthDate.Year
            };
            return jMusician;
        }
        public static JObject GetJAlbum(Album album)
        {
            var jAlbum = new JObject
            {
                ["id"] = album.Id,
                ["name"] = album.Name,
                ["releaseYear"] = album.ReleaseYear.Year
            };
            return jAlbum;
        }

        public static JObject GetTrack(Track track)
        {
            var jTrack = new JObject
            {
                ["id"] = track.Id,
                ["name"] = track.Name,
                ["duration"] = String.Format("{0}:{1}", (track.Duration / 60).ToString("00"), track.Duration % 60)
            };
            return jTrack;
        }

        public static JObject GetUser(User user)
        {
            var jUser = new JObject
            {
                ["id"] = user.Id,
                ["firstName"] = user.FirstName,
                ["sex"] = user.Male ? "male" : "female"
            };
            return jUser;
        }

        public static JObject GetError(int errorCode, string desc = null)
        {
            var errorMsg = "";
            switch (errorCode)
            {
                case 2:
                    errorMsg = "Invalid likeStatus";
                    desc = "likeStatus is able to be: like, dislike or none";
                    break;
                case 1:
                    errorMsg = "track or user have not been found";
                    break;
                case 0:
                    errorMsg = "look at description";
                    break;
                default:
                    errorMsg = "unknown error";
                    break;
            }
            return new JObject
            {
                ["errorCode"] = errorCode,
                ["errorMessage"] = errorMsg,
                ["errorDescription"] = desc
            };
        }
    }
}
