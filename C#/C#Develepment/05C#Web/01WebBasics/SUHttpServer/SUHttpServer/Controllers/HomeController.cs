using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.Controllers;
using SUHttpServer.HTTP;

namespace SUHttpServer.Demo.Controllers
{
    public class HomeController : Controller
    {

        private const string location = "https://softuni.bg/";

        private const string HtmlForm = @"<form action='HTML' method='POST'>
                                           Name: <input type='text' name='Name'>
                                           Age: <input type='number' name='Age'>
                                           <input type='submit' value ='Save'/>
                                         </form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
                                            <input type='submit' value ='Download Sites Content' /> 
                                            </form>";

        private const string FileName = "content.txt";


        public HomeController(Request request)
        : base(request)
        {
        }

        public Response Index() => Text("Hello from the server!");

        public Response Redirect() => Redirect(location);

        public Response Html() => Html(HomeController.HtmlForm);

        public Response HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public Response Content() => Html(HomeController.DownloadForm);

        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(HomeController.FileName,
                new string[] { "https://judge.softuni.org/", "https://softuni.bg/" }).Wait();

            return File(HomeController.FileName);
        }


        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(
                Environment.NewLine + new string('-', 100),
                responses);

           // await File.WriteAllTextAsync(fileName, responsesString);
        }
    }
}
