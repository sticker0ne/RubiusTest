using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicServiceCore.Models
{
    public class UserListened
    {
        public Guid UserId { get; set; }
        public long TrackId { get; set; }
    }
}
