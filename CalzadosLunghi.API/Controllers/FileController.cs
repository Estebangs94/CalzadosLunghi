using CalzadosLunghi.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalzadosLunghi.API.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        public const string FilePath = "C:/Users/Esteban/Documents/filesTest/";

        [HttpPost]
        public async Task<ActionResult> CreateFile(FileValuesDto fileValuesDto)
        {
            var path = String.Concat(FilePath, fileValuesDto.FileName);


            var logFile = System.IO.File.Create(path);
            var logWriter = new System.IO.StreamWriter(logFile);

            logWriter.WriteLine($"Your file was created at: {path}");
            logWriter.WriteLine($"Your text: {fileValuesDto.Text}");

            logWriter.Dispose();

            using (var httpClient = new HttpClient())
            {
                var parameters = new Dictionary<string, string>();
                var encodedContent = new FormUrlEncodedContent(parameters);

                try
                {
                    var response = await httpClient.PostAsync("https://localhost:44374/api/aws", encodedContent);
                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("Your file was succesfully created and uploaded to AWS!");
                    }

                    else return Problem("Your file wasn't able to be uploaded");

                }
                catch(Exception e)
                {
                    return Problem($"There was an error {e.Message}", $"{e.InnerException}");
                }
            };
        }
    }
}
