using System;
namespace musicServiceCore.Models
{
    public class UsersLike
    {
        public Guid UserId { get; set; }
        public long TrackId { get; set; }
        public bool IsLike { get; set; }
    }
}
