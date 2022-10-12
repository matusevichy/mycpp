using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Less2_cw
{
    internal class MailClient: INotifyPropertyChanged
    {
        private readonly SynchronizationContext context = SynchronizationContext.Current;

        public BindingList<Message> messages;

        string host;
        string user;
        string password;

        private string log;

        public MailClient(string host, string user, string password)
        {
            this.host = host;
            this.user = user;
            this.password = password;
            messages = new BindingList<Message>();
        }

        public string Log
        {
            get { return log; }
            set
            { 
                log = value;
                OnPropertyChanged("Log");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async Task Connect()
        {
        }

        public async Task SendMessage(string mailFrom, string mailTo, string subj, string message)
        {
            var tcpSMTPClient = new TcpClient(host, 25);
            using Stream stream = tcpSMTPClient.GetStream();
            using var writeStream = new StreamWriter(stream, Encoding.ASCII);
            writeStream.AutoFlush = true;
            using var readStream = new StreamReader(stream, Encoding.ASCII);

            string str;
            do
            {
                str = readStream.ReadLine();
                AddToLog(str + Environment.NewLine);
            } while (!str.StartsWith("220"));
            ;
            await writeStream.WriteAsync($"HELO {host}\r\n");
            AddToLog(await readStream.ReadLineAsync() + Environment.NewLine);
            await writeStream.WriteAsync($"MAIL FROM: {mailFrom}\r\n");
            AddToLog(await readStream.ReadLineAsync() + Environment.NewLine);
            await writeStream.WriteAsync($"RCPT TO: <{mailTo}>\r\n");
            AddToLog(await readStream.ReadLineAsync() + Environment.NewLine);
            await writeStream.WriteAsync("DATA\r\n");
            await readStream.ReadLineAsync();

            await writeStream.WriteAsync($"Date: {DateTime.Now}\r\n");
            await writeStream.WriteAsync($"From: {mailFrom}\r\n");
            await writeStream.WriteAsync($"To: {mailTo}\r\n");
            await writeStream.WriteAsync($"Subject: {subj}\r\n");
            await writeStream.WriteAsync($"{message}\r\n");
            await writeStream.WriteAsync(".\r\n");
            AddToLog(await readStream.ReadLineAsync() + Environment.NewLine);
            await writeStream.WriteAsync("QUIT");
            ;
        }

        public async Task GetMessagesList()
        {
            var tcpPOPClient = new TcpClient(host, 110);
            messages.Clear();
            using Stream stream = tcpPOPClient.GetStream();
            using var writeStream = new StreamWriter(stream, Encoding.ASCII);
            writeStream.AutoFlush = true;
            using var readStream = new StreamReader(stream, Encoding.ASCII);

            AddToLog(readStream.ReadLine() + Environment.NewLine);
            await writeStream.WriteAsync($"USER {user}\r\n");
            AddToLog(readStream.ReadLine() + Environment.NewLine);
            await writeStream.WriteAsync($"PASS {password}\r\n");
            var str = readStream.ReadLine();
            if (str.StartsWith("+"))
            {
                var messCount = Regex.Match(str, @"[!]\s*(\d+)\s*messages").Groups[1].Value;
                AddToLog(str + Environment.NewLine);
                for (int i = 1; i <= int.Parse(messCount); i++)
                {
                    await writeStream.WriteAsync($"RETR {i}\r\n");
                    str = readStream.ReadLine();
                    if (str.StartsWith("+OK"))
                    {
                        List<string> strings = new List<string>();
                        do
                        {
                            str = readStream.ReadLine() + Environment.NewLine;
                            strings.Add(str);
                        } while (!str.StartsWith("."));
                        messages.Add(ParseMessage(i, strings));
                        ;
                    }
                }
            }
            else
            {
                MessageBox.Show("Username or password is invalid or incorrect");
            }
        }

        Message ParseMessage(int id, List<string> strings)
        {
            Message msg = new Message();
            msg.Id = id;
            strings.ForEach(s =>
            {
                if (s.StartsWith("From: "))
                {
                    msg.From = GetStringBody(s);
                }
                if (s.StartsWith("To: "))
                {
                    msg.To = GetStringBody(s);
                }
                if (s.StartsWith("Date: "))
                {
                    msg.Date = DateTime.Parse(GetStringBody(s));
                }
                if (s.StartsWith("Subject: "))
                {
                    msg.Subject = GetStringBody(s);
                }
            });
            msg.Body = string.Join("\n", strings);

            return msg;
        }

        string GetStringBody(string str)
        {
            var start = str.IndexOf(":")+2;
            var end = str.IndexOf("\n");
            return str.Substring(start, end-start);
        }

        void AddToLog(string str)
        {
            context.Post(delegate { Log+=str; }, null);
        }
    }
}
