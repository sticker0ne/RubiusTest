using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicServiceCore.Models
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public long MusicianId { get; set; }

    }
}
