using AutoMapper;
using CalzadosLunghi.API.DTO;
using CalzadosLunghi.Core.Interfaces;
using CalzadosLunghi.Entities;
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

        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IFileCloudProviderService _fileCloudProviderService;

        public FileController(IFileService fileCreationService, IMapper mapper, IFileCloudProviderService fileCloudProviderService)
        {
            _fileService = fileCreationService;
            _mapper = mapper;
            _fileCloudProviderService = fileCloudProviderService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateFile(FileForCreationDto fileForCreationDto)
        {
            var path = String.Concat(FilePath, fileForCreationDto.FileName);


            var logFile = System.IO.File.Create(path);
            var logWriter = new System.IO.StreamWriter(logFile);

            logWriter.WriteLine($"Your file was created at: {path}");
            logWriter.WriteLine($"Your text: {fileForCreationDto.Text}");

            logWriter.Dispose();

            using (var httpClient = new HttpClient())
            {
                var parameters = new Dictionary<string, string>();
                var encodedContent = new FormUrlEncodedContent(parameters);

                try
                {
                    var response = await httpClient.PostAsync("https://localhost:44374/api/aws", encodedContent);
                    if (!response.IsSuccessStatusCode)
                    {
                       return Problem("Your file wasn't able to be uploaded");            
                    }
                    
                    return Ok("Your file was succesfully created and uploaded to AWS!");
                }
                catch(Exception e)
                {
                    return Problem($"There was an error {e.Message}", $"{e.InnerException}");
                }
            };
        }

        [HttpPost]
        [Route("createandupload")]
        public async Task<IActionResult> CreateAndUploadFile(FileForCreationDto fileForCreationDto)
        {
            var fileValues = await _fileService.CreateFile(_mapper.Map<FileValues>(fileForCreationDto));

            var error = await _fileCloudProviderService.UploadFile(fileValues);

            if(error.HasError)
            {
                return Problem(error.Message);
            }

            return Ok("Your file was created and uploaded to AWS!");
        }
    }
}
