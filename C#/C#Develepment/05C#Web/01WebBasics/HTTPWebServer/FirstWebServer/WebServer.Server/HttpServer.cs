using System;
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

        private readonly RoutingTable routingTable;

        public HttpServer(string ipAdress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAdress);
            this.port = port;

            listener = new TcpListener(this.ipAddress, this.port);

            this.routingTable = new RoutingTable();
            routingTableConfiguration(this.routingTable);
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

<<<<<<< HEAD
                Console.WriteLine(requestText);

                // var request = HttpRequest.Parse(requestText);
=======
                var request = HttpRequest.Parse(requestText);
>>>>>>> 7bef16a1170058a9cd26d42208df3367692d8fd8

                var response = this.routingTable.MatchRequest(request);

                await WriteResponse(networkStream,response);

                connectionAcceptTcpClient.Close();
            }

        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {

            var bufferLength = 1024;

            int totalBytes = 0;
            var buffer = new byte[bufferLength];

            int total = 0;

            var requestBuilder = new StringBuilder();

            do
            {

                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large");
                }

                total += bytesRead;
                if (total > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too big");
                }
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
<<<<<<< HEAD


            } while (networkStream.DataAvailable);

=======
            }
            while (networkStream.DataAvailable);
>>>>>>> 8968228426709d2273f6f7b554728106b5d5134c

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream,HttpResponse response)
        {
   

            var responseBites = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBites);

        }
    }
}
