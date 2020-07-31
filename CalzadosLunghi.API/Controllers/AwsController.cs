using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace CalzadosLunghi.API.Controllers
{
    [ApiController]
    [Route("/api/aws")]
    public class AwsController : ControllerBase
    {
        private const string bucketName = "testbucketesteban";
        private const string filePath = "C:/Users/Esteban/Documents/filesTest/test1.txt";

        private readonly IAmazonS3 _s3Client;

        public AwsController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile()
        {
            try
            {
                var fileTransferUtility =
                        new TransferUtility(_s3Client);

                // Option 1. Upload a file. The file name is used as the object key name.
                await fileTransferUtility.UploadAsync(filePath, bucketName);
            }
            catch (AmazonS3Exception e)
            {
                return Problem("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
               return Problem("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

            return Ok();
        }
    }
}
