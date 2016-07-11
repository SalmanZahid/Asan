using System.Web.Mvc;

namespace AsanHtmlHelpers.Components
{
    public static class AsanActivePageExtension
    {
        // This method set class on active menu link in Menu Bar
        public static string AsanActivePage(this HtmlHelper helper, string controller, string action, string cssClass = "active")
        {
            string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            string currentAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();

            if (currentController == controller && (string.IsNullOrEmpty(action) || currentAction == action))
                return cssClass;
            else
                return string.Empty;
        }
    }
}
