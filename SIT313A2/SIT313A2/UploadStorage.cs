using Google.Cloud.Storage.V1;
using System;
using System.Diagnostics;

namespace SIT313A2
{
    class UploadStorage
    {
        public virtual Object UploadObject(string bucket, string objectName, string contentType, Stream source, Stream destination, UploadObjectOptions options = null, IProgress<IUploadProgress> progress = null)
        {
            var client = StorageClient.Create();

            using (var stream = File.OpenRead(source))
            {
                // IUploadProgress defined in Google.Apis.Upload namespace
                var progress = new Progress<IUploadProgress>(
                  p => Console.WriteLine($"bytes: {p.BytesSent}, status: {p.Status}")
                );

                // var acl = PredefinedAcl.PublicRead // public
                var acl = PredefinedObjectAcl.AuthenticatedRead; // private
                var options = new UploadObjectOptions { PredefinedAcl = acl };
                var obj = client.UploadObject(bucket, destination, contentType, stream, options, progress);
            }
        }
    }
}