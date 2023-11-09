using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using TheMoviesHub.Class;
using TheMoviesHub.Models;

namespace TheMoviesHub.Controllers
{
    public class TmdbApiController : Controller
    {
        public ActionResult Index(string peopleName, int? page) 
        { 

            if (page != null)
                CallAPI(peopleName, Convert.ToInt32(page));
        
            Models.TheMovieDb theMovieDb= new Models.TheMovieDb ();
            theMovieDb.searchText= peopleName;
            return View(theMovieDb);

           

 
        }

        [HttpPost]

        public ActionResult Index(Models.TheMovieDb theMovieDb, string searchText)
        {
            if (ModelState.IsValid) 
            {
                CallAPI(searchText, 0);
                
            }
            return View(theMovieDb);
        }


        public void CallAPI(string searchText, int page) 
        {
            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page) ;

            /* Calling https://developers.themoviedb.org/3/search-people */
            string apiKey = "608995990f09c59f776a5233218745f9";

            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/search/person?api_key=" + apiKey+ "&languaje=en-US&query=" + searchText + "&page=" + pageNo + "&include_adult=false") as
                HttpWebRequest;

            string apiResponse = "";
            ServicePointManager.SecurityProtocol= SecurityProtocolType.Ssl3
                | SecurityProtocolType.Tls
                |SecurityProtocolType.Tls11
                | SecurityProtocolType.Tls12;
            using(HttpWebResponse response = apiRequest.GetResponse() as  HttpWebResponse ) 
        
            {
                
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();  
            
            }

            ResponseSearchPeople rootObject = JsonConvert.DeserializeObject<ResponseSearchPeople>(apiResponse);


            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"resultDiv\" ><p>Names</p> ");

            foreach(Result result in rootObject.results) 
            {

                string image = result.profile_path == null ? Url.Content("~/content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + result.profile_path;
                string link =Url.Action("GetPerson", "TmdbApi", new {id = result.id});
                sb.Append("<div class=\"result\" resourdeId=\""+ result.id + "\">" + "<a href=\""+ link + "\" ><img src=\"" + image + "\"/>"+ "<p>" + result.name + "</a></p></div>");
            }
            ViewBag.Result = sb.ToString();

            int pageSize = 20;
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = pageNo;
            pagingInfo.TotalItems= rootObject.total_results;
            pagingInfo.ItemsPerPage= pageSize;
            ViewBag.Paging = pagingInfo;
        }

        public ActionResult GetPerson(int id) 
        {

            /* Calling API https://devolopers.themoviedb.org/3/people */
            string apiKey = "608995990f09c59f776a5233218745f9";
            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/person/" + id + "?api_key=" + apiKey + "&language=en-US")  as HttpWebRequest;

            string apiResponse = "";
            using(HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse ) 
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }


            ResponsePerson rootObject = JsonConvert.DeserializeObject<ResponsePerson>(apiResponse);

            TheMovieDb theMovieDb = new TheMovieDb();
            theMovieDb.name= rootObject.name;  
            theMovieDb.biography = rootObject.biography;
            theMovieDb.birthday = rootObject.birthday;
            theMovieDb.place_of_brith = rootObject.place_of_brith;
            theMovieDb.profile_path= rootObject.profile_path == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500" + rootObject.profile_path;
           
            theMovieDb.also_known_as = string.Join("," , rootObject.also_known_as );

            return View(theMovieDb);
        }
    }
}
