using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.HTTP;
using SUHttpServer.Routing;
using SUHttpServer.Server.HTTP;

namespace SUHttpServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;
        private readonly RoutingTable routingTable;

        public HttpServer(
            Action<IRoutingTable> routingTable)
            : this(8080, routingTable)
        {
        }

        public HttpServer(
            int port,
            Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(
            string _ipAddress,
            int _port,
            Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(_ipAddress);
            this.port = _port;

            serverListener = new TcpListener(ipAddress, port);

            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public async Task Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server is listening on port {port}");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    var networkStream = connection.GetStream();
                    var requestText = await this.ReadRequest(networkStream);

                    Console.WriteLine(requestText);

                    var request = Request.Parse(requestText);
                    var response = this.routingTable.MatchRequest(request);

                    if (response.PreRenderAction != null)
                    {
                        response.PreRenderAction(request, response);
                    }

                    AddSession(request, response);

                    await WriteResponse(networkStream, response);
                    connection.Close();
                });
            }
        }

        private void AddSession(Request request, Response response)
        {
            var sessionExists = request
                .Session
                .ContainsKey(Session.SessionCurrentDateKey);

            if (!sessionExists)
            {
                request.Session[Session.SessionCurrentDateKey]
                    = DateTime.Now.ToString();
                response.Cookies
                    .Add(Session.SessionCookieName, request.Session.Id);
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var totalBytes = 0;
            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        private static async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);

        }
    }
}
