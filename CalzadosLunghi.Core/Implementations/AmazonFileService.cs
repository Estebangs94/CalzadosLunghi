using Amazon.S3;
using Amazon.S3.Transfer;
using CalzadosLunghi.Core.Interfaces;
using CalzadosLunghi.Core.Utils;
using CalzadosLunghi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Core.Implementations
{
    public class AmazonFileService : IFileCloudProviderService
    {
        private const string bucketName = "testbucketesteban";


        private readonly IAmazonS3 _s3Client;

        public AmazonFileService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<ErrorMessage> UploadFile(FileValues fileValues)
        {
            try
            {
                var fileTransferUtility =
                        new TransferUtility(_s3Client);

                // Option 1. Upload a file. The file name is used as the object key name.
                await fileTransferUtility.UploadAsync(fileValues.Path, bucketName);

                return new ErrorMessage()
                {
                    HasError = false
                };
            }
            catch (AmazonS3Exception e)
            {
                return new ErrorMessage()
                {
                    HasError = true,
                    Message = $"Unknown error encountered on server. Message:'{e.Message}' when writing an object"
                };
            }
            catch (Exception e)
            {
                return new ErrorMessage()
                {
                    HasError = true,
                    Message = $"Unknown error encountered on server. Message:'{e.Message}' when writing an object"
                };
            }
        }
    }
}
