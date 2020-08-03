using CalzadosLunghi.Core.Utils;
using CalzadosLunghi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Core.Interfaces
{
    public interface IFileCloudProviderService
    {
        public Task<ErrorMessage> UploadFile(FileValues fileValues);
    }
}
