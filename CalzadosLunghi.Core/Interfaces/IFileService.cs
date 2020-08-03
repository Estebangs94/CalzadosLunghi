using CalzadosLunghi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Core.Interfaces
{
    public interface IFileService
    {
         public Task<FileValues> CreateFile(FileValues fileValues);
    }
}
