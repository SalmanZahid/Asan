using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

namespace AsanHtmlHelpers.Components
{
    public static class AsanDropdownXML
    {
        //This overload is extension method that accepts three parameters i.e. name and dropdowntype which is saved in xml and selected value
        public static MvcHtmlString Custom_DropdownList(this HtmlHelper helper, string name, string dropdownType, string selectedValue)
        {
            //This method in turns calls below overload.
            return Custom_DropdownList(helper, name, dropdownType, selectedValue, null);
        }

        //This overload is extension method accepts name, list and htmlAttributes as parameters.
        public static MvcHtmlString Custom_DropdownList(this HtmlHelper helper, string name, string dropdownType, string selectedValue, object htmlAttributes)
        {
            //Creating a list for holding Shift Types 
            List<string> dropdownItems = new List<string>();


            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/DropdownItems.xml");
            // Create an XML Document for this file.
            XmlDocument document = new XmlDocument();
            document.Load(xmlData);

            if (dropdownType == null)
                return null;

            XmlNodeList nodes = document.GetElementsByTagName(dropdownType);

            if (nodes == null)
                return null;

            foreach (XmlNode node in nodes)
            {
                if (!string.IsNullOrEmpty(node.Attributes["value"].Value.ToString()))
                    dropdownItems.Add(node.Attributes["value"].Value.ToString());
            }

            //Creating a string to Hold Selected tag
            string selected = string.Empty;

            //Creating a select element using TagBuilder class which will create a dropdown.
            TagBuilder dropdownList = new TagBuilder("select");
            //Setting the name and id attribute with name parameter passed to this method.
            dropdownList.Attributes.Add("name", name);
            dropdownList.Attributes.Add("id", name);

            //Created StringBuilder object to store option data fetched oen by one from list.
            StringBuilder options = new StringBuilder();

            options.Append("<option>---- Select " + name + "----</option>");

            //Iterated over the IEnumerable list.
            foreach (var item in dropdownItems)
            {
                //Checking If The Selected Value Is Not Null,then select the value
                if (item == selectedValue)
                    selected = "selected";
                //Each option represents a value in dropdown. For each element in the list, option element is created and appended to the stringBuilder object.
                options = options.Append("<option value='" + item + "' " + selected + ">" + item + "</option>");
                //Once it is selected then making selecred value empty
                selected = string.Empty;
            }
            //assigned all the options to the dropdown using innerHTML property.
            dropdownList.InnerHtml = options.ToString();

            //Assigning the attributes passed as a htmlAttributes object.
            dropdownList.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            //Returning the entire select or dropdown control in HTMLString format.
            return MvcHtmlString.Create(dropdownList.ToString(TagRenderMode.Normal));
        }
    }
}
