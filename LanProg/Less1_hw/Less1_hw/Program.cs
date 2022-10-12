using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

var dir = "public_html";
if (!Directory.Exists(dir))
{
    Console.WriteLine("Home directory not exists. Server shutdown...");
    return -1;
}
var tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
tcpListener.Start();

while (true)
{
    using var tcpClient = await tcpListener.AcceptTcpClientAsync();
    using var tcpStream = tcpClient.GetStream();

    using var requestStream = new StreamReader(tcpStream);

    string str, httpRequest = "";
    while (!string.IsNullOrWhiteSpace(str = await requestStream.ReadLineAsync()))
    {
        httpRequest += str;
    }
    string regex = @"GET \/([\w.]*)\?*([\w\W]*) HTTP";
    var getPass = Regex.Match(httpRequest, regex).Groups[1].Value;
    var file = Path.Combine(dir, getPass);

    using var responseStream = new StreamWriter(tcpStream);
    responseStream.AutoFlush = true;
    string httpResponse="";
    if (File.Exists(file))
    {
        using (var streamFileRead = new StreamReader(file))
        {
            httpResponse = "HTTP/1.1 200 OK\r\n"
                   + "Content-Type: text/html\r\n"
                   + $"Content-Length: {new FileInfo(file).Length}\r\n"
                   + "Connection: close\r\n"
                   + "\r\n";

            string line;
            while ((line = await streamFileRead.ReadLineAsync()) !=null)
            {
                httpResponse += line;
            }
        }
    }
    if (!File.Exists(file))
    {
        httpResponse = "HTTP/1.1 404 OK\r\n";
    }
    await responseStream.WriteAsync(httpResponse);
    ; 
}