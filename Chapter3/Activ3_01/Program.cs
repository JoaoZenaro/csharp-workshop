using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Chapter3.Activ3_01
{
    public class DownloadProgressChangedEventArgs
    {
        public int ProgressPercentage { get; init; }
        public long BytesReceived { get; init; }

        public DownloadProgressChangedEventArgs(int progressPercentage, long bytesReceived) {
            ProgressPercentage = progressPercentage;
            BytesReceived = bytesReceived;
        }
    }

    public class WebClientAdapter
    {
        public event EventHandler DownloadCompleted;
        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public event EventHandler<string> DownloadError;

        public IDisposable DownloadFile(string url, string destination)
        {
            if(!Uri.TryCreate(url, UriKind.Absolute, out var uri)) 
            {
                DownloadError?.Invoke(this, url);
                return null;
            }

            var client = new WebClient();
            client.DownloadFileCompleted += (sender, args) => DownloadCompleted?.Invoke(this, EventArgs.Empty);

            client.DownloadProgressChanged += (sender, args) => DownloadProgressChanged?.Invoke(this, new DownloadProgressChangedEventArgs(args.ProgressPercentage, args.BytesReceived));

            client.DownloadFileAsync(uri, destination);

            return client;
        }
    }

    public class Program
    {
        public static void Main()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a URL: ");
                input = Console.ReadLine();

                if(!string.IsNullOrEmpty(input))
                {
                    string destination;
                    var lastSlash = input.LastIndexOf('/');
                    if(lastSlash > -1)
                    {
                        destination = Path.Join(Path.GetTempPath(), input.Substring(lastSlash + 1));
                    } else
                    {
                        destination = Path.GetTempFileName();
                    }
                    Download(input, destination);
                }
            } while(input != string.Empty);
        }

        private static void Download(string url, string destination)
        {
            var client = new WebClientAdapter();
            var waiter = new ManualResetEventSlim(false);

            using (waiter)
            {
                client.DownloadError += (sender, args) =>
                {
                    var oldColor = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Download error: {args}");
                    Console.BackgroundColor = oldColor;
                };

                client.DownloadProgressChanged += (sender, args) => {
                    Console.WriteLine($"Downloading...{args.ProgressPercentage}% complete ({args.BytesReceived:N0} bytes)");
                };

                client.DownloadCompleted += (sender, args) => {
                    Console.WriteLine($"Downloaded to {destination}");
                    waiter.Set();
                };

                Console.WriteLine($"Downloading {url}...");
                var request = client.DownloadFile(url, destination);
                if ( request == null )
                    return;

                using (request)
                {
                    if (!waiter.Wait(TimeSpan.FromSeconds(10D)))
                    {
                        Console.WriteLine($"Timedout downloading {url}");
                    }
                }

            }
        }
    }
}