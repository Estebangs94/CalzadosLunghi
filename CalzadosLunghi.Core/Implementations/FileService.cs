using CalzadosLunghi.Core.Interfaces;
using CalzadosLunghi.Data;
using CalzadosLunghi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Core.Implementations
{
    public class FileService : IFileService
    {
        public const string FilePath = "C:/Users/Esteban/Documents/filesTest/";
        private readonly CalzadosLunghiDbContext _context;

        public FileService(CalzadosLunghiDbContext context)
        {
            _context = context;
        }

        public async Task<FileValues> CreateFile(FileValues fileValues)
        {
            var path = String.Concat(FilePath, fileValues.FileName);

            var logFile = System.IO.File.Create(path);
            var logWriter = new System.IO.StreamWriter(logFile);

            logWriter.WriteLine($"Your file was created at: {path}");
            logWriter.WriteLine($"Your text: {fileValues.Text}");

            logWriter.Dispose();

            fileValues.Path = path;

            await _context.FilesValues.AddAsync(fileValues);
            await _context.SaveChangesAsync();

            return fileValues;
        }
    }
}
