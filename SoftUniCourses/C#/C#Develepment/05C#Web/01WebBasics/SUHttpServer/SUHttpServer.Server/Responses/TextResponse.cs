
namespace SUHttpServer.Responses
{
    using System;
    using HTTP;

    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, ContentType.PlainText)
        {
        }
    }
}
