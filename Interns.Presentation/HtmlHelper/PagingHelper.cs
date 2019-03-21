﻿using System;
using System.Text;
using System.Web.Mvc;
using Interns.Presentation.Models;

namespace Interns.Presentation.HtmlHelper
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this System.Web.Mvc.HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected"); tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default"); result.Append(tag);
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}