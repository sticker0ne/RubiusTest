using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicServiceCore.Models
{
    public class Musician
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CareerStartYear { get; set; }
    }
}
