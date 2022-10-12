using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleDemo
{
    class Program
    {
        static WebClient webClient = new WebClient();
        const string bookUrl = "https://the-eye.eu/public/Books/IT%20Various/async_in_c_5.0.pdf";
        const string pdf = "async_in_c.pdf";

        static void Main(string[] args)
        {
            // DownloadSync(bookUrl, pdf);
            // DownloadThread(bookUrl, pdf);
            // DownloadAPM(bookUrl, pdf);
            // DownloadEAP(bookUrl, pdf);
            // DownloadTAP(bookUrl, pdf);
            // DownloadAsyncAwait(bookUrl, pdf);

            Task.Run(async () =>
            {
                try
                {
                    SynchronizationContext sc = SynchronizationContext.Current;
                    await GetRandom()
					    .ContinueWith((r) => { Console.WriteLine("Result: " + r.Result); })
                        .ContinueWith((r) =>
                        {
                            sc.Post(
                                delegate
                                {
                                    Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId + " " +
                                                      r.AsyncState);
                                }, null);
                        });
                }
                catch (OperationCanceledException ca)
                {
                    Console.WriteLine("Cancelled ex");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Catch " + ex);
                }
            });

            Console.WriteLine("End main...");
            Console.ReadLine();
        }

        static async Task<int> GetRandom()
        {
            await Task.Delay(2000);

            Random rnd = new Random();
            return rnd.Next(100);
        }

        static void ProcessFile(string file)
        {
            Console.WriteLine("Open book...");
            Process.Start(pdf);
        }

        static void DownloadSync(string url, string file)
        {
            Console.WriteLine(
                $"Sync: Start download at {DateTime.Now} on ThreadId {Thread.CurrentThread.ManagedThreadId}");
            webClient.DownloadFile(url, file);
            Console.WriteLine($"Sync: End download at {DateTime.Now}");
            ProcessFile(file);
        }

        static void DownloadThread(string url, string file)
        {
            Console.WriteLine(
                $"Sync: Start download at {DateTime.Now} on ThreadId {Thread.CurrentThread.ManagedThreadId}");
            webClient.DownloadFile(url, file);
            Console.WriteLine($"Sync: End download at {DateTime.Now}");
            ProcessFile(file);
        }

        // Asynchronous Programming Model (APM)
        // https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/asynchronous-programming-model-apm
        static void DownloadAPM(string url, string file)
        {
            Console.WriteLine(
                $"APM: Start download at {DateTime.Now} on ThreadId {Thread.CurrentThread.ManagedThreadId}");
            HttpWebRequest req = WebRequest.CreateHttp(url);

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            resp.GetResponseStream();
            using (var input = resp.GetResponseStream())
            {
                using (var output = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int count = 0;
                    while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, count);
                    }
                }
            }

            ;
            Console.WriteLine($"APM: End download at {DateTime.Now}");
            ProcessFile(file);
        }

        // Event-based Asynchronous Pattern
        // https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview
        static void DownloadEAP(string url, string file)
        {
            Console.WriteLine(
                $"EAP: Start download at {DateTime.Now} on ThreadId {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"EAP: End download at {DateTime.Now}");
            ProcessFile(file);
        }

        // Task-based Asynchronous Pattern (TAP)
        // https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap
        static void DownloadTAP(string url, string file)
        {
            Console.WriteLine(
                $"TAP: Start download at {DateTime.Now} on ThreadId {Thread.CurrentThread.ManagedThreadId}");
            Task task = webClient.DownloadFileTaskAsync(url, file);

            Console.WriteLine($"TAP: End download at {DateTime.Now}");
            ProcessFile(file);
        }

        static void DownloadAsyncAwait(string url, string file)
        {
            Console.WriteLine(
                $"TAP: Start download at {DateTime.Now} on ThreadId {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"TAP: End download at {DateTime.Now}");
            ProcessFile(file);
        }
    }
}