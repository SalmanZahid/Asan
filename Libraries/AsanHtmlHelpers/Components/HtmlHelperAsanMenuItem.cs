﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsanHtmlHelpers.Components
{
    public static class HtmlHelperAsanMenuItem
    {

        public static MvcHtmlString AsanMenu(this HtmlHelper html, string text, string controller)
        {
            return AsanMenu(html, text, null, controller, null, null);
        }

        public static MvcHtmlString AsanMenu(this HtmlHelper html, string text, string controller, string cssClass)
        {
            return AsanMenu(html, text, null, controller, cssClass, null);
        }

        public static MvcHtmlString AsanMenu(this HtmlHelper html, string text, string controller, object htmlAttributes)
        {
            return AsanMenu(html, text, null, controller, null, htmlAttributes);
        }


        public static MvcHtmlString AsanMenu(this HtmlHelper html, string text, string action, string controller, string cssClass, object htmlAttributes)
        {

            return new MvcHtmlString("");
        }


    }
}
