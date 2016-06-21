using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AsanHtmlHelpers.Components
{
    public static class HtmlHelperImage
    {
        #region 2 parameter overloads
        /// <summary>
        /// This helper creates AsanImage tag
        /// </summary>        
        /// <param name="source">provide specified url</param>
        /// <param name="alternateText">alternate text to display</param>
        /// <returns><img src="source" alt="alternateText" /></returns>
        public static MvcHtmlString AsanImage(this HtmlHelper htmlHelper,
        string source,
        string alternateText)
        {
            return AsanImage(htmlHelper, null, source, alternateText, null, null);
        }
        #endregion

        #region 3 parameter overloads
        /// <summary>
        ///  This helper creates AsanImage tag
        /// </summary>
        /// <param name="name">set name and id for html tag</param>
        /// <param name="source">provide specified url</param>
        /// <param name="alternateText">alternate text to display</param>
        /// <returns><img src="source" alt="alternateText" name="name" id="name" /></returns>
        public static MvcHtmlString AsanImage(this HtmlHelper htmlHelper,
          string name,
          string source,
          string alternateText)
        {
            return AsanImage(htmlHelper, name, source, alternateText, null, null);
        }


        /// <summary>
        ///  This helper creates AsanImage tag
        /// </summary>
        /// <param name="source">provide specified url</param>
        /// <param name="alternateText">alternate text to display</param>
        /// <param name="htmlAttributes">object of html components</param>
        /// <returns><img src="source" alt="alternateText" /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImage(this HtmlHelper htmlHelper,
        string source,
        string alternateText,
        object htmlAttributes)
        {
            return AsanImage(htmlHelper, null, source, alternateText, null, htmlAttributes);
        }
        #endregion

        #region 4 parameter overloads
        /// <summary>
        ///  This helper creates AsanImage tag
        /// </summary>
        /// <param name="name">set name and id for html tag</param>
        /// <param name="source">provide specified url</param>
        /// <param name="alternateText">alternate text to display</param>
        /// <param name="cssClass">css classes to be applied</param>
        /// <returns><img src="source" alt="alternateText" name="name" id="name" class="cssClass" /></returns>
        public static MvcHtmlString AsanImage(this HtmlHelper htmlHelper,
         string name,
         string source,
         string alternateText,
         string cssClass)
        {
            return AsanImage(htmlHelper, name, source, alternateText, cssClass, null);
        }

        /// <summary>
        ///  This helper creates AsanImage tag
        /// </summary>
        /// <param name="name">set name and id for html tag</param>
        /// <param name="source">provide specified url</param>
        /// <param name="alternateText">alternate text to display</param>
        /// <param name="htmlAttributes">object of html components</param>
        /// <returns><img src="source" alt="alternateText" name="name" id="name"  /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImage(this HtmlHelper htmlHelper,
         string name,
         string source,
         string alternateText,
         object htmlAttributes)
        {
            return AsanImage(htmlHelper, name, source, alternateText, null, htmlAttributes);
        }

        /// <summary>
        ///  This helper creates AsanImage tag
        /// </summary>
        /// <param name="source">provide specified url</param>
        /// <param name="alternateText">alternate text to display</param>
        /// <param name="htmlAttributes">object of html components</param>
        /// <param name="cssClass">css classes to be applied</param>
        /// <returns><img src="source" alt="alternateText" class="cssClass" /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImage(this HtmlHelper htmlHelper,
         string source,
         string alternateText,
         object htmlAttributes,
         string cssClass)
        {
            return AsanImage(htmlHelper, null, source, alternateText, cssClass, htmlAttributes);
        }
        #endregion

        /// <summary>
        ///  This helper creates AsanImage tag
        /// </summary>
        /// <param name="name">set name and id for html tag</param>
        /// <param name="source">provide specified url</param>
        /// <param name="alternateText">alternate text to display</param>
        /// <param name="cssClass">css classes to be applied</param>
        /// <param name="htmlAttributes">object of html components</param>
        /// <returns><img src="source" alt="alternateText" name="name" id="name" class="cssClass" /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImage(this HtmlHelper htmlHelper,
           string name,
           string source,
           string alternateText,
           string cssClass,
           object htmlAttributes)
        {

            TagBuilder builder = new TagBuilder("img");


            if (!string.IsNullOrEmpty(name))
            {
                name = TagBuilder.CreateSanitizedId(name);
                builder.GenerateId(name);
                builder.MergeAttribute("name", name);
            }

            if (!string.IsNullOrWhiteSpace(cssClass))
                builder.AddCssClass(cssClass);

            builder.MergeAttribute("src", source);
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
