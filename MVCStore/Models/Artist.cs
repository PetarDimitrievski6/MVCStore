﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCStore.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}