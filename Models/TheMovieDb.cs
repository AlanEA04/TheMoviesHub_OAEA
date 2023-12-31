﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMoviesHub.Models
{
    public class TheMovieDb
    {

        [Required]

        public string searchText { get; set; }
        public bool adult { get; set; }
        public string also_known_as { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }

        public string deathday { get; set; }

        public int gender { get; set; }

        public string homepage { get; set; }

        public int id { get; set; } 
        public string imdb_id { get; set; }
        public string name { get; set; }
        public string place_of_brith { get; set; }
        public double papularity { get; set; }
        public string profile_path { get; set; }

    }
}