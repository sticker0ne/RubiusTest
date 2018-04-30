using System.ComponentModel.DataAnnotations.Schema;

namespace musicServiceCore.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }

    }
}
