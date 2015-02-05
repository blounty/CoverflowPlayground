using System;
using UIKit;

namespace CoverflowSample.Models
{
	public class Album
	{
        string albumUrl;
     
        public string AlbumUrl
        {
            get
            {
                return albumUrl;
            }
        }

        public Album(string albumUrl)
        {
            this.albumUrl = albumUrl;
            
        }
	}

}

