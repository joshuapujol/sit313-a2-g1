using Google.Cloud.Storage.V1;
using System;
using System.Diagnostics;

namespace SIT313A2
{
    class CreateStorageBucket
    {
        static void Main(string[] args)
        {
            // Google Cloud Platform project ID.
            string projectId = "sit313-2018";


            // Instantiates a client.
            StorageClient storageClient = StorageClient.Create();

            // The name for the new bucket.
            string bucketName = projectId + "-test-bucket";
            try
            {
                // Creates the new bucket.
                storageClient.CreateBucket(projectId, bucketName);
                Console.WriteLine($"Bucket {bucketName} created.");
            }
            catch (Google.GoogleApiException e)
            when (e.Error.Code == 409)
            {
                // The bucket already exists.  That's fine.
                Console.WriteLine(e.Error.Message);
            }
        }
    }
}