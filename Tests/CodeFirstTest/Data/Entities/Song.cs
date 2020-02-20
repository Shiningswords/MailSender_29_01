using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CodeFirstTest.Data.Entities
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public double Length { get; set; }

        public string Description { get; set; }

        //public int ArtistId { get; set; }

        //[ForeignKey(nameof(ArtistId))]
        //[ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }
    }
}
