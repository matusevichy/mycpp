/*
Trying 127.0.0.1...
Connected to 127.0.0.1.
Escape character is '^]'.
220 maksym-Lenovo-ideapad-700-17ISK ESMTP Postfix (Ubuntu)
HELO localhost
250 maksym-Lenovo-ideapad-700-17ISK
MAIL FROM: maksym@localhost
250 2.1.0 Ok
RCPT TO: maksym@localhost
250 2.1.5 Ok
DATA
354 End data with <CR><LF>.<CR><LF>
From: maksym@localhost
Subject: test email from telnet

Good morning!

.
250 2.0.0 Ok: queued as D9CF92BC0EA2
QUIT
221 2.0.0 Bye
Connection closed by foreign host.
*/

using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

var smtpClient = new TcpClient("localhost", 25);
using var stream = smtpClient.GetStream();
using var writeStream = new StreamWriter(stream, Encoding.Latin1);
writeStream.AutoFlush = true;

using var readerStream = new StreamReader(stream, Encoding.Latin1);

// Read greeting
string line;
do
{
    line = await readerStream.ReadLineAsync();
    Console.WriteLine(line);
} while (!Regex.IsMatch(line, @"^\d{3}"));

await writeStream.WriteAsync("HELO localhost\r\n");
line = await readerStream.ReadLineAsync();
Console.WriteLine(line);
await writeStream.WriteAsync("MAIL FROM: maksym@localhost\r\n");
line = await readerStream.ReadLineAsync();
Console.WriteLine(line);
await writeStream.WriteAsync("RCPT TO: maksym@localhost\r\n");
line = await readerStream.ReadLineAsync();
Console.WriteLine(line);
await writeStream.WriteAsync("DATA\r\n");
await readerStream.ReadLineAsync();

await writeStream.WriteAsync("From: maksym@localhost\r\n");
await writeStream.WriteAsync("To: maksym@localhost\r\n");
await writeStream.WriteAsync("Subject: test email from clientSmtp\r\n");
Console.WriteLine("Write your message: ");
var message = Console.ReadLine();
await writeStream.WriteAsync($"{message}\r\n");
await writeStream.WriteAsync(".\r\n");
line = await readerStream.ReadLineAsync();
Console.WriteLine(line);
await writeStream.WriteAsync("QUIT");