using StudentsApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace StudentsApp.Html
{
    public static class ItemExtensions
    {
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string LinkText, string actionName, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(LinkText, actionName, null, new RouteValueDictionary(), new RouteValueDictionary(), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string LinkText, string actionName, object routeValues, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(LinkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary(), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string LinkText, string actionName, string controllerName, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(LinkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary(), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string LinkText, string actionName, RouteValueDictionary routeValues, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(LinkText, actionName, null, routeValues, new RouteValueDictionary(), showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string LinkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool showActionLinkAsDisabled = false)
        {
            return htmlHelper.ActionLinkAuthorized(LinkText, actionName, null, routeValues, htmlAttributes, showActionLinkAsDisabled);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string LinkText, string actionName, string controllerName, object routeValues, object htmlAttributes, bool showActionLinkAsDisabled = false, bool addAnchor = true)
        {
            return htmlHelper.ActionLinkAuthorized(LinkText, actionName, controllerName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes), showActionLinkAsDisabled, addAnchor);
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string LinkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool showActionLinkAsDisabled, bool addAnchor = true)
        {
            if (htmlHelper.ActionAuthorized(actionName, controllerName))
            {
                return htmlHelper.RawActionLink(LinkText, actionName, controllerName, routeValues, htmlAttributes, addAnchor);
            }
            else
            {
                if (showActionLinkAsDisabled)
                {
                    TagBuilder tagBuilder = new TagBuilder("span");
                    tagBuilder.InnerHtml = LinkText;
                    return MvcHtmlString.Create(tagBuilder.ToString());
                }
                else
                {
                    return MvcHtmlString.Empty;
                }
            }
        }

        public static MvcHtmlString ActionItemAuthorized(this HtmlHelper htmlHelper, string actionName, bool showActionItemAsDisabled = false)
        {
            return htmlHelper.ActionItemAuthorized(actionName, null, new RouteValueDictionary(), showActionItemAsDisabled);
        }

        public static MvcHtmlString ActionItemAuthorized(this HtmlHelper htmlHelper, string actionName, string controllerName, bool showActionItemAsDisabled = false)
        {
            return htmlHelper.ActionItemAuthorized(actionName, controllerName, new RouteValueDictionary(), showActionItemAsDisabled);
        }

        public static MvcHtmlString ActionItemAuthorized(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, bool showActionItemAsDisabled = false)
        {
            return htmlHelper.ActionItemAuthorized(actionName, controllerName, new RouteValueDictionary(routeValues), showActionItemAsDisabled);
        }

        public static MvcHtmlString ActionItemAuthorized(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, bool showActionItemAsDisabled)
        {
            try
            {
                if (htmlHelper.ActionAuthorized(actionName, controllerName))
                {
                    return htmlHelper.Action(actionName, controllerName, routeValues);
                }
                else
                {
                    return MvcHtmlString.Empty;
                }
            }
            catch (Exception ex)
            {


                return MvcHtmlString.Empty;
            }

        }

        public static MvcHtmlString RawActionLink(this HtmlHelper htmlHelper, string rawHtml, string action, string controller, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool addAnchor = true)
        {
            string holder = Guid.NewGuid().ToString();
            if (addAnchor)
            {
                string anchor = htmlHelper.ActionLink(holder, action, controller, routeValues.Count == 0 ? null : routeValues, htmlAttributes.Count == 0 ? null : htmlAttributes).ToString();
                return MvcHtmlString.Create(anchor.Replace(holder, rawHtml));
            }
            else
            {
                string anchor = htmlHelper.ActionLink(holder, "Dummy", "Dummy", routeValues.Count == 0 ? null : routeValues, htmlAttributes.Count == 0 ? null : htmlAttributes).ToString();
                var index = anchor.IndexOf("href=\"");
                var endIndex = 0;
                for (int i = index + 15; i < anchor.Length; i++)
                {
                    var indexChar = anchor[i];
                    if (indexChar == '\"')
                    {
                        endIndex = i;
                        break;
                    }
                }
                anchor = anchor.Replace(anchor.Substring(index, 1 + endIndex - index), "href=\"#\"");
                return MvcHtmlString.Create(anchor.Replace(holder, rawHtml));
            }

        }
    }
}