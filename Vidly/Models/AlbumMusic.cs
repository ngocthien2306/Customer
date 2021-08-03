using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class AlbumMusic
    {
        public int Id { get; set; }

        public TypeOfAlbum TypeOfAlbum { get; set; }
        [Required()]
        [StringLength(255)]
        public string  Title { get; set; }

        public byte Type { get; set; }

        [Required()]
        [StringLength(30)]
        public string  Country { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required()]
        [Range(1, 100)]
        public int AmountOfAlbum { get; set; }
    }
}