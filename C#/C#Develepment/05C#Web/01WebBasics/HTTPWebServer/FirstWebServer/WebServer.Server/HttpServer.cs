using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Server
{
    public class HttpServer
    {
        private IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HttpServer(string ipAdress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAdress);
            this.port = port;

            listener = new TcpListener(this.ipAddress, this.port);
        }

        public async Task Start()
        {

            this.listener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {

                var connectionAcceptTcpClient = await this.listener.AcceptTcpClientAsync();
                var networkStream = connectionAcceptTcpClient.GetStream();

                var request = await this.ReadRequest(networkStream);

                Console.WriteLine(request);

                await WriteRespoinse(networkStream);
                


                connectionAcceptTcpClient.Close();
            }

        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {

            var bufferLength = 1024;

            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            while (networkStream.DataAvailable)
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            return requestBuilder.ToString();
        }

        private async Task WriteRespoinse(NetworkStream networkStream)
        {
            var contentBody = "Пацо е голем!";

            int contentLength = Encoding.UTF8.GetByteCount(contentBody);

            var response = @$"HTTP/1.1 200 OK
Server: Begins Server
Date: {DateTime.UtcNow:R}
Content-Length: {contentLength}
Content-Type: text/plain; charset=UTF-8

{contentBody}";

            var responseBites = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responseBites);

        }
    }
}
