using HtmlTags;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DeToiServer.HtmlTemplates
{
    public static class HtmlTagHelpers
    {
        public static HtmlTag TextBoxTag(this HtmlHelper html, string name)
        {
            return new HtmlTag("input").Id(name).Attr("name", name)
                .Attr("type", "text").Attr("value", html.ViewData[name]);
        }
    }
}
