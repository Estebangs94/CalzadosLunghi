using CalzadosLunghi.Core.Interfaces;
using CalzadosLunghi.Core.Utils;
using CalzadosLunghi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Core.Implementations
{
    class AzureFileService : IFileCloudProviderService
    {
        public Task<ErrorMessage> UploadFile(FileValues fileValues)
        {
            throw new NotImplementedException();
        }
    }
}
