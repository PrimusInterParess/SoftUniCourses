namespace SUHttpServer.Responses
{
    using System;
    using HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(
            string text)
            : base(text,ContentType.Html)
        {
        }
    }
}
