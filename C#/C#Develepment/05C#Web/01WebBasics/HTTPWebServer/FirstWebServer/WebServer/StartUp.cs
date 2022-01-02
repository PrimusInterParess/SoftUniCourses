

using System.Text;

namespace WebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using WebServer.Server;

    // localhost 127.0.0.1

    public class StartUp
    {
        private const string IpAddress = "127.0.0.1";
        private const int port = 9091;

        public static async Task Main()
        {
            var server = new HttpServer(IpAddress, port);

            await server.Start();

            //            IPAddress address = IPAddress.Parse(IpAddress);

            //            int port = 9091;

            //            TcpListener listener = new TcpListener(address, port);

            //            listener.Start();

            //            Console.WriteLine($"Server started on port {port}...");
            //            Console.WriteLine($"Listening for requests...");

            //            while (true)
            //            {
            //                var connectionAcceptTcpClient = await listener.AcceptTcpClientAsync();
            //                var networkStream = connectionAcceptTcpClient.GetStream();

            //                var bufferLength = 1024;


            //                var buffer = new byte[bufferLength];

            //                var requestBuilder = new StringBuilder();

            //                while (networkStream.DataAvailable)
            //                {
            //                    var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

            //                    requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            //                }

            //                Console.WriteLine(requestBuilder);


            //                var contentBody = "Пацо е голем!";

            //                int contentLength = Encoding.UTF8.GetByteCount(contentBody);

            //                var response = @$"HTTP/1.1 200 OK
            //Server: Begins Server
            //Date: {DateTime.UtcNow:R}
            //Content-Length: {contentLength}
            //Content-Type: text/plain; charset=UTF-8

            //{contentBody}";

            //                var responseBites = Encoding.UTF8.GetBytes(response);

            //                await networkStream.WriteAsync(responseBites);



            //                connectionAcceptTcpClient.Close();  
            //            }


        }
    }
}
