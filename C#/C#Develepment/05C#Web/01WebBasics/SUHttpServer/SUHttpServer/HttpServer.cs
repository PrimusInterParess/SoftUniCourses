using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUHttpServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string _ipAddress, int _port = 8080)
        {
            this.ipAddress = IPAddress.Parse(_ipAddress);
            this.port = _port;

            serverListener = new TcpListener(ipAddress, port);
        }

        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server is listening on port {port}");
            Console.WriteLine($"Listening for requests...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();
                var networkStream = connection.GetStream();
                WriteResponce(networkStream, "Hello World!");

                var requestText = this.ReadRequest(networkStream);
                Console.WriteLine(requestText);
                connection.Close();
            }

        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var totalBytes = 0;
            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

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

        private static void WriteResponce(NetworkStream networkStream, string content)
        {

            int contentLengt = Encoding.UTF8.GetByteCount(content);

            string responce = $@"HTTP/1.1 200 OK
Content-type: text/plain; charset=UTF-8
Content-Length: {contentLengt}

{content}";

            var responceBytes = Encoding.UTF8.GetBytes(responce);

            networkStream.Write(responceBytes, 0, responceBytes.Length);
        }
    }
}
