﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server.Http;
using WebServer.Server.Routing;

namespace WebServer.Server
{
    public class HttpServer
    {
        private IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HttpServer(string ipAdress, int port, Action<IRoutingTable> routingTable)
        {
            this.ipAddress = IPAddress.Parse(ipAdress);
            this.port = port;

            listener = new TcpListener(this.ipAddress, this.port);
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable) : this("127.0.0.1", port,routingTable){}

        public HttpServer(Action<IRoutingTable> routingTable) : this( 5000,routingTable){}
        
            
        

        public async Task Start()
        {

            this.listener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {

                var connectionAcceptTcpClient = await this.listener.AcceptTcpClientAsync();
                var networkStream = connectionAcceptTcpClient.GetStream();

                var requestText = await this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                await WriteResponse(networkStream);



                connectionAcceptTcpClient.Close();
            }

        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {

            var bufferLength = 1024;

            var buffer = new byte[bufferLength];

            int total = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                total += bytesRead;
                if (total > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too big");
                }
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream)
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
