using CodeFirstTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestSongsDBContext())
            {
                db.Database.Log = Console.WriteLine;

                foreach (var artist in db.Artists.Where(a => a.Birthday < DateTime.Now))
                    foreach (var artist_song in artist.Songs)
                        Console.WriteLine(artist_song.Title);

                var values = db.Artists.Select(artist => new { Name = artist.Name }).ToArray();
            }


            Console.ReadLine();
        }
    }
}
