using System;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

    public class AmazonUpload
    {
        private string bucketName = "missions69";
        private string keyName = "mission69.xml";
        private string filePath = "D:\\AntWork\\AdminTRUE\\Mission69.xml";
    private string dfilePath = "D:\\AntWork\\AdminTRUE\\dmission.xml";
    public void TestDownloadFile(string filePath, string keyName)
    {
        TransferUtility fileTransferUtility =
    new TransferUtility(
        new AmazonS3Client("AKIAJO3YO2ATRVV5UQYA", "4+SelI41UmF0oO8IiXazTizmLy60C82Eaem2nonH", Amazon.RegionEndpoint.EUWest3));
        fileTransferUtility.Download(filePath, bucketName, keyName);
    }
    public void TestUploadFile(string filePath, string keyName)
    {
        TransferUtility fileTransferUtility =
    new TransferUtility(
        new AmazonS3Client("AKIAJO3YO2ATRVV5UQYA", "4+SelI41UmF0oO8IiXazTizmLy60C82Eaem2nonH", Amazon.RegionEndpoint.EUWest3));
        fileTransferUtility.Upload(filePath, bucketName, keyName);
    }
    public void DownloadFile()
    {
        var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest3);

        try
        {
            GetObjectRequest getRequest = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = keyName,
            };
            GetObjectResponse response = client.GetObject(getRequest);
            response.WriteResponseStreamToFile(dfilePath);
        }
        catch (AmazonS3Exception amazonS3Exception)
        {
            if (amazonS3Exception.ErrorCode != null &&
                (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                ||
                amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
            {
                throw new Exception("Check the provided AWS Credentials.");
            }
            else
            {
                throw new Exception("Error occurred: " + amazonS3Exception.Message);
            }
        }

}
    public void UploadFile(string bucketName, string keyName, string filePath)
        {
            var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest3);

        try
        {
            PutObjectRequest putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = keyName,
                FilePath = filePath,
                ContentType = "text/plain"
            };
            PutObjectResponse response = client.PutObject(putRequest);
        }
        catch (AmazonS3Exception amazonS3Exception)
        {
            if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
            {
                throw new Exception("Check the provided AWS Credentials.");
            }
            else
            {
                throw new Exception("Error occurred: " + amazonS3Exception.Message);
            }
        }
    }
}