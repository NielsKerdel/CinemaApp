using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Entities
{
   public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Subtitle { get; set; }
        public string Writer { get; set; }
        public string Stars { get; set; }
        public string Website { get; set; }
        public string IMDB { get; set; }
        public string Trailer { get; set; }
        public string ImageData { get; set; }
        public string Kijkwijzer { get; set; }
        public string ThumbnailData { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }

    }
}
