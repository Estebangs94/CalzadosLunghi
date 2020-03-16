using CalzadosLunghi.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Data
{
    public interface ITipoMaterialData
    {
        TipoMaterial Add(TipoMaterial tipoMaterial);
        TipoMaterial GetById(int id);
        TipoMaterial Update(TipoMaterial tipoMaterial);
        TipoMaterial Delete(int id);
        IEnumerable<TipoMaterial> GetAll();
        Task<int> Commit();
    }
}
