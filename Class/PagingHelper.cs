using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TheMoviesHub.Class
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            string anchorInnetHtml = "";
            for(int i = 1; i <= pagingInfo.TotalPages; i++) 
            {
                TagBuilder tag = new TagBuilder("a");
                anchorInnetHtml = AnchorInnetHtml(i, pagingInfo);

                if (anchorInnetHtml == "..")
                    tag.MergeAttribute("href", "#");

                else
                    tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml= anchorInnetHtml;

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("active");

                }
                tag.AddCssClass("paging");
                if(anchorInnetHtml !="")
                    result.Append(tag.ToString());

            }
            return MvcHtmlString.Create(result.ToString()); 
        }
        public static string AnchorInnetHtml(int i, PagingInfo pagingInfo)
        {

            string anchorInnetHtml = "";
            if (pagingInfo.TotalPages <= 10)
                anchorInnetHtml = i.ToString();
            else
            {
                if (pagingInfo.CurrentPage <= 5)
                {
                    if ((i <= 8) || (i == pagingInfo.TotalPages))
                        anchorInnetHtml = i.ToString();
                    else if (i == pagingInfo.TotalPages - 1)
                        anchorInnetHtml = "..";
                }
                else if ((pagingInfo.CurrentPage > 5) && (pagingInfo.TotalPages - pagingInfo.CurrentPage >= 5))
                {

                    if ((i == 1) || (i == pagingInfo.TotalPages) || ((pagingInfo.CurrentPage - i >= -3) && (pagingInfo.CurrentPage - i < 3)))
                        anchorInnetHtml = i.ToString();

                    else if ((i == pagingInfo.CurrentPage - 4) || (i == pagingInfo.CurrentPage + 4))
                        anchorInnetHtml = "..";
                }
                else if (pagingInfo.TotalPages - pagingInfo.CurrentPage < 5)
                {
                    if ((i == 1) || (pagingInfo.TotalPages - i <= 7))
                        anchorInnetHtml = i.ToString();
                    else if (pagingInfo.TotalPages - 1 == 8)
                        anchorInnetHtml = "..";
                }
            }
            return anchorInnetHtml;
        }

        /*  private static string AnchoInnetHtml(int i, PagingInfo pagingInfo)
          {
              throw new NotImplementedException();

          }*/
    }

   

}