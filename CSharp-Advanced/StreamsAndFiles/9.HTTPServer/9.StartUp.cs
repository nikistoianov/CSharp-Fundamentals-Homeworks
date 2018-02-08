using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _9.HTTPServer
{
    class Program
    {
        static void Main()
        {
            int portNumber = 1234;
            var tcpListener = new TcpListener(IPAddress.Any, portNumber);
            tcpListener.Start();
            Console.WriteLine($"Listening on port {portNumber}...");

            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    string html = string.Format("HTTP/1.1 200 OK\nContent-Type:text\n\n");
                   
                    byte[] request = new byte[4096];
                    stream.Read(request, 0, 4096);
                    string encodedRequest = Encoding.UTF8.GetString(request);
                    Console.WriteLine(encodedRequest);
                    if (encodedRequest.StartsWith("GET / "))
                    {
                        html += "<!doctype html>\r\n<html>\r\n<head>\r\n\t<title>Home Page</title>\r\n</head>\r\n<body>\r\n\t<h1>Welcome to our test page.</h1>\r\n\t<h4>You can check the server information <a href=\"/info\">here</a></h4>\r\n\t<h5>Congratulations for creating your first web app :) </h5>\r\n</body>\r\n</html>";
                    }
                    else if (encodedRequest.StartsWith("GET /info "))
                    {
                        html += $"<!doctype html>\r\n<html>\r\n<head>\r\n\t<meta charset=\"utf-8\" />\r\n<title>Info Page</title>\r\n</head>\r\n<body>\r\n\t<h2>Current Time: {DateTime.Now}</h2>\r\n\t<h2>Logical Processors: {Environment.ProcessorCount}<h2>\r\n</body>\r\n</html>";
                    }
                    else
                    {
                        html += "<!doctype html>\r\n<html>\r\n<head>\r\n\t<title>Error Page</title>\r\n</head>\r\n<body>\r\n\t<h2 style=\"color:red\">Error! Try going to the <a href=\"/\">home page</a></h2>\r\n</body>\r\n</html>";
                    }
                    
                    byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                    stream.Write(htmlBytes, 0, htmlBytes.Length);

                }
            }

        }
    }
}
