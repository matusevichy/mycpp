
// 1. Start tcp listener to listen port 8080

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

var tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
tcpListener.Start();

while (true)
{
    // 2. In loop establish with client
    using var client = await tcpListener.AcceptTcpClientAsync();
    WriteLine("-= Begin =-");
   
    using var netStream = client.GetStream();
    
    // 3. Get HTTP Request from client
    using var requestStream = new StreamReader(netStream);
    var httpRequestBuilder = new StringBuilder();
    string line;
    while (!string.IsNullOrWhiteSpace(line = await requestStream.ReadLineAsync()))
    {
        httpRequestBuilder.Append(line).AppendLine();
    }

    WriteLine("-= HTTP Request =-");
    var httpRequest = httpRequestBuilder.ToString();

    WriteLine(httpRequest);

    string regex = @"GET \/([\w.]*)\?*a=([\w\W]*)&b=([\w\W]*) HTTP";
    var match = Regex.Match(httpRequest, regex);

    int a = 0;
    int b = 0;

    if (match.Value !="")
    {
        a = int.Parse(match.Groups[2].Value);
        b = int.Parse(match.Groups[3].Value);
    }

    // 4. Send HTTP Response to client
    using var responseStream = new StreamWriter(netStream);
    responseStream.AutoFlush = true;
    var html = $@"<!doctype html>
<html>
    <head>
        <title>Server made this page</title>
    </head>
    <body>
        <h1>Hello World</h1>
        <h2>HTTP Request</h2>
        <pre>{httpRequest}</pre>
        <p>Server time: {DateTime.Now}</p>
        <p>a + b = {a+b}</p>
    </body>
</html>";
    var httpResponse = "HTTP/1.1 200 OK\r\n"
                       + "Content-Type: text/html\r\n"
                       + $"Content-Length: {Encoding.ASCII.GetByteCount(html)}\r\n"
                       + "Connection: close\r\n"
                       + "\r\n"
                       + html;
    WriteLine("-= HTTP Response =-");
    WriteLine(httpResponse);
    await responseStream.WriteAsync(httpResponse);
    WriteLine("-= End =-");
}