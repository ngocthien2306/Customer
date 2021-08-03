using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class NewAlbumsMusicViewModel
    {
        public IEnumerable<TypeOfAlbum> TypeOfAlbums { get; set; }
        public AlbumMusic AlbumMusic { get; set; }
        public string GetTitle
        {
            get
            {
                if (AlbumMusic != null && AlbumMusic.Id != 0)
                    return "Edit Album";
                return "Create Album";
            }
        }
    }
}