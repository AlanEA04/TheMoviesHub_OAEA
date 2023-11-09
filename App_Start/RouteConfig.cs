using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheMoviesHub
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "TmdbApi",
                url: "TmdbApi/{id}/",
                defaults: new { Controller = "TmdbApi", action = "GetPerson", id = "" },
                constraints: new { id = @"^ [0-9]+$" }
                );


            routes.MapRoute(
                name: "TmdbApiPaging",
                url: "TmdbApi/{peopleName}/{page}",
                defaults: new { Controller = "TmdbApi", action = "index", peopleName="", page=""},
                constraints: new { peooleName = @"^ [a-zA-Z]+$", page =  @"^ [0-9]+$" }

                );

            routes.MapRoute(
                   name: "Desault",
                url: "{controller}/{action}/{id}",
                defaults: new { Controller = "TmdbApi", action = "index", id = UrlParameter.Optional }
              

                );
        }
    }
}
