using CalzadosLunghi.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalzadosLunghi.Data.Interfaces
{
    public interface IColorData
    {
        Color Add(Color color);
        IEnumerable<Color> GetAll();
        IEnumerable<Color> GetAllByMaterialId(int materialId);
        Task<int> Commit();
    }
}
