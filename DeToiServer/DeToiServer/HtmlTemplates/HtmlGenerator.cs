using HtmlTags;

namespace DeToiServer.HtmlTemplates
{
    public static class HtmlGenerator
    {
        private static HtmlTag CreateBaseHtml()
        {
            // Create a new HTML document
            var html = new HtmlTag("html");

            // Create the head section with the title
            var head = new HtmlTag("head");
            head.Append(new HtmlTag("title").Text("Default Title"));

            // Create the style tag with CSS rules
            var style = new HtmlTag("style");
            style.Text(@"
                body {
                    font-family: Arial, sans-serif;
                    padding: 12px; /* Padding for mobile devices */
                }
                h1 {
                    padding: 8px 0; /* Padding for title */
                }
                p {
                    padding-bottom: 8px; /* Padding for message */
                }
                img {
                    max-width: 100%; /* Ensure images don't exceed container width */
                    height: auto; /* Maintain aspect ratio */
                    display: block; /* Ensure images don't have extra space below */
                    margin-bottom: 8px; /* Add spacing below images */
                }
                .section {
                    padding: 20px; /* Padding for sections */
                }
                .hyphen {
                    width: 60%;
                    margin: 0 auto;
                    text-align: center;
                }
                .image-container {
                    display: flex;
                    justify-content: space-between;
                    width: 80%;
                    margin: 0 auto;
                    text-align: center;
                }
                .image-container img {
                    width: 50%; /* Default width for images */
                    margin: 0 5%; /* Add spacing between images */
                }
                .image-container img:last-child {
                    width: 80%; /* Adjust width for last image in a row */
                    margin-right: 0; /* Remove right margin for the last image */
                }
            ");

            // Add the head and style sections to the HTML document
            html.Append(head);
            head.Append(style);

            return html;
        }

        public static HtmlTag GenerateHtmlWithTitleMessage(string title, string message)
        {
            // Create a div for the HTML content
            var html = CreateBaseHtml();

            // Create the body section with the title and message
            var body = new HtmlTag("body").AddClass("section");
            body.Append(new HtmlTag("h2").Text(title));
            body.Append(new HtmlTag("p").Text(message));

            // Add the body section to the HTML document
            html.Append(body);

            return html;
        }

        public static HtmlTag GenerateHtmlWithTitleMessageImage(string title, string message, string imageUrl)
        {
            // Create a div for the HTML content
            var html = CreateBaseHtml();

            // Create the body section with the title and message
            var body = new HtmlTag("body").AddClass("section");
            body.Append(new HtmlTag("h2").Text(title));
            body.Append(new HtmlTag("p").Text(message));

            // Create a div for the image container
            var imageContainer = new HtmlTag("div").AddClass("image-container");

            // Add the image to the image container
            imageContainer.Append(new HtmlTag("img").Attr("src", imageUrl));

            // Add the image container to the body section
            body.Append(imageContainer);

            // Add the body section to the HTML document
            html.Append(body);

            return html;
        }

        public static HtmlTag GenerateHtmlWithTitleMessageImages(string title, string message, params string[] imageUrls)
        {
            // Create a div for the HTML content
            var html = CreateBaseHtml();

            // Create the body section with the title and message
            var body = new HtmlTag("body").AddClass("section");
            body.Append(new HtmlTag("h2").Text(title));
            body.Append(new HtmlTag("p").Text(message));

            // Create a div for the image container
            var imageContainer = new HtmlTag("div").AddClass("image-container");

            // Add each image to the image container
            foreach (var imageUrl in imageUrls)
            {
                imageContainer.Append(new HtmlTag("img").Attr("src", imageUrl));
            }

            // Add the image container to the body section
            body.Append(imageContainer);

            // Add the body section to the HTML document
            html.Append(body);

            return html;
        }

        public static HtmlTag GenerateHtmlWithTitleMessageIframe(string title, string message, string iframeUrl)
        {
            // Create a div for the HTML content
            var html = CreateBaseHtml();

            // Create the body section with the title and message
            var body = new HtmlTag("body").AddClass("section");
            body.Append(new HtmlTag("h2").Text(title));
            body.Append(new HtmlTag("p").Text(message));

            // Create a div for the iframe container
            var iframeContainer = new HtmlTag("div").AddClass("iframe-container");

            // Add the iframe to the iframe container
            iframeContainer.Append(new HtmlTag("iframe").Attr("src", iframeUrl).Attr("width", "100%").Attr("height", "300"));

            // Add the iframe container to the body section
            body.Append(iframeContainer);

            // Add the body section to the HTML document
            html.Append(body);

            return html;
        }

        public static HtmlTag GenerateHtmlWithComponents(string title, string message, params HtmlTag[] components)
        {
            // Create a div for the HTML content
            var html = CreateBaseHtml();

            // Create the body section with the title and message
            var body = new HtmlTag("body").AddClass("section");
            body.Append(new HtmlTag("h1").Text(title));
            body.Append(new HtmlTag("p").Text(message));

            // Add additional components to the body section
            foreach (var component in components)
            {
                body.Append(component);
                body.Append(new HtmlTag("hr").AddClass("hyphen")); // Add centered hyphen separator
            }

            // Add the body section to the HTML document
            html.Append(body);

            return html;
        }
    }
}
