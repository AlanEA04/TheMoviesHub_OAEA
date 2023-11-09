using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TheMoviesHub.Class
{
    public class TheMoviedbSearchPerson
    {
    }
    public class KnownFor
    {
        public string poster_path { get; set; }

        public bool adult { get; set; }

        public string overview { get; set; }

        public string realease_date { get; set; }
        public string original_title { get; set; }

        public List<object> genre_ids { get; set; }
        public int id { get; set; }
        public string media_type { get; set; }
        public string original_language { get; set; }
            
        public string title { get; set; }

        public string backdrop_path{ get; set;}

        public string poipularity { get; set; }
        public string vote_count { get; set; }
        public string first_air_date { get; set;}

        public List<string> origin_country { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }

    }
    public class Result
    {
        public string profile_path { get; set; }
        public bool adult { get; set; }
        public int id { set; get; }
        public List<KnownFor> known_Fors { get; set; }
        public string name { get; set; }
        public double popularity { get; set; }


    }

    public class ResponseSearchPeople
    {
        public int page { set; get; }
        public List<Result> results { get; set; }
        public int total_results { set; get; }
        public int total_pages { set; get; }
    }
    public class ResponsePerson
    {
        public bool adult { set; get; }
        public List<string> also_known_as { set; get; }

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