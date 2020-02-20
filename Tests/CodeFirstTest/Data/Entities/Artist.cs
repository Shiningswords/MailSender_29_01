using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest.Data.Entities
{
    //[Table("Artist")]
    public class Artist
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Song> Songs { get; set; }// = new List<Song>();

        public virtual ICollection<Distributors> Distributors { get; set; }
    }
}
}
