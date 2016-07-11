using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace AsanHtmlHelpers.Components
{
    public static class AsanImageForExtension
    {

        /// <summary>
        /// This helper creates Image tag for Model
        /// </summary>
        /// <param name="expression">Model Property</param>
        /// <returns><img src="Source" alt="AlternateText" name="PropertyName" id="PropertyId" class="CSS" /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return AsanImageFor(htmlHelper, expression, null, null, null);
        }


        #region 2 parameter overloads
        /// <summary>
        /// This helper creates Image tag for Model
        /// </summary>
        /// <param name="expression">Model Property</param>
        /// <param name="alternateText">Alternate text to display</param>
        /// <returns><img src="Source" alt="AlternateText" name="PropertyName" id="PropertyId" class="CSS" /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string alternateText)
        {
            return AsanImageFor(htmlHelper, expression, alternateText, null, null);
        }
        #endregion

        #region 3 parameter overloads


        /// <summary>
        /// This helper creates Image tag for Model
        /// </summary>
        /// <param name="expression">Model Property</param>
        /// <param name="alternateText">Alternate text to display</param>
        /// <param name="cssClass">CSS classes to be applied</param>
        /// <returns><img src="Source" alt="AlternateText" name="PropertyName" id="PropertyId" class="CSS" /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
        string alternateText,
        string cssClass)
        {
            return AsanImageFor(htmlHelper, expression, alternateText, cssClass, null);
        }


        /// <summary>
        /// This helper creates Image tag for Model
        /// </summary>
        /// <param name="expression">Model Property</param>
        /// <param name="alternateText">Alternate text to display</param>
        /// <param name="htmlAttributes">Object of html components</param>
        /// <returns><img src="Source" alt="AlternateText" name="PropertyName" id="PropertyId" class="CSS" /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
        string alternateText,
        object htmlAttributes)
        {
            return AsanImageFor(htmlHelper, expression, alternateText, null, htmlAttributes);
        }
        #endregion

        #region 4 parameter overloads

        /// <summary>
        ///  This helper creates Image tag for Model
        /// </summary>
        /// <param name="expression">Model Property</param>
        /// <param name="alternateText">Alternate text to display</param>
        /// <param name="cssClass">CSS classes to be applied</param>
        /// <param name="htmlAttributes">Object of html components</param>
        /// <returns><img src="Source" alt="AlternateText" name="PropertyName" id="PropertyId" class="CSS" /> HtmlAttributes depend what values you wanted to pass in</returns>
        public static MvcHtmlString AsanImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
           string alternateText,
           string cssClass,
           object htmlAttributes)
        {

            // Reads the expression name 
            string name = ExpressionHelper.GetExpressionText(expression);

            // Reads all the metadata for the provided property
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            // Create input element image
            TagBuilder builder = new TagBuilder("img");

            // Add attribute for Name
            if (!string.IsNullOrEmpty(metadata.DisplayName))
            {
                name = TagBuilder.CreateSanitizedId(metadata.DisplayName);
            }
            else
            {
                name = TagBuilder.CreateSanitizedId(name);
            }

            builder.MergeAttribute("name", name);

            // Add attribute for Id
            builder.GenerateId(name);

            // Add attribute of CSS Class
            if (!string.IsNullOrWhiteSpace(cssClass))
                builder.AddCssClass(cssClass);
            else
                builder.AddCssClass("img-responsive");

            // Add attribute src
            string source = metadata.Model as string;
            builder.MergeAttribute("src", source);

            // Add attribute alt & title
            if (!string.IsNullOrEmpty(alternateText))
            {
                builder.MergeAttribute("alt", metadata.Description);
                builder.MergeAttribute("title", metadata.Description);
            }
            else
            {
                builder.MergeAttribute("alt", alternateText);
                builder.MergeAttribute("title", alternateText);
            }

            // Add attribute of htmlAttributes
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }


        #endregion
    }
}
