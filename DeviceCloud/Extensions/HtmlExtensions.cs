using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceCloud.Extensions
{
    public static class HtmlExtensions
    {
        public static string Span(this HtmlHelper helper, string id, string text)
        {
            return String.Format(@"<span id=""{0}"">{1}</span>", id, text);
        }
    }
}