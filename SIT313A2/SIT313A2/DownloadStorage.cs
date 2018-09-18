using System;
using System.Collections.Generic;
using System.Text;

namespace SIT313A2
{
    class DownloadStorage
    {
        public virtual void DownloadObject(string bucket, string objectName, Stream destination, DownloadObjectOptions options = null, IProgress<IDownloadProgress> progress = null)
        {
            var client = StorageClient.Create();
            var source = "greetings/hello.txt";
            var destination = "hello.txt";

            using (var stream = File.Create(destination))
            {
                // IDownloadProgress defined in Google.Apis.Download namespace
                var progress = new Progress<IDownloadProgress>(
                    p => Console.WriteLine($"bytes: {p.BytesDownloaded}, status: {p.Status}")
                );

                // Download source object from bucket to local file system
                client.DownloadObject(bucket, source, stream, null, progress);
            }
        }
    }
}
