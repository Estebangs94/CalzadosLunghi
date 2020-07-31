using CalzadosLunghi.API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalzadosLunghi.API.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        public const string FilePath = "C:/Users/Esteban/Documents/filesTest/";

        [HttpPost]
        public ActionResult CreateFile(FileValuesDto fileValuesDto)
        {
            var path = String.Concat(FilePath, fileValuesDto.FileName);

            
            var logFile = System.IO.File.Create(path);
            var logWriter = new System.IO.StreamWriter(logFile);

            logWriter.WriteLine($"Your file was created at: {path}");
            logWriter.WriteLine($"Your text: {fileValuesDto.Text}");

            logWriter.Dispose();

            return Ok();
        }        
    }
}
