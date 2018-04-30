using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicServiceCore.Models
{
    public class UserFavorite
    {
        public Guid UserId { get; set; }
        public long TrackId { get; set; }
    }
}
