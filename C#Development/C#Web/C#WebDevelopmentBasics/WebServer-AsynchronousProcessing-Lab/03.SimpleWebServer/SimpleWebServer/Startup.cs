namespace SimpleWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var address = IPAddress.Parse("127.0.0.1");
            const int port = 1300;
            var listener = new TcpListener(address, port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at 127.0.0.1:{port}");

            var task = Task.Run(async () => await ConnectWithTcpClient(listener));
            task.Wait();
        }

        private static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected.");

                var buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                var message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(message);

                var data = Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\n\nHello from server!");

                await client.GetStream().WriteAsync(data, 0, data.Length);

                Console.WriteLine("Close connection.");

                client.GetStream().Dispose();
            }
        }
    }
}
